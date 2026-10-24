USE TandGSystem;
GO

IF OBJECT_ID('dbo.EvaluacionProveedor', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.EvaluacionProveedor
    (
        IdEvaluacion INT IDENTITY(1,1) PRIMARY KEY,
        IdCompra INT NOT NULL,
        FechaPrometida DATE NOT NULL,
        Calidad INT NULL,
        Observaciones NVARCHAR(500) NULL,

        CONSTRAINT FK_EvaluacionProveedor_Compra
        FOREIGN KEY (IdCompra)
        REFERENCES dbo.Compras(idCompra),

        CONSTRAINT UQ_EvaluacionProveedor_Compra
        UNIQUE (IdCompra),

        CONSTRAINT CK_EvaluacionProveedor_Calidad
        CHECK (Calidad BETWEEN 1 AND 5)
    );
END;
GO