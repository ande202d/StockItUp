CREATE TABLE [dbo].[InventoryCountProduct] (
    [InventoryCount] INT NOT NULL,
    [Product]        INT NOT NULL,
    [Amount]         INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Product] ASC, [InventoryCount] ASC),
    CONSTRAINT [FK_InventoryCountProduct_InventoryCount] FOREIGN KEY ([InventoryCount]) REFERENCES [dbo].[InventoryCount] ([Id]),
    CONSTRAINT [FK_InventoryCountProduct_Product] FOREIGN KEY ([Product]) REFERENCES [dbo].[Product] ([Id])
);

