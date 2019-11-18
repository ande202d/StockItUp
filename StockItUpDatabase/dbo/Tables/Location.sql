CREATE TABLE [dbo].[Location] (
    [Id]    INT          IDENTITY (1, 1) NOT NULL,
    [Name]  VARCHAR (50) NOT NULL,
    [Store] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Location_ToTable] FOREIGN KEY ([Store]) REFERENCES [dbo].[Store] ([Id])
);

