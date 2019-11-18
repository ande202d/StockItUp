CREATE TABLE [dbo].[OrderHistoryData] (
    [Id]                INT          NOT NULL,
    [Product]           VARCHAR (50) NOT NULL,
    [MissingAmount]     INT          NOT NULL,
    [AmountPerBox]      INT          NOT NULL,
    [RecommendedAmount] INT          NOT NULL,
    [AmountOrdered]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC, [Product] ASC),
    CONSTRAINT [FK_OrderHistoryData_ToTable] FOREIGN KEY ([Id]) REFERENCES [dbo].[OrderHistory] ([Id])
);

