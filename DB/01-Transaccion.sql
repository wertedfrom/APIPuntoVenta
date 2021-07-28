use PuntoDeVenta
GO

--if(object_id('dbo.Transacciones') is not null) drop table Transacciones;

create table Transacciones(
	[Id] UNIQUEIDENTIFIER not null,
	[ImporteCompra] DECIMAL(19,4),
	[ImportePago] DECIMAL(19,4),
	[Cambio] DECIMAL(19,4),
	[MensajeCambio] NVARCHAR(512),
	[CreatedAt] DATETIME2,

	CONSTRAINT PK_Transaccion PRIMARY KEY (Id)
);
GO 