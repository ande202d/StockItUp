CREATE TABLE [dbo].[StoreProduct] (
	[Id] INT IDENTITY (1, 1) NOT NULL,
    [Store]   INT NOT NULL,
    [Product] INT NOT NULL,
    [Amount]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StoreProduct_Procut] FOREIGN KEY ([Product]) REFERENCES [dbo].[Product] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_StoreProduct_ToTable] FOREIGN KEY ([Store]) REFERENCES [dbo].[Store] ([Id]) ON DELETE CASCADE
);

