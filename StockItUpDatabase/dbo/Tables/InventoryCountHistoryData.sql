CREATE TABLE [dbo].[InventoryCountHistoryData] (
    [Id]      INT          NOT NULL,
    [Product] VARCHAR (50) NOT NULL,
    [Amount]  INT          NOT NULL,
    [InventoryCountHistory] INT NOT NULL, 
    CONSTRAINT [FK_InventoryCountHistoryData_ToTable] FOREIGN KEY ([InventoryCountHistory]) REFERENCES [dbo].[InventoryCountHistory] ([Id]) ON DELETE CASCADE, 
    CONSTRAINT [PK_InventoryCountHistoryData] PRIMARY KEY ([Id])
);

