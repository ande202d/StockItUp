CREATE TABLE [dbo].[Order] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [OrderDate] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

