USE [TandGSystem]
GO

/****** Objeto: Table [dbo].[EvaluacionProveedor] Fecha de script: 24/10/2026 03:19:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EvaluacionProveedor](
	[IdEvaluacion] [int] IDENTITY(1,1) NOT NULL,
	[IdCompra] [int] NOT NULL,
	[FechaPrometida] [date] NOT NULL,
	[Calidad] [int] NULL,
	[Observaciones] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEvaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_EvaluacionProveedor_Compra] UNIQUE NONCLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EvaluacionProveedor]  WITH CHECK ADD  CONSTRAINT [FK_EvaluacionProveedor_Compra] FOREIGN KEY([IdCompra])
REFERENCES [dbo].[Compras] ([idCompra])
GO

ALTER TABLE [dbo].[EvaluacionProveedor] CHECK CONSTRAINT [FK_EvaluacionProveedor_Compra]
GO

ALTER TABLE [dbo].[EvaluacionProveedor]  WITH CHECK ADD  CONSTRAINT [CK_EvaluacionProveedor_Calidad] CHECK  (([Calidad]>=(1) AND [Calidad]<=(5)))
GO

ALTER TABLE [dbo].[EvaluacionProveedor] CHECK CONSTRAINT [CK_EvaluacionProveedor_Calidad]
GO


