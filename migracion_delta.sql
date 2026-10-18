/******************************************************************************************************
  T&GSystem  -  Migracion INCREMENTAL sobre una base EXISTENTE CON DATOS (KAN-84)
  ----------------------------------------------------------------------------------------------------
  ATENCION:
    Este script NO reemplaza a "migracion_sqlserver.sql". Ese otro hace DROP/CREATE de TODAS las
    tablas y BORRA los datos: sirve para crear la base desde cero (o la de prueba TandGSystemTest).
    Este script, en cambio, es un DELTA idempotente pensado para bases de produccion que NO se
    pueden perder: solo agrega/renombra lo que falta y se puede correr las veces que haga falta.

  Que aplica:
    1) Ventas : renombra [estadoPago] -> [estadoCobro] (KAN-84: el cobro es de ventas).
    2) Compras: agrega [idPresupuesto] INT NULL, [fechaRecepcion] DATE NULL y
                [estadoPago] TINYINT NOT NULL DEFAULT 1 (constraint DF_Compras_estadoPago).
    3) Compras: agrega la FK FK_Compras_Presupuesto -> dbo.Presupuesto ([idPresupuesto]).
    4) DetalleCompras: pasa [cantidad] de INT a DECIMAL(18,4) NOT NULL.

  Como usarlo (apuntando a la base LOCAL TandGSystem, auth Windows):
      sqlcmd -S localhost -E -d TandGSystem -i migracion_delta.sql -b

  Cada cambio esta protegido para poder correr el script N veces sin error (con -b aborta apenas
  falla; si vuelve con exit 0, la base ya estaba al dia).

  Importante: ejecutar SOLO contra TandGSystem. NO correr contra TandGSystemTest ni contra la
  base de prueba si no se quiere modificar.
  ******************************************************************************************************/

SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

--------------------------------------------------------------------------------
-- 1) VENTAS: renombrar [estadoPago] -> [estadoCobro]
--    Solo si todavia NO existe [estadoCobro] y SI existe la vieja [estadoPago].
--------------------------------------------------------------------------------
IF COL_LENGTH(N'dbo.Ventas', N'estadoCobro') IS NULL
   AND COL_LENGTH(N'dbo.Ventas', N'estadoPago') IS NOT NULL
BEGIN
    EXEC sp_rename N'dbo.Ventas.estadoPago', N'estadoCobro', N'COLUMN';
    PRINT N'Ventas: columna estadoPago renombrada a estadoCobro.';
END
ELSE
    PRINT N'Ventas: no hacia falta renombrar (ya existe estadoCobro o no existe estadoPago).';
GO

--------------------------------------------------------------------------------
-- 2) COMPRAS: agregar columnas faltantes (cada una solo si no existe)
--------------------------------------------------------------------------------

-- 2a) idPresupuesto: origen del pedido de compra (NULL = carga manual).
IF COL_LENGTH(N'dbo.Compras', N'idPresupuesto') IS NULL
BEGIN
    ALTER TABLE dbo.Compras ADD [idPresupuesto] INT NULL;
    PRINT N'Compras: columna idPresupuesto agregada.';
END
ELSE
    PRINT N'Compras: idPresupuesto ya existia.';
GO

-- 2b) fechaRecepcion: se setea al pasar la compra a RECIBIDA.
IF COL_LENGTH(N'dbo.Compras', N'fechaRecepcion') IS NULL
BEGIN
    ALTER TABLE dbo.Compras ADD [fechaRecepcion] DATE NULL;
    PRINT N'Compras: columna fechaRecepcion agregada.';
END
ELSE
    PRINT N'Compras: fechaRecepcion ya existia.';
GO

-- 2c) estadoPago: 1 = Pendiente, 2 = Pagado (Modelos/EstadoPago.cs).
--     Al agregarla NOT NULL DEFAULT 1, las filas existentes quedan en Pendiente.
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

--------------------------------------------------------------------------------
-- 3) COMPRAS: FK FK_Compras_Presupuesto -> dbo.Presupuesto ([idPresupuesto])
--    ON UPDATE NO ACTION / ON DELETE NO ACTION (evita el segundo camino de cascada;
--    ver la nota en migracion_sqlserver.sql).
--------------------------------------------------------------------------------
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

--------------------------------------------------------------------------------
-- 4) DETALLECOMPRAS: [cantidad] de INT a DECIMAL(18,4) NOT NULL
--    Solo si el tipo actual no es decimal.
--    OJO: la base de produccion tiene el check CK_DetalleCompras_cantidad ([cantidad]>(0)),
--    que impide el ALTER COLUMN. Se quita y se vuelve a crear IDENTICO (misma condicion).
--------------------------------------------------------------------------------
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
