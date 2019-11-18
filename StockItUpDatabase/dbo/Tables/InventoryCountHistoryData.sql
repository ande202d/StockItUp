CREATE TABLE [dbo].[InventoryCountHistoryData] (
    [Id]      INT          NOT NULL,
    [Product] VARCHAR (50) NOT NULL,
    [Amount]  INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC, [Product] ASC),
    CONSTRAINT [FK_InventoryCountHistoryData_ToTable] FOREIGN KEY ([Id]) REFERENCES [dbo].[InventoryCountHistory] ([Id])
);

