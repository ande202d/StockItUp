CREATE TABLE [dbo].[OrderProduct] (
    [Order]         INT NOT NULL,
    [Product]       INT NOT NULL,
    [OrderedAmount] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Product] ASC, [Order] ASC),
    CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY ([Order]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY ([Product]) REFERENCES [dbo].[Product] ([Id])
);

