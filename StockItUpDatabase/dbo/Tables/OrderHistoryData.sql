CREATE TABLE [dbo].[OrderHistoryData] (
	[Id] INT IDENTITY (1, 1) NOT NULL,
    [OrderHistory]                INT          NOT NULL,
    [Product]           VARCHAR (50) NOT NULL,
    [MissingAmount]     INT          NOT NULL,
    [AmountPerBox]      INT          NOT NULL,
    [RecommendedAmount] INT          NOT NULL,
    [AmountOrdered]     INT          NOT NULL,
    [Supplier] VARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [FK_OrderHistoryData_ToTable] FOREIGN KEY ([OrderHistory]) REFERENCES [dbo].[OrderHistory] ([Id])
);

