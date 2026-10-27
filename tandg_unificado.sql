/******************************************************************************************************
  T&GSystem  -  Script UNICO de base de datos (SQL Server)
  ----------------------------------------------------------------------------------------------------
  Destino : base SQL Server "TandGSystem"  (o la de prueba "TandGSystemTest", ver uso abajo)

  Este script reemplaza a los 4 anteriores:
      migracion_sqlserver.sql         -> esquema completo + datos iniciales (viene de mvp.db)
      migracion_delta.sql             -> KAN-84 (estadoPago -> estadoCobro, columnas de Compras, etc.)
      evaluacion_proveedor.sql  \ 
      TablaEvaluacionProveedor.sql  / -> tabla EvaluacionProveedor (modulo de IA)

  ES IDEMPOTENTE Y NO DESTRUCTIVO: se puede correr N veces, sobre una base vacia o sobre una base
  de produccion con datos, y siempre la deja al dia. NO hace DROP de nada:
    1) Crea cada tabla solo si todavia no existe.
    2) Aplica los cambios incrementales (cada uno protegido, solo si falta).
    3) Carga los datos iniciales SOLO si la base esta vacia (base nueva).
    4) Muestra un conteo de filas por tabla para verificar.

  Como usarlo:
    * SSMS: activar "Modo SQLCMD" (menu Consulta) y ejecutar el script completo.
    * sqlcmd (apuntando a la base local, auth Windows):
        sqlcmd -S localhost -E -v BaseNombre="TandGSystem" -i tandg_unificado.sql -b
      Para una base de PRUEBA separada:
        sqlcmd -S localhost -E -v BaseNombre="TandGSystemTest" -i tandg_unificado.sql -b
    * NO usar IF DB_ID(...) con CREATE DATABASE en Azure SQL Database (no lo permite). En ese caso
      crear la base desde el portal y ejecutar solo desde la linea USE hacia abajo.
    * Para BORRAR todo y recrear desde cero (solo desarrollo/pruebas) ver el bloque comentado
      "0) RESET OPCIONAL" mas abajo.

  COMO ACTUALIZARLO DE ACA EN ADELANTE (regla simple):
    - Tabla NUEVA          -> agregar su  IF OBJECT_ID(...) IS NULL BEGIN CREATE TABLE ... END
                              en la seccion 1 (respetando el orden por dependencias).
    - Cambio sobre tabla EXISTENTE (columna, FK, tipo, indice, etc.)
                           -> agregar un bloque protegido en la seccion 2 (con su ticket), y
                              TAMBIEN reflejarlo en el CREATE TABLE de la seccion 1, para que una
                              base nueva nazca ya con el cambio.
    - No editar nunca un bloque ya aplicado en produccion: agregar uno nuevo debajo.

  Historial de cambios incluidos:
    * Base:   migracion de SQLite (mvp.db) a SQL Server, 12 tablas originales.
    * KAN-81: Presupuestos (PrecioProveedor, Presupuesto, DetallePresupuesto).
    * KAN-84: Ventas.estadoPago -> estadoCobro; Compras.idPresupuesto / fechaRecepcion / estadoPago;
              FK_Compras_Presupuesto; DetalleCompras.cantidad INT -> DECIMAL(18,4).
    * IA:     EvaluacionProveedor (una evaluacion por compra: fecha prometida, calidad 1..5).

  ----------------------------------------------------------------------------------------------------
  Decisiones de mapeo (SQLite -> SQL Server), heredadas de la migracion original:
    * INTEGER PRIMARY KEY AUTOINCREMENT  ->  INT IDENTITY(1,1) PRIMARY KEY
    * TEXT  ->  NVARCHAR(...)   (acentos y enye preservados; prefijo N en los literales)
    * REAL  ->  DECIMAL(18,4)   (se evita el error de redondeo del tipo float)
    * activo / Activo  ->  BIT NOT NULL DEFAULT 1
    * estado, estadoPedido, estadoCobro  ->  TINYINT (NO BIT: van de 0 a 4, ver Modelos/Estado*.cs)
    * DATE / TEXT con fecha -> DATE ; fecha y hora -> DATETIME2(0)
    * Los nombres de tablas y columnas se conservan EXACTAMENTE como en SQLite, porque el codigo C#
      (carpeta Datos) los referencia con esos nombres en el SQL embebido.

  Correcciones aplicadas en la migracion original (el esquema SQLite tenia errores):
    1) Insumos.descripcion estaba declarado INTEGER pero contiene texto ("Kg") -> NVARCHAR(500).
    2) Ventas.fecha: 2 filas estaban en dd-MM-yyyy; se normalizaron a ISO (yyyy-MM-dd), que T-SQL
       interpreta siempre bien sin depender del DATEFORMAT del servidor.
    3) Se agregaron las FOREIGN KEY que SQLite declaraba pero nunca aplicaba (PRAGMA foreign_keys OFF).
    4) DetalleTanda.idEmpleado queda SIN foreign key: no existe la tabla Empleados.
    5) TandaProduccion: fecha y hora unidas en una sola columna DATETIME2 (una columna TIME vuelve
       como TimeSpan en .NET y hace fallar GetDateTime()/GetString()).
    6) Transportes.fecha paso de DATE a DATETIME2 (el codigo ya guardaba fecha y hora).
  ******************************************************************************************************/

SET NOCOUNT ON;
SET XACT_ABORT ON;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- Crear la base si no existe (omitir este bloque si la base ya existe).
-- $(BaseNombre) permite apuntar a una base de prueba; sqlcmd lo reemplaza por el valor de -v.
IF DB_ID(N'TandGSystem') IS NULL

BEGIN

    EXEC('CREATE DATABASE [TandGSystem]');

END

GO



USE [TandGSystem];

GO



SET DATEFORMAT dmy;  -- red de seguridad contra literales ambiguos (los del script son ISO)
GO

--------------------------------------------------------------------------------
-- 0) RESET OPCIONAL  (DESTRUCTIVO - borra TODAS las tablas y sus datos)
--    Solo para desarrollo / base de prueba. Descomentar, ejecutar, y volver a comentar.
--    Despues de esto, el resto del script recrea todo y recarga los datos iniciales.
--------------------------------------------------------------------------------
/*
IF OBJECT_ID(N'dbo.EvaluacionProveedor', N'U') IS NOT NULL DROP TABLE dbo.EvaluacionProveedor;
IF OBJECT_ID(N'dbo.DetalleCompras', N'U') IS NOT NULL DROP TABLE dbo.DetalleCompras;
IF OBJECT_ID(N'dbo.Compras', N'U') IS NOT NULL DROP TABLE dbo.Compras;
IF OBJECT_ID(N'dbo.DetallePresupuesto', N'U') IS NOT NULL DROP TABLE dbo.DetallePresupuesto;
IF OBJECT_ID(N'dbo.Presupuesto', N'U')        IS NOT NULL DROP TABLE dbo.Presupuesto;
IF OBJECT_ID(N'dbo.PrecioProveedor', N'U')    IS NOT NULL DROP TABLE dbo.PrecioProveedor;
IF OBJECT_ID(N'dbo.DetalleSolicitudCotizacion', N'U') IS NOT NULL DROP TABLE dbo.DetalleSolicitudCotizacion;
IF OBJECT_ID(N'dbo.SolicitudCotizacion', N'U') IS NOT NULL DROP TABLE dbo.SolicitudCotizacion;
IF OBJECT_ID(N'dbo.Proveedores', N'U') IS NOT NULL DROP TABLE dbo.Proveedores;
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
*/

--------------------------------------------------------------------------------
-- 1) ESQUEMA  (cada tabla se crea solo si todavia no existe)
--------------------------------------------------------------------------------

-- ---------- Tablas sin dependencias ----------

IF OBJECT_ID(N'dbo.Clientes', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Clientes (
        [id]        INT IDENTITY(1,1) NOT NULL,
        [nombre]    NVARCHAR(100)  NOT NULL,
        [empresa]   NVARCHAR(150)  NOT NULL,
        [direccion] NVARCHAR(250)  NOT NULL,
        [activo]    BIT            NOT NULL DEFAULT 1,
        [telefono]  NVARCHAR(50)   NULL,
        CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([id] ASC)
    );
END
GO

IF OBJECT_ID(N'dbo.MetodosPago', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.MetodosPago (
        [IdMetodoPago] INT IDENTITY(1,1) NOT NULL,
        [Descripcion]  NVARCHAR(100) NOT NULL,
        [Activo]       BIT           NOT NULL DEFAULT 1,
        CONSTRAINT [PK_MetodosPago] PRIMARY KEY CLUSTERED ([IdMetodoPago] ASC)
    );
END
GO

IF OBJECT_ID(N'dbo.Productos', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Productos (
        [IdProducto]     INT IDENTITY(1,1) NOT NULL,
        [Nombre]         NVARCHAR(100)  NOT NULL,
        [Descripcion]    NVARCHAR(500)  NOT NULL,
        [Precio]         DECIMAL(18,4)  NOT NULL,
        [Activo]         BIT            NOT NULL DEFAULT 1,
        [vidaUtilDias]   INT            NULL,
        CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED ([IdProducto] ASC)
    );
END
GO

-- NOTA: en SQLite la columna [descripcion] estaba declarada INTEGER (error de esquema).
--       Contiene texto, asi que va como NVARCHAR.
IF OBJECT_ID(N'dbo.Insumos', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Insumos (
        [id]            INT IDENTITY(1,1) NOT NULL,
        [nombre]        NVARCHAR(100) NULL,
        [descripcion]   NVARCHAR(500) NULL,   -- <-- corregido: era INTEGER en mvp.db
        [precio]        DECIMAL(18,4) NULL,
        [activo]        BIT           NULL,
        [unidadMedida]  NVARCHAR(20)  NULL,
        CONSTRAINT [PK_Insumos] PRIMARY KEY CLUSTERED ([id] ASC)
    );
END
GO

IF OBJECT_ID(N'dbo.Proveedores', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Proveedores (
        [IdProveedor] INT IDENTITY(1,1) NOT NULL,
        [Nombre]      NVARCHAR(100) NOT NULL,
        [Direccion]   NVARCHAR(250) NULL,
        [Telefono]    NVARCHAR(50)  NULL,
        [Email]       NVARCHAR(150) NULL,
        [activo]      BIT           NOT NULL DEFAULT 1,
        CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED ([IdProveedor] ASC)
    );
END
GO

-- ---------- Tablas con dependencias ----------

IF OBJECT_ID(N'dbo.RecetaProducto', N'U') IS NULL
BEGIN
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
END
GO

IF OBJECT_ID(N'dbo.StockProducto', N'U') IS NULL
BEGIN
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
END
GO

IF OBJECT_ID(N'dbo.StockInsumo', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.StockInsumo (
        [id]        INT IDENTITY(1,1) NOT NULL,
        [insumo_id] INT           NOT NULL,
        -- DECIMAL porque los insumos se miden en Kg/Gr y admiten fracciones
        [cantidad]  DECIMAL(18,4) NULL,
        CONSTRAINT [PK_StockInsumo] PRIMARY KEY CLUSTERED ([id] ASC),
        CONSTRAINT [FK_StockInsumo_Insumo] FOREIGN KEY ([insumo_id])
            REFERENCES dbo.Insumos ([id]) ON UPDATE CASCADE ON DELETE CASCADE
    );
END
GO

IF OBJECT_ID(N'dbo.TandaProduccion', N'U') IS NULL
BEGIN
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
END
GO

IF OBJECT_ID(N'dbo.DetalleTanda', N'U') IS NULL
BEGIN
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
END
GO

IF OBJECT_ID(N'dbo.Ventas', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Ventas (
        [idVenta]       INT IDENTITY(1,1) NOT NULL,
        [idCliente]     INT           NOT NULL,
        [idMetodoPago]  INT           NOT NULL,
        [fecha]         DATE          NOT NULL,
        [estadoPedido]  TINYINT       NOT NULL DEFAULT 1,   -- 0..4 (Modelos/EstadoPedido.cs)
        [estadoCobro]    TINYINT       NOT NULL DEFAULT 1,   -- 0..2 (Modelos/EstadoCobro.cs)
        [totalVenta]    DECIMAL(18,4) NULL,
        [montoRecibido] DECIMAL(18,4) NULL,
        CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED ([idVenta] ASC),
        CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY ([idCliente])
            REFERENCES dbo.Clientes ([id]) ON UPDATE CASCADE ON DELETE NO ACTION,
        CONSTRAINT [FK_Venta_MetodoPago] FOREIGN KEY ([idMetodoPago])
            REFERENCES dbo.MetodosPago ([IdMetodoPago]) ON UPDATE CASCADE ON DELETE NO ACTION
    );
END
GO

IF OBJECT_ID(N'dbo.DetalleVentas', N'U') IS NULL
BEGIN
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
END
GO

IF OBJECT_ID(N'dbo.Transportes', N'U') IS NULL
BEGIN
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
END
GO

IF OBJECT_ID(N'dbo.Compras', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Compras (
        [idCompra]       INT IDENTITY(1,1) NOT NULL,
        [idProveedor]    INT           NOT NULL,
        [idPresupuesto]  INT           NULL,     -- origen (pedido); NULL = carga manual (KAN-84)
        [fecha]          DATE          NOT NULL,
        [fechaRecepcion] DATE          NULL,     -- se setea al pasar a RECIBIDA (KAN-84)
        [estado]         TINYINT       NOT NULL DEFAULT 0,   -- 0..4 (Modelos/EstadoCompra.cs)
        [estadoPago]     TINYINT       NOT NULL DEFAULT 1,   -- 1..2 (Modelos/EstadoPago.cs)
        [totalCompra]    DECIMAL(18,4) NULL,
        [montoPagado]    DECIMAL(18,4) NULL,
        CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED ([idCompra] ASC),
        CONSTRAINT [FK_Compras_Proveedor] FOREIGN KEY ([idProveedor])
            REFERENCES dbo.Proveedores ([IdProveedor]) ON UPDATE CASCADE ON DELETE NO ACTION
    );
END
GO

IF OBJECT_ID(N'dbo.DetalleCompras', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.DetalleCompras (
        [idDetalleCompra]    INT IDENTITY(1,1) NOT NULL,
        [idCompra]           INT           NOT NULL,
        [idInsumo]           INT           NOT NULL,
        [cantidad]           DECIMAL(18,4) NOT NULL,   -- antes INT (KAN-84: insumos con fracciones)
        [subTotal]           DECIMAL(18,4) NULL,
        [motivoModificacion] NVARCHAR(200) NULL,
        CONSTRAINT [PK_DetalleCompras] PRIMARY KEY CLUSTERED ([idDetalleCompra] ASC),
        CONSTRAINT [FK_DetalleCompras_Compra] FOREIGN KEY ([idCompra])
            REFERENCES dbo.Compras ([idCompra]) ON UPDATE CASCADE ON DELETE CASCADE,
        CONSTRAINT [FK_DetalleCompras_Insumo] FOREIGN KEY ([idInsumo])
            REFERENCES dbo.Insumos ([id]) ON UPDATE CASCADE ON DELETE NO ACTION
    );
END
GO

IF OBJECT_ID(N'dbo.SolicitudCotizacion', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SolicitudCotizacion (
        [idSolicitud] INT IDENTITY(1,1) NOT NULL,
        [idProveedor] INT           NOT NULL,
        [fecha]       DATE          NOT NULL,
        [estado]      TINYINT       NOT NULL DEFAULT 0,   -- 0..3 (Modelos/EstadoSolicitudCotizacion.cs)
        CONSTRAINT [PK_SolicitudCotizacion] PRIMARY KEY CLUSTERED ([idSolicitud] ASC),
        CONSTRAINT [FK_SolicitudCotizacion_Proveedor] FOREIGN KEY ([idProveedor])
            REFERENCES dbo.Proveedores ([IdProveedor]) ON UPDATE CASCADE ON DELETE NO ACTION
    );
END
GO

IF OBJECT_ID(N'dbo.DetalleSolicitudCotizacion', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.DetalleSolicitudCotizacion (
        [idDetalleSolicitud] INT IDENTITY(1,1) NOT NULL,
        [idSolicitud]        INT           NOT NULL,
        [idInsumo]           INT           NOT NULL,
        [cantidad]           DECIMAL(18,4) NOT NULL,
        CONSTRAINT [PK_DetalleSolicitudCotizacion] PRIMARY KEY CLUSTERED ([idDetalleSolicitud] ASC),
        CONSTRAINT [FK_DetalleSolicitudCotizacion_Solicitud] FOREIGN KEY ([idSolicitud])
            REFERENCES dbo.SolicitudCotizacion ([idSolicitud]) ON UPDATE CASCADE ON DELETE CASCADE,
        CONSTRAINT [FK_DetalleSolicitudCotizacion_Insumo] FOREIGN KEY ([idInsumo])
            REFERENCES dbo.Insumos ([id]) ON UPDATE CASCADE ON DELETE NO ACTION
    );
END
GO

-- ---------- Presupuestos (KAN-81) ----------

IF OBJECT_ID(N'dbo.PrecioProveedor', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PrecioProveedor (
        [idPrecioProveedor]  INT IDENTITY(1,1) NOT NULL,
        [idProveedor]        INT           NOT NULL,
        [idInsumo]           INT           NOT NULL,
        [precio]             DECIMAL(18,4) NOT NULL,
        [fechaActualizacion] DATE          NOT NULL,
        CONSTRAINT [PK_PrecioProveedor] PRIMARY KEY CLUSTERED ([idPrecioProveedor] ASC),
        CONSTRAINT [FK_PrecioProveedor_Proveedor] FOREIGN KEY ([idProveedor])
            REFERENCES dbo.Proveedores ([IdProveedor]) ON UPDATE CASCADE ON DELETE NO ACTION,
        CONSTRAINT [FK_PrecioProveedor_Insumo] FOREIGN KEY ([idInsumo])
            REFERENCES dbo.Insumos ([id]) ON UPDATE CASCADE ON DELETE NO ACTION
    );
END
GO

IF OBJECT_ID(N'dbo.Presupuesto', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Presupuesto (
        [idPresupuesto] INT IDENTITY(1,1) NOT NULL,
        [idSolicitud]   INT           NOT NULL,
        [fecha]         DATE          NOT NULL,
        [total]         DECIMAL(18,4) NOT NULL DEFAULT 0,
        [activo]        BIT           NOT NULL DEFAULT 1,
        CONSTRAINT [PK_Presupuesto] PRIMARY KEY CLUSTERED ([idPresupuesto] ASC),
        CONSTRAINT [FK_Presupuesto_Solicitud] FOREIGN KEY ([idSolicitud])
            REFERENCES dbo.SolicitudCotizacion ([idSolicitud]) ON UPDATE CASCADE ON DELETE NO ACTION
    );
END
GO

IF OBJECT_ID(N'dbo.DetallePresupuesto', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.DetallePresupuesto (
        [idDetallePresupuesto] INT IDENTITY(1,1) NOT NULL,
        [idPresupuesto]        INT           NOT NULL,
        [idInsumo]             INT           NOT NULL,
        [cantidad]             DECIMAL(18,4) NOT NULL,
        [precioUnitario]       DECIMAL(18,4) NOT NULL,
        [subtotal]             DECIMAL(18,4) NOT NULL,
        CONSTRAINT [PK_DetallePresupuesto] PRIMARY KEY CLUSTERED ([idDetallePresupuesto] ASC),
        CONSTRAINT [FK_DetallePresupuesto_Presupuesto] FOREIGN KEY ([idPresupuesto])
            REFERENCES dbo.Presupuesto ([idPresupuesto]) ON UPDATE CASCADE ON DELETE CASCADE,
        CONSTRAINT [FK_DetallePresupuesto_Insumo] FOREIGN KEY ([idInsumo])
            REFERENCES dbo.Insumos ([id]) ON UPDATE CASCADE ON DELETE NO ACTION
    );
END
GO


-- ---------- Evaluacion de proveedores (modulo de IA) ----------
-- Una evaluacion por compra (UNIQUE sobre IdCompra). Calidad de 1 a 5, opcional.
-- (Unifica evaluacion_proveedor.sql y TablaEvaluacionProveedor.sql: eran la misma tabla.)

IF OBJECT_ID(N'dbo.EvaluacionProveedor', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.EvaluacionProveedor (
        [IdEvaluacion]   INT IDENTITY(1,1) NOT NULL,
        [IdCompra]       INT           NOT NULL,
        [FechaPrometida] DATE          NOT NULL,
        [Calidad]        INT           NULL,
        [Observaciones]  NVARCHAR(500) NULL,
        CONSTRAINT [PK_EvaluacionProveedor] PRIMARY KEY CLUSTERED ([IdEvaluacion] ASC),
        CONSTRAINT [UQ_EvaluacionProveedor_Compra] UNIQUE NONCLUSTERED ([IdCompra] ASC),
        CONSTRAINT [FK_EvaluacionProveedor_Compra] FOREIGN KEY ([IdCompra])
            REFERENCES dbo.Compras ([idCompra]),
        CONSTRAINT [CK_EvaluacionProveedor_Calidad] CHECK ([Calidad] BETWEEN 1 AND 5)
    );
END
GO

--------------------------------------------------------------------------------
-- 2) CAMBIOS INCREMENTALES sobre bases EXISTENTES  (KAN-84)
--    En una base nueva todo esto ya viene aplicado desde la seccion 1 y no hace nada.
--    En una base vieja (con datos) agrega/renombra solo lo que falta.
--------------------------------------------------------------------------------

-- 2.1) VENTAS: renombrar [estadoPago] -> [estadoCobro]
--      Solo si todavia NO existe [estadoCobro] y SI existe la vieja [estadoPago].
IF COL_LENGTH(N'dbo.Ventas', N'estadoCobro') IS NULL
   AND COL_LENGTH(N'dbo.Ventas', N'estadoPago') IS NOT NULL
BEGIN
    EXEC sp_rename N'dbo.Ventas.estadoPago', N'estadoCobro', N'COLUMN';
    PRINT N'Ventas: columna estadoPago renombrada a estadoCobro.';
END
ELSE
    PRINT N'Ventas: no hacia falta renombrar (ya existe estadoCobro o no existe estadoPago).';
GO

-- 2.2) COMPRAS: agregar columnas faltantes (cada una solo si no existe)

-- 2.2a) idPresupuesto: origen del pedido de compra (NULL = carga manual).
IF COL_LENGTH(N'dbo.Compras', N'idPresupuesto') IS NULL
BEGIN
    ALTER TABLE dbo.Compras ADD [idPresupuesto] INT NULL;
    PRINT N'Compras: columna idPresupuesto agregada.';
END
ELSE
    PRINT N'Compras: idPresupuesto ya existia.';
GO

-- 2.2b) fechaRecepcion: se setea al pasar la compra a RECIBIDA.
IF COL_LENGTH(N'dbo.Compras', N'fechaRecepcion') IS NULL
BEGIN
    ALTER TABLE dbo.Compras ADD [fechaRecepcion] DATE NULL;
    PRINT N'Compras: columna fechaRecepcion agregada.';
END
ELSE
    PRINT N'Compras: fechaRecepcion ya existia.';
GO

-- 2.2c) estadoPago: 1 = Pendiente, 2 = Pagado (Modelos/EstadoPago.cs).
--       Al agregarla NOT NULL DEFAULT 1, las filas existentes quedan en Pendiente.
IF COL_LENGTH(N'dbo.Compras', N'estadoPago') IS NULL
BEGIN
    ALTER TABLE dbo.Compras
        ADD [estadoPago] TINYINT NOT NULL
            CONSTRAINT [DF_Compras_estadoPago] DEFAULT 1;
    PRINT N'Compras: columna estadoPago agregada (default 1).';
END
ELSE
    PRINT N'Compras: estadoPago ya existia.';
GO

-- 2.3) COMPRAS: FK FK_Compras_Presupuesto -> dbo.Presupuesto ([idPresupuesto])
--      Va aca (y no dentro del CREATE de Compras) porque Presupuesto se crea despues de Compras.
--      ON UPDATE NO ACTION (y no CASCADE): Compras ya cascadea desde Proveedores directo y, por
--      Presupuesto -> SolicitudCotizacion -> Proveedores, un CASCADE seria un segundo camino de
--      cascada (SQL Server lo rechaza con el error 1785).
IF NOT EXISTS (
    SELECT 1 FROM sys.foreign_keys WHERE name = N'FK_Compras_Presupuesto'
)
BEGIN
    ALTER TABLE dbo.Compras ADD CONSTRAINT [FK_Compras_Presupuesto]
        FOREIGN KEY ([idPresupuesto]) REFERENCES dbo.Presupuesto ([idPresupuesto])
        ON UPDATE NO ACTION ON DELETE NO ACTION;
    PRINT N'Compras: FK_Compras_Presupuesto agregada.';
END
ELSE
    PRINT N'Compras: FK_Compras_Presupuesto ya existia.';
GO

-- 2.4) DETALLECOMPRAS: [cantidad] de INT a DECIMAL(18,4) NOT NULL
--      Solo si el tipo actual no es decimal.
--      OJO: la base de produccion tiene el check CK_DetalleCompras_cantidad ([cantidad]>(0)),
--      que impide el ALTER COLUMN. Se quita y se vuelve a crear IDENTICO (misma condicion).
IF EXISTS (
    SELECT 1
    FROM sys.columns c
    JOIN sys.types t ON c.user_type_id = t.user_type_id
    WHERE c.object_id = OBJECT_ID(N'dbo.DetalleCompras')
      AND c.name = N'cantidad'
      AND t.name <> N'decimal'
)
BEGIN
    IF EXISTS (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_DetalleCompras_cantidad'
          AND parent_object_id = OBJECT_ID(N'dbo.DetalleCompras')
    )
        ALTER TABLE dbo.DetalleCompras DROP CONSTRAINT [CK_DetalleCompras_cantidad];

    ALTER TABLE dbo.DetalleCompras ALTER COLUMN [cantidad] DECIMAL(18,4) NOT NULL;

    IF NOT EXISTS (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_DetalleCompras_cantidad'
          AND parent_object_id = OBJECT_ID(N'dbo.DetalleCompras')
    )
        ALTER TABLE dbo.DetalleCompras
            ADD CONSTRAINT [CK_DetalleCompras_cantidad] CHECK ([cantidad] > 0);

    PRINT N'DetalleCompras: cantidad convertida a DECIMAL(18,4).';
END
ELSE
    PRINT N'DetalleCompras: cantidad ya era decimal.';
GO

-- 2.x) (agregar aca los proximos cambios incrementales, uno por bloque protegido, con su ticket)

--------------------------------------------------------------------------------
-- 3) DATOS INICIALES  (generado desde mvp.db, orden respetando las dependencias)
--    SOLO se cargan si la base esta vacia (base nueva). Si ya hay datos, no se toca nada.
--    Los IDs originales se preservan (IDENTITY_INSERT) y al final se re-secuencian los IDENTITY
--    con los valores de sqlite_sequence; sin eso un INSERT nuevo arrancaria en 1 y chocaria.
--------------------------------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM dbo.Clientes)
   AND NOT EXISTS (SELECT 1 FROM dbo.Productos)
   AND NOT EXISTS (SELECT 1 FROM dbo.Insumos)
   AND NOT EXISTS (SELECT 1 FROM dbo.Ventas)
BEGIN
    PRINT N'Base vacia: cargando datos iniciales...';

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
    INSERT INTO [Ventas] (idVenta, idCliente, idMetodoPago, fecha, estadoPedido, estadoCobro, totalVenta, montoRecibido) VALUES
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
END
ELSE
    PRINT N'La base ya tiene datos: se omiten los datos iniciales.';
GO

--------------------------------------------------------------------------------
-- 4) VERIFICACION
--------------------------------------------------------------------------------
-- PRINT no admite subconsultas, por eso la verificacion va como SELECT.
SELECT * FROM (
    SELECT 'Clientes'        AS Tabla, COUNT_BIG(*) AS Filas FROM dbo.Clientes        UNION ALL
    SELECT 'MetodosPago',    COUNT_BIG(*) FROM dbo.MetodosPago                      UNION ALL
    SELECT 'Productos',       COUNT_BIG(*) FROM dbo.Productos                         UNION ALL
    SELECT 'Insumos',         COUNT_BIG(*) FROM dbo.Insumos                           UNION ALL
    SELECT 'Proveedores',     COUNT_BIG(*) FROM dbo.Proveedores                       UNION ALL
    SELECT 'RecetaProducto',  COUNT_BIG(*) FROM dbo.RecetaProducto                    UNION ALL
    SELECT 'StockProducto',   COUNT_BIG(*) FROM dbo.StockProducto                     UNION ALL
    SELECT 'StockInsumo',     COUNT_BIG(*) FROM dbo.StockInsumo                       UNION ALL
    SELECT 'TandaProduccion', COUNT_BIG(*) FROM dbo.TandaProduccion                   UNION ALL
    SELECT 'DetalleTanda',    COUNT_BIG(*) FROM dbo.DetalleTanda                      UNION ALL
    SELECT 'Ventas',          COUNT_BIG(*) FROM dbo.Ventas                            UNION ALL
    SELECT 'DetalleVentas',   COUNT_BIG(*) FROM dbo.DetalleVentas                     UNION ALL
    SELECT 'Transportes',     COUNT_BIG(*) FROM dbo.Transportes                       UNION ALL
    SELECT 'Compras',         COUNT_BIG(*) FROM dbo.Compras                           UNION ALL
    SELECT 'DetalleCompras',  COUNT_BIG(*) FROM dbo.DetalleCompras                    UNION ALL
    SELECT 'SolicitudCotizacion',        COUNT_BIG(*) FROM dbo.SolicitudCotizacion        UNION ALL
    SELECT 'DetalleSolicitudCotizacion', COUNT_BIG(*) FROM dbo.DetalleSolicitudCotizacion UNION ALL
    SELECT 'Presupuesto',                COUNT_BIG(*) FROM dbo.Presupuesto                UNION ALL
    SELECT 'DetallePresupuesto',         COUNT_BIG(*) FROM dbo.DetallePresupuesto         UNION ALL
    SELECT 'PrecioProveedor',            COUNT_BIG(*) FROM dbo.PrecioProveedor            UNION ALL
    SELECT 'EvaluacionProveedor',        COUNT_BIG(*) FROM dbo.EvaluacionProveedor
) AS Conteo ORDER BY Tabla;
GO

--------------------------------------------------------------------------------
-- 5) INDICES RECOMENDADOS (opcionales; SQLite no los tenia, pero con varios
--    usuarios concurrentes conviene. Descomentar si la base crece.)
--------------------------------------------------------------------------------
-- CREATE NONCLUSTERED INDEX IX_Ventas_idCliente      ON dbo.Ventas (idCliente);
-- CREATE NONCLUSTERED INDEX IX_Ventas_fecha          ON dbo.Ventas (fecha);
-- CREATE NONCLUSTERED INDEX IX_DetalleVentas_idVenta ON dbo.DetalleVentas (idVenta);
-- CREATE NONCLUSTERED INDEX IX_TandaProd_idProducto  ON dbo.TandaProduccion (idProducto);
-- CREATE NONCLUSTERED INDEX IX_StockProducto_prod    ON dbo.StockProducto (producto_id);
-- CREATE NONCLUSTERED INDEX IX_StockInsumo_ins       ON dbo.StockInsumo (insumo_id);
GO
