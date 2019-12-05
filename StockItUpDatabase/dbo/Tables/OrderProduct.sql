CREATE TABLE [dbo].[OrderProduct] (
	[Id] INT IDENTITY (1, 1) NOT NULL,
    [Order]         INT NOT NULL,
    [Product]       INT NOT NULL,
    [OrderedAmount] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY ([Order]) REFERENCES [dbo].[Order] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY ([Product]) REFERENCES [dbo].[Product] ([Id]) ON DELETE CASCADE
);

