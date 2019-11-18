CREATE TABLE [dbo].[StoreProduct] (
    [Store]   INT NOT NULL,
    [Product] INT NOT NULL,
    [Amount]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Store] ASC, [Product] ASC),
    CONSTRAINT [FK_StoreProduct_Procut] FOREIGN KEY ([Product]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_StoreProduct_ToTable] FOREIGN KEY ([Store]) REFERENCES [dbo].[Store] ([Id])
);

