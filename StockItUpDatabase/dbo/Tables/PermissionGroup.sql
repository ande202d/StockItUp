CREATE TABLE [dbo].[PermissionGroup]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 

    [CanCreateProduct] BIT NOT NULL, 
    [CanDeleteProduct] BIT NOT NULL,
    [CanUpdateProduct] BIT NOT NULL,

    [CanCreateSupplier] BIT NOT NULL,
    [CanDeleteSupplier] BIT NOT NULL,
    [CanUpdateSupplier] BIT NOT NULL,
	
    [CanCreateLocation] BIT NOT NULL,
    [CanDeleteLocation] BIT NOT NULL,
    [CanUpdateLocation] BIT NOT NULL,

	[CanCreateInventoryCount] BIT NOT NULL,
    [CanDeleteInventoryCount] BIT NOT NULL,
    [CanViewInventoryCount] BIT NOT NULL,
	
	[CanCreateOrder] BIT NOT NULL,
    [CanDeleteOrder] BIT NOT NULL,
    [CanViewOrder] BIT NOT NULL,

    [CanChangeStoreProduct] BIT NOT NULL,

	[CanCreateUser] BIT NOT NULL,
    [CanDeleteUser] BIT NOT NULL,
    [CanUpdateUser] BIT NOT NULL,

	[CanCreatePermissionGroup] BIT NOT NULL,
    [CanDeletePermissionGroup] BIT NOT NULL,
    [CanUpdatePermissionGroup] BIT NOT NULL,
	
	[CanCreateStore] BIT NOT NULL,
    [CanDeleteStore] BIT NOT NULL,
    [CanUpdateStore] BIT NOT NULL
)
