CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Username] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL, 
    [PhoneNumber] INT NOT NULL, 
    [GroupId] INT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_User_Group] FOREIGN KEY ([GroupId]) REFERENCES [PermissionGroup]([Id]) ON DELETE SET DEFAULT
)
