CREATE TABLE [dbo].[Product] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50) NOT NULL,
    [AmountPerBox] INT          NOT NULL,
    [Supplier]     INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_ToTable] FOREIGN KEY ([Supplier]) REFERENCES [dbo].[Supplier] ([Id]) ON DELETE SET NULL
);

