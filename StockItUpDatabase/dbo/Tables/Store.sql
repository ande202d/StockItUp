CREATE TABLE [dbo].[Store] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (50) NOT NULL,
    [Address] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

