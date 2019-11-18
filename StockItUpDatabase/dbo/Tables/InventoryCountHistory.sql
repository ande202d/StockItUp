CREATE TABLE [dbo].[InventoryCountHistory] (
    [Id]        INT          NOT NULL,
    [Location]  VARCHAR (50) NOT NULL,
    [CountDate] DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

