CREATE TABLE [dbo].[InventoryCount] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [Location]    INT      NOT NULL,
    [DateCounted] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_InventoryCount_Location] FOREIGN KEY ([Location]) REFERENCES [dbo].[Location] ([Id]) ON DELETE CASCADE
);

