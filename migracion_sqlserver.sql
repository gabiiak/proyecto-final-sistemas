/******************************************************************************************************
  T&GSystem  -  Migracion de SQLite (mvp.db) a SQL Server
  ----------------------------------------------------------------------------------------------------
  Origen  : ProyectoFinal/Datos/mvp.db   (12 tablas, 48 filas, 0 filas huerfanas)
  Destino : base SQL Server "TandGSystem"

  Como usarlo:
    1) Abrir SQL Server Management Studio (o Azure Data Studio) y ejecutar este script completo.
    2) El script es idempotente: borra las tablas si ya existen y las vuelve a crear con sus datos.
    3) NO usar IF DB_ID(...) con CREATE DATABASE en Azure SQL Database (no lo permite).
       En ese caso crear la base desde el portal y ejecutar solo desde la linea USE hacia abajo.

  IMPORTANTE - decisiones de mapeo (SQLite -> SQL Server):
    * INTEGER PRIMARY KEY AUTOINCREMENT  ->  INT IDENTITY(1,1) PRIMARY KEY
      (el IDENTITY se re-setea al final con DBCC CHECKIDENT usando sqlite_sequence)
    * TEXT  ->  NVARCHAR(...)   (acentos y enye preservados; se usa prefijo N en los literales)
    * REAL  ->  DECIMAL(18,4)   (se evita el error de redondeo del tipo float)
    * activo / Activo  ->  BIT NOT NULL DEFAULT 1     (solo usan 0 y 1)
    * estado, estadoPedido, estadoPago  ->  TINYINT
      (OJO: NO pueden ser BIT. Van de 0 a 4 - ver Modelos/Estado*.cs)
    * DATE / TEXT con fecha -> DATE ; hora -> TIME
    * DEFAULT 1 de SQLite pasa a DEFAULT 1 explicito.
    * Los nombres de tablas y columnas se conservan EXACTAMENTE como en SQLite, porque el
      codigo C# (las clases de la carpeta Datos) los referencia con esos nombres en el SQL embebido.

  Correcciones aplicadas durante la migracion (el esquema SQLite tenia errores):
    1) Insumos.descripcion estaba declarado INTEGER pero contiene texto ("Kg").
       SQLite lo permitia por tipado debil; en SQL Server habria fallado el INSERT.
       Aqui se declara como NVARCHAR(500).
    2) Ventas.fecha: las 2 filas existentes estaban guardadas como dd-MM-yyyy ("01-05-2026"),
       mientras que el codigo las escribe SIEMPRE como yyyy-MM-dd (Datos/DataVentas.cs:273).
       Se normalizaron a ISO para que sean inequivocas al importar en T-SQL:
         01-05-2026 -> 2026-05-01     23-05-2026 -> 2026-05-23
       En T-SQL el literal ISO yyyy-MM-dd siempre se interpreta bien, sin depender del
       DATEFORMAT del servidor (SET DATEFORMAT dmy).
    3) Se agregaron las FOREIGN KEY que SQLite declaraba pero nunca aplicaba (PRAGMA
       foreign_keys viene OFF por defecto). Se verifico que no hay huerfanos, asi que
       activarlas no rompe nada y aporta integridad real al usar la base en red.
    * 4) DetalleTanda.idEmpleado queda SIN foreign key: no existe la tabla Empleados
       (el modelo Modelos/Empleado.cs esta sin uso y su JOIN esta comentado en
       Datos/DataDetalleTandaProduccion.cs).
    5) TandaProduccion: se unieron las columnas fecha y hora en una sola fecha DATETIME2.
       Motivo tecnico, no de formato: una columna TIME devuelve TimeSpan en .NET, y tanto
       GetDateTime() como GetString() fallan sobre ella, asi que el codigo de lectura
       revienta. Ademas las dos rutas de escritura guardaban formatos distintos en "hora"
       (Datos/DataTandaProduccion.cs:23 usaba yyyy-MM-dd HH:mm:ss y la linea 194 HH:mm:ss).
    6) Transportes.fecha paso de DATE a DATETIME2: el codigo ya guardaba fecha y hora
       (Datos/DataTransporte.cs:22) y la UI la rotula "Fecha y Hora Programada".

  Aclaracion sobre los formatos de fecha: en SQL Server NO existe un tipo "dia-mes-ano".
  Los formatos dd-MM-aaaa / aaaa-MM-dd son solo tema de pantalla y de entrada de datos, y se
  resuelven en C# con .ToString("dd-MM-yyyy"). El almacenamiento (DATE, DATETIME2) es binario
  y neutro respecto del idioma del servidor. La ambiguedad dia/mes que existia en mvp.db
  venia de que SQLite guardaba las fechas como texto; con tipos reales desaparece, y por eso
  los literales de este script son ISO (aaaa-MM-dd), que T-SQL siempre interpreta bien.
  ******************************************************************************************************/

SET NOCOUNT ON;
SET XACT_ABORT ON;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- Crear la base si no existe (omitir este bloque si la base ya existe).
IF DB_ID(N'TandGSystem') IS NULL
BEGIN
    CREATE DATABASE [TandGSystem];
END
GO

USE [TandGSystem];
GO

SET DATEFORMAT dmy;  -- guarda contra literales ambiguos (los del script son ISO, asi que es solo una red de seguridad)
GO

--------------------------------------------------------------------------------
-- 0) DROP de tablas e indices (orden inverso por dependencias) - hace el script idempotente
--------------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.DetalleVentas', N'U') IS NOT NULL DROP TABLE dbo.DetalleVentas;
IF OBJECT_ID(N'dbo.Transportes', N'U')    IS NOT NULL DROP TABLE dbo.Transportes;
IF OBJECT_ID(N'dbo.DetalleTanda', N'U')  IS NOT NULL DROP TABLE dbo.DetalleTanda;
IF OBJECT_ID(N'dbo.Ventas', N'U')        IS NOT NULL DROP TABLE dbo.Ventas;
IF OBJECT_ID(N'dbo.TandaProduccion', N'U') IS NOT NULL DROP TABLE dbo.TandaProduccion;
IF OBJECT_ID(N'dbo.StockInsumo', N'U')   IS NOT NULL DROP TABLE dbo.StockInsumo;
IF OBJECT_ID(N'dbo.StockProducto', N'U') IS NOT NULL DROP TABLE dbo.StockProducto;
IF OBJECT_ID(N'dbo.RecetaProducto', N'U') IS NOT NULL DROP TABLE dbo.RecetaProducto;
IF OBJECT_ID(N'dbo.Productos', N'U')     IS NOT NULL DROP TABLE dbo.Productos;
IF OBJECT_ID(N'dbo.Insumos', N'U')       IS NOT NULL DROP TABLE dbo.Insumos;
IF OBJECT_ID(N'dbo.MetodosPago', N'U')  IS NOT NULL DROP TABLE dbo.MetodosPago;
IF OBJECT_ID(N'dbo.Clientes', N'U')      IS NOT NULL DROP TABLE dbo.Clientes;
GO

--------------------------------------------------------------------------------
-- 1) ESQUEMA
--------------------------------------------------------------------------------

-- ---------- Tablas sin dependencias ----------

CREATE TABLE dbo.Clientes (
    [id]        INT IDENTITY(1,1) NOT NULL,
    [nombre]    NVARCHAR(100)  NOT NULL,
    [empresa]   NVARCHAR(150)  NOT NULL,
    [direccion] NVARCHAR(250)  NOT NULL,
    [activo]    BIT            NOT NULL DEFAULT 1,
    [telefono]  NVARCHAR(50)   NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

CREATE TABLE dbo.MetodosPago (
    [IdMetodoPago] INT IDENTITY(1,1) NOT NULL,
    [Descripcion]  NVARCHAR(100) NOT NULL,
    [Activo]       BIT           NOT NULL DEFAULT 1,
    CONSTRAINT [PK_MetodosPago] PRIMARY KEY CLUSTERED ([IdMetodoPago] ASC)
);
GO

CREATE TABLE dbo.Productos (
    [IdProducto]     INT IDENTITY(1,1) NOT NULL,
    [Nombre]         NVARCHAR(100)  NOT NULL,
    [Descripcion]    NVARCHAR(500)  NOT NULL,
    [Precio]         DECIMAL(18,4)  NOT NULL,
    [Activo]         BIT            NOT NULL DEFAULT 1,
    [vidaUtilDias]   INT            NULL,
    CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED ([IdProducto] ASC)
);
GO

-- NOTA: en SQLite la columna [descripcion] estaba declarada INTEGER (error de esquema).
--       Contiene texto, asi que va como NVARCHAR.
CREATE TABLE dbo.Insumos (
    [id]            INT IDENTITY(1,1) NOT NULL,
    [nombre]        NVARCHAR(100) NULL,
    [descripcion]   NVARCHAR(500) NULL,   -- <-- corregido: era INTEGER en mvp.db
    [precio]        DECIMAL(18,4) NULL,
    [activo]        BIT           NULL,
    [unidadMedida]  NVARCHAR(20)  NULL,
    CONSTRAINT [PK_Insumos] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

-- ---------- Tablas con dependencias ----------

CREATE TABLE dbo.RecetaProducto (
    [idReceta]          INT IDENTITY(1,1) NOT NULL,
    [idProducto]        INT           NOT NULL,
    [idInsumo]          INT           NOT NULL,
    [cantidadPorUnidad] DECIMAL(18,4) NOT NULL,
    CONSTRAINT [PK_RecetaProducto] PRIMARY KEY CLUSTERED ([idReceta] ASC),
    CONSTRAINT [FK_RecetaProducto_Producto] FOREIGN KEY ([idProducto])
        REFERENCES dbo.Productos ([IdProducto]) ON UPDATE CASCADE ON DELETE NO ACTION,
    CONSTRAINT [FK_RecetaProducto_Insumo] FOREIGN KEY ([idInsumo])
        REFERENCES dbo.Insumos ([id]) ON UPDATE CASCADE ON DELETE NO ACTION
);
GO

CREATE TABLE dbo.StockProducto (
    [id]          INT IDENTITY(1,1) NOT NULL,
    [producto_id] INT           NOT NULL,
    -- INT a proposito: el stock de productos se cuenta por unidades (medallones), no por peso.
    -- Los insumos SI van en DECIMAL porque ahi si hay fracciones (98,2 Kg de carne, 0,15 Kg por medallon).
    [cantidad]    INT           NULL,
    CONSTRAINT [PK_StockProducto] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_StockProducto_Producto] FOREIGN KEY ([producto_id])
        REFERENCES dbo.Productos ([IdProducto]) ON UPDATE CASCADE ON DELETE CASCADE
);
GO

CREATE TABLE dbo.StockInsumo (
    [id]        INT IDENTITY(1,1) NOT NULL,
    [insumo_id] INT           NOT NULL,
    -- DECIMAL porque los insumos se miden en Kg/Gr y admiten fracciones
    [cantidad]  DECIMAL(18,4) NULL,
    CONSTRAINT [PK_StockInsumo] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_StockInsumo_Insumo] FOREIGN KEY ([insumo_id])
        REFERENCES dbo.Insumos ([id]) ON UPDATE CASCADE ON DELETE CASCADE
);
GO

CREATE TABLE dbo.TandaProduccion (
    [idTanda]            INT IDENTITY(1,1) NOT NULL,
    [idProducto]         INT           NOT NULL,
    -- fecha y hora en UNA sola columna DATETIME2. En mvp.db estaban separadas (fecha + hora)
    -- y eso obligaba a usar una columna TIME, que en .NET vuelve como TimeSpan y hace fallar
    -- GetDateTime(). Ademas las dos rutas de escritura del codigo guardaban formatos distintos
    -- (yyyy-MM-dd HH:mm:ss y HH:mm:ss) en la misma columna "hora".
    -- El modelo TandaProduccion sigue teniendo Fecha y Hora por separado: las dos propiedades
    -- se leen de este mismo valor, y la UI ya imprime Hora como .ToString("HH:mm:ss").
    [fecha]              DATETIME2(0)   NULL,
    [estado]             TINYINT       NULL,   -- 0..3  (Modelos/EstadoTanda.cs)
    [cantidadProducida]  INT           NULL,
    [fechaCaducidad]     DATE          NULL,
    CONSTRAINT [PK_TandaProduccion] PRIMARY KEY CLUSTERED ([idTanda] ASC),
    CONSTRAINT [FK_TandaProduccion_Producto] FOREIGN KEY ([idProducto])
        REFERENCES dbo.Productos ([IdProducto]) ON UPDATE CASCADE ON DELETE NO ACTION
);
GO

CREATE TABLE dbo.DetalleTanda (
    [idDetalleTanda]     INT IDENTITY(1,1) NOT NULL,
    [idTandaProd]        INT           NOT NULL,
    [idInsumo]           INT           NOT NULL,
    [idEmpleado]         INT           NULL,   -- sin FK: la tabla Empleados no existe
    [cantidadUtilizada]  DECIMAL(18,4) NULL,
    CONSTRAINT [PK_DetalleTanda] PRIMARY KEY CLUSTERED ([idDetalleTanda] ASC),
    CONSTRAINT [FK_DetalleTanda_Tanda] FOREIGN KEY ([idTandaProd])
        REFERENCES dbo.TandaProduccion ([idTanda]) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT [FK_DetalleTanda_Insumo] FOREIGN KEY ([idInsumo])
        REFERENCES dbo.Insumos ([id]) ON UPDATE CASCADE ON DELETE NO ACTION
);
GO

CREATE TABLE dbo.Ventas (
    [idVenta]       INT IDENTITY(1,1) NOT NULL,
    [idCliente]     INT           NOT NULL,
    [idMetodoPago]  INT           NOT NULL,
    [fecha]         DATE          NOT NULL,
    [estadoPedido]  TINYINT       NOT NULL DEFAULT 1,   -- 0..4 (Modelos/EstadoPedido.cs)
    [estadoPago]    TINYINT       NOT NULL DEFAULT 1,   -- 0..2 (Modelos/EstadoPago.cs)
    [totalVenta]    DECIMAL(18,4) NULL,
    [montoRecibido] DECIMAL(18,4) NULL,
    CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED ([idVenta] ASC),
    CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY ([idCliente])
        REFERENCES dbo.Clientes ([id]) ON UPDATE CASCADE ON DELETE NO ACTION,
    CONSTRAINT [FK_Venta_MetodoPago] FOREIGN KEY ([idMetodoPago])
        REFERENCES dbo.MetodosPago ([IdMetodoPago]) ON UPDATE CASCADE ON DELETE NO ACTION
);
GO

CREATE TABLE dbo.DetalleVentas (
    [idDetalleVenta] INT IDENTITY(1,1) NOT NULL,
    [idVenta]        INT           NOT NULL,
    [idProducto]     INT           NOT NULL,
    [cantidad]       INT           NOT NULL,
    [subTotal]       DECIMAL(18,4) NULL,
    CONSTRAINT [PK_DetalleVentas] PRIMARY KEY CLUSTERED ([idDetalleVenta] ASC),
    CONSTRAINT [FK_DetalleVenta_Venta] FOREIGN KEY ([idVenta])
        REFERENCES dbo.Ventas ([idVenta]) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT [FK_DetalleVenta_Producto] FOREIGN KEY ([idProducto])
        REFERENCES dbo.Productos ([IdProducto]) ON UPDATE CASCADE ON DELETE NO ACTION
);
GO

CREATE TABLE dbo.Transportes (
    [idTransporte] INT IDENTITY(1,1) NOT NULL,
    [idVenta]      INT           NOT NULL,
    -- DATETIME2 y no DATE: el codigo ya guardaba fecha Y hora (Datos/DataTransporte.cs:22 usa
    -- "yyyy-MM-dd HH:mm:ss") y la UI la llama "Fecha y Hora Programada".
    [fecha]        DATETIME2(0)   NOT NULL,
    [estado]       TINYINT       NOT NULL,   -- 0..3 (Modelos/EstadoTransporte.cs)
    CONSTRAINT [PK_Transportes] PRIMARY KEY CLUSTERED ([idTransporte] ASC),
    CONSTRAINT [FK_Transporte_Venta] FOREIGN KEY ([idVenta])
        REFERENCES dbo.Ventas ([idVenta]) ON UPDATE CASCADE ON DELETE CASCADE
);
GO

--------------------------------------------------------------------------------
-- 2) DATOS  (generado desde mvp.db, orden SDL respetando las dependencias)
--------------------------------------------------------------------------------

BEGIN TRANSACTION;

-- Clientes (7 filas)
-- Se preservan los IDs originales, asi que hay que habilitar IDENTITY_INSERT para esta tabla.
SET IDENTITY_INSERT dbo.Clientes ON;
INSERT INTO [Clientes] (id, nombre, empresa, direccion, activo, telefono) VALUES
  (N'1', N'Pedro', N'RotiseriaGralPaz', N'Lima-271', 1, N'3516807998'),
  (N'2', N'José', N'LoDeJosé', N'Av.Libertador-812', 1, N'3518721113'),
  (N'3', N'Manuel', N'LaDoctaBodegon', N'Av. Colón 1240', 1, N'3514289104'),
  (N'4', N'Valentina', N'Peperina&Carbon', N'Belgrano 782', 1, N'3515693321'),
  (N'5', N'Mateo', N'SanJeronimoResto', N'Mariano Fragueiro 1955', 1, N'3513401198'),
  (N'6', N'Camila', N'SaborSerrano', N'Av. Rafael Núñez 4120', 1, N'3517110542'),
  (N'7', N'Facundo', N'LaVieCaniadaTattoria', N'Caseros 340', 1, N'3512398876');
SET IDENTITY_INSERT dbo.Clientes OFF;

-- MetodosPago (3 filas)
-- Se preservan los IDs originales, asi que hay que habilitar IDENTITY_INSERT para esta tabla.
SET IDENTITY_INSERT dbo.MetodosPago ON;
INSERT INTO [MetodosPago] (IdMetodoPago, Descripcion, Activo) VALUES
  (N'1', N'Transferencia', 1),
  (N'2', N'Efectivo', 1),
  (N'3', N'QR', 1);
SET IDENTITY_INSERT dbo.MetodosPago OFF;

-- Productos (6 filas)
-- Se preservan los IDs originales, asi que hay que habilitar IDENTITY_INSERT para esta tabla.
-- La columna fechaCaducidad que venia de mvp.db (2029-06-25 en los 6 productos) se elimino en la
-- fase 2: no tenia relacion con vidaUtilDias y ningun codigo la leia. La caducidad real de un
-- lote se calcula al finalizar la tanda (fecha + vidaUtilDias) y se guarda en
-- TandaProduccion.fechaCaducidad.
SET IDENTITY_INSERT dbo.Productos ON;
INSERT INTO [Productos] (IdProducto, Nombre, Descripcion, Precio, Activo, vidaUtilDias) VALUES
  (N'1', N'carne-150grs', N'medallon de carne 30% grasa', 2000.3, 1, N'90'),
  (N'2', N'magra-150grs', N'medallon de carne 90% magra', 3900.3, 1, N'90'),
  (N'3', N'pollo-150grs', N'medallon de pollo y especias', 4100.3, 1, N'90'),
  (N'4', N'pescado-120grs', N'medallon de merluza condimentado', 2100.3, 1, N'90'),
  (N'5', N'vegana-120grs', N'medallón de legumbres 100% origen vegetal', 4100, 1, N'90'),
  (N'6', N'smash-90grs', N'mix de carne y chorizo para smashear', 5100, 1, N'90');
SET IDENTITY_INSERT dbo.Productos OFF;

-- Insumos (8 filas)
-- Se preservan los IDs originales, asi que hay que habilitar IDENTITY_INSERT para esta tabla.
SET IDENTITY_INSERT dbo.Insumos ON;
INSERT INTO [Insumos] (id, nombre, descripcion, precio, activo, unidadMedida) VALUES
  (N'1', N'carne_vaca', N'Kg', 13900, 1, N'Kg'),
  (N'2', N'pollo', N'Kg', 7900, 1, N'Kg'),
  (N'3', N'pescado', N'Kg', 12000, 1, N'Kg'),
  (N'4', N'chorizo', N'Kg', 8000, 1, N'Kg'),
  (N'5', N'sal', N'Kg', 6900, 1, N'Gr'),
  (N'6', N'pimienta', N'Kg', 6900, 1, N'Gr'),
  (N'7', N'soja', N'Kg', 1700, 1, N'Kg'),
  (N'8', N'semillas_mostaza', N'Kg', 3000, 1, N'Gr');
SET IDENTITY_INSERT dbo.Insumos OFF;

-- RecetaProducto (3 filas)
-- Se preservan los IDs originales, asi que hay que habilitar IDENTITY_INSERT para esta tabla.
SET IDENTITY_INSERT dbo.RecetaProducto ON;
INSERT INTO [RecetaProducto] (idReceta, idProducto, idInsumo, cantidadPorUnidad) VALUES
  (1, 1, 1, 0.15),
  (2, 1, 5, 5),
  (3, 3, 2, 0.15);
SET IDENTITY_INSERT dbo.RecetaProducto OFF;

-- StockProducto (4 filas)
-- Se preservan los IDs originales, asi que hay que habilitar IDENTITY_INSERT para esta tabla.
SET IDENTITY_INSERT dbo.StockProducto ON;
INSERT INTO [StockProducto] (id, producto_id, cantidad) VALUES
  (1, 1, 200),
  (2, 2, 200),
  (3, 3, 200),
  (4, 4, 200);
SET IDENTITY_INSERT dbo.StockProducto OFF;

-- StockInsumo (5 filas)
-- Se preservan los IDs originales, asi que hay que habilitar IDENTITY_INSERT para esta tabla.
SET IDENTITY_INSERT dbo.StockInsumo ON;
INSERT INTO [StockInsumo] (id, insumo_id, cantidad) VALUES
  (1, 1, 100),
  (2, 2, 100),
  (3, 3, 30),
  (4, 4, 30),
  (5, 5, 3000);
SET IDENTITY_INSERT dbo.StockInsumo OFF;

-- TandaProduccion (1 filas)
-- Se preservan los IDs originales, asi que hay que habilitar IDENTITY_INSERT para esta tabla.
-- fechaCaducidad = fecha + vidaUtilDias del producto (carne-150grs = 90 dias), que es como la
-- calcula Negocio/NTandaProduccion al finalizar la tanda. Ver NOTA sobre el dato heredado de
-- mvp.db mas abajo: venia con 2026-09-25, que no correspondia a fecha + 90.
SET IDENTITY_INSERT dbo.TandaProduccion ON;
INSERT INTO [TandaProduccion] (idTanda, idProducto, fecha, estado, cantidadProducida, fechaCaducidad) VALUES
  (1, 1, N'2026-06-25 23:59:00', 1, 1, N'2026-09-23');
SET IDENTITY_INSERT dbo.TandaProduccion OFF;

-- DetalleTanda (0 filas: la tabla queda creada y vacia, como en mvp.db)
-- Ventas (2 filas)
-- Se preservan los IDs originales, asi que hay que habilitar IDENTITY_INSERT para esta tabla.
SET IDENTITY_INSERT dbo.Ventas ON;
INSERT INTO [Ventas] (idVenta, idCliente, idMetodoPago, fecha, estadoPedido, estadoPago, totalVenta, montoRecibido) VALUES
  (1, 1, 1, N'2026-05-01', 1, 1, 10000, 100),
  (2, 2, 1, N'2026-05-23', 1, 1, 10000, 100);
SET IDENTITY_INSERT dbo.Ventas OFF;

-- DetalleVentas (9 filas)
-- Se preservan los IDs originales, asi que hay que habilitar IDENTITY_INSERT para esta tabla.
SET IDENTITY_INSERT dbo.DetalleVentas ON;
INSERT INTO [DetalleVentas] (idDetalleVenta, idVenta, idProducto, cantidad, subTotal) VALUES
  (1, 1, 1, 3, 2000),
  (2, 1, 1, 3, 2000),
  (3, 1, 1, 3, 2000),
  (4, 1, 1, 3, 2000),
  (5, 2, 2, 2, 3000),
  (6, 2, 2, 2, 3000),
  (7, 2, 2, 2, 3000),
  (8, 2, 2, 2, 3000),
  (9, 2, 2, 2, 3000);
SET IDENTITY_INSERT dbo.DetalleVentas OFF;

-- Transportes (0 filas: la tabla queda creada y vacia, como en mvp.db)
COMMIT TRANSACTION;
GO

--------------------------------------------------------------------------------
-- 3) RE-SECUENCIAR los IDENTITY  (valores tomados de sqlite_sequence de mvp.db)
--    Sin esto, un INSERT nuevo arrancaria en 1 y chocaria con las claves existentes.
--------------------------------------------------------------------------------
DBCC CHECKIDENT ('dbo.Clientes', RESEED, 7) WITH NO_INFOMSGS;
DBCC CHECKIDENT ('dbo.DetalleTanda', RESEED, 0) WITH NO_INFOMSGS;
DBCC CHECKIDENT ('dbo.DetalleVentas', RESEED, 9) WITH NO_INFOMSGS;
DBCC CHECKIDENT ('dbo.Insumos', RESEED, 8) WITH NO_INFOMSGS;
DBCC CHECKIDENT ('dbo.MetodosPago', RESEED, 3) WITH NO_INFOMSGS;
DBCC CHECKIDENT ('dbo.Productos', RESEED, 6) WITH NO_INFOMSGS;
DBCC CHECKIDENT ('dbo.RecetaProducto', RESEED, 3) WITH NO_INFOMSGS;
DBCC CHECKIDENT ('dbo.StockInsumo', RESEED, 5) WITH NO_INFOMSGS;
DBCC CHECKIDENT ('dbo.StockProducto', RESEED, 4) WITH NO_INFOMSGS;
DBCC CHECKIDENT ('dbo.TandaProduccion', RESEED, 1) WITH NO_INFOMSGS;
DBCC CHECKIDENT ('dbo.Ventas', RESEED, 2) WITH NO_INFOMSGS;
GO

-- PRINT no admite subconsultas, por eso la verificacion va como SELECT.
SELECT * FROM (
    SELECT 'Clientes'        AS Tabla, COUNT_BIG(*) AS Filas FROM dbo.Clientes        UNION ALL
    SELECT 'MetodosPago',    COUNT_BIG(*) FROM dbo.MetodosPago                      UNION ALL
    SELECT 'Productos',       COUNT_BIG(*) FROM dbo.Productos                         UNION ALL
    SELECT 'Insumos',         COUNT_BIG(*) FROM dbo.Insumos                           UNION ALL
    SELECT 'RecetaProducto',  COUNT_BIG(*) FROM dbo.RecetaProducto                    UNION ALL
    SELECT 'StockProducto',   COUNT_BIG(*) FROM dbo.StockProducto                     UNION ALL
    SELECT 'StockInsumo',     COUNT_BIG(*) FROM dbo.StockInsumo                       UNION ALL
    SELECT 'TandaProduccion', COUNT_BIG(*) FROM dbo.TandaProduccion                   UNION ALL
    SELECT 'DetalleTanda',    COUNT_BIG(*) FROM dbo.DetalleTanda                      UNION ALL
    SELECT 'Ventas',          COUNT_BIG(*) FROM dbo.Ventas                            UNION ALL
    SELECT 'DetalleVentas',   COUNT_BIG(*) FROM dbo.DetalleVentas                     UNION ALL
    SELECT 'Transportes',     COUNT_BIG(*) FROM dbo.Transportes
) AS Conteo ORDER BY Tabla;
GO

--------------------------------------------------------------------------------
-- 4) INDICES RECOMENDADOS (opcionales; SQLite no los tenia, pero con varios
--    usuarios concurrentes conviene. Descomentar si la base crece.)
--------------------------------------------------------------------------------
-- CREATE NONCLUSTERED INDEX IX_Ventas_idCliente      ON dbo.Ventas (idCliente);
-- CREATE NONCLUSTERED INDEX IX_Ventas_fecha          ON dbo.Ventas (fecha);
-- CREATE NONCLUSTERED INDEX IX_DetalleVentas_idVenta ON dbo.DetalleVentas (idVenta);
-- CREATE NONCLUSTERED INDEX IX_TandaProd_idProducto  ON dbo.TandaProduccion (idProducto);
-- CREATE NONCLUSTERED INDEX IX_StockProducto_prod    ON dbo.StockProducto (producto_id);
-- CREATE NONCLUSTERED INDEX IX_StockInsumo_ins       ON dbo.StockInsumo (insumo_id);
GO
