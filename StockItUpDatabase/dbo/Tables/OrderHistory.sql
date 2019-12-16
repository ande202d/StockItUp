CREATE TABLE [dbo].[OrderHistory] (
    [Id]          INT      NOT NULL,
    [OrderedDate] DATETIME NOT NULL,
    [StoreId] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_OrderHistory_Store] FOREIGN KEY ([StoreId]) REFERENCES [Store]([Id])
);

