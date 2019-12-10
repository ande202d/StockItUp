USE [StockItUpDB]
GO
delete from [dbo].[UserStore];
delete from [dbo].[User];
delete from [dbo].[PermissionGroup];
delete from [dbo].[OrderHistoryData];
delete from [dbo].[OrderHistory];
delete from [dbo].[OrderProduct];
delete from [dbo].[Order];
delete from [dbo].[InventoryCountHistoryData];
delete from [dbo].[InventoryCountHistory];
delete from [dbo].[InventoryCountProduct];
delete from [dbo].[InventoryCount];
delete from [dbo].[StoreProduct];
delete from [dbo].[Product];
delete from [dbo].[Supplier];
delete from [dbo].[Location];
delete from [dbo].[Store];

SET IDENTITY_INSERT [dbo].[Store] ON
INSERT INTO [dbo].[Store] ([Id], [Name], [Address]) VALUES (1, N'Club Retro', N'Bjergegade 1, 3000 Helsingør')
SET IDENTITY_INSERT [dbo].[Store] OFF

SET IDENTITY_INSERT [dbo].[Location] ON
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (1001, N'Baren', 1)
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (1002, N'Lageret', 1)
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (1003, N'Baglokalet', 1)
SET IDENTITY_INSERT [dbo].[Location] OFF

SET IDENTITY_INSERT [dbo].[Supplier] ON
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (1001, N'Carlsberg', N'Carlsberg@beer.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (1002, N'Tuborg', N'Tuborg@beer.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (1003, N'Royal', N'Royal@beer.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (1004, N'Smirnoff', N'Smirnoff@sprut.dk')
SET IDENTITY_INSERT [dbo].[Supplier] OFF

SET IDENTITY_INSERT [dbo].[Product] ON
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (2001, N'Carlsberg', 24, 1001)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (2002, N'Tuborg Classic', 24, 1002)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (2003, N'Royal Export', 12, 1003)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (2004, N'Smirnoff', 6, 1004)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (2005, N'Jack Daniels', 8, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF

SET IDENTITY_INSERT [dbo].[StoreProduct] ON
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (2001, 1, 2001, 240)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (2002, 1, 2003, 60)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (2003, 1, 2005, 36)
SET IDENTITY_INSERT [dbo].[StoreProduct] OFF

SET IDENTITY_INSERT [dbo].[InventoryCount] ON
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (3005, 1001, N'2019-12-08 20:17:27')
SET IDENTITY_INSERT [dbo].[InventoryCount] OFF

SET IDENTITY_INSERT [dbo].[InventoryCountProduct] ON
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (3016, 3005, 2001, 53)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (3017, 3005, 2003, 22)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (3018, 3005, 2005, 40)
SET IDENTITY_INSERT [dbo].[InventoryCountProduct] OFF

INSERT INTO [dbo].[InventoryCountHistory] ([Id], [Location], [CountDate]) VALUES (3005, N'Baren', N'2019-12-08 20:17:27')

INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (3016, N'Carlsberg', 53, 3005, 24)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (3017, N'Royal Export', 22, 3005, 12)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (3018, N'Jack Daniels', 40, 3005, 8)

SET IDENTITY_INSERT [dbo].[Order] ON
INSERT INTO [dbo].[Order] ([Id], [OrderDate]) VALUES (1003, N'2019-12-08 20:17:57')
SET IDENTITY_INSERT [dbo].[Order] OFF

SET IDENTITY_INSERT [dbo].[OrderProduct] ON
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (1008, 1003, 2001, 10)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (1009, 1003, 2003, 6)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (1010, 1003, 2005, 2)
SET IDENTITY_INSERT [dbo].[OrderProduct] OFF

INSERT INTO [dbo].[OrderHistory] ([Id], [OrderedDate]) VALUES (1003, N'2019-12-08 20:17:57')

SET IDENTITY_INSERT [dbo].[OrderHistoryData] ON
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier]) VALUES (1009, 1003, N'Carlsberg', 187, 24, 8, 10, N'Carlsberg')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier]) VALUES (1010, 1003, N'Royal Export', 38, 12, 4, 6, N'Royal')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier]) VALUES (1011, 1003, N'Jack Daniels', 0, 8, 0, 2, N'')
SET IDENTITY_INSERT [dbo].[OrderHistoryData] OFF

SET IDENTITY_INSERT [dbo].[PermissionGroup] ON
INSERT INTO [dbo].[PermissionGroup] ([Id], [Name], [CanCreateProduct], [CanDeleteProduct], [CanUpdateProduct], [CanCreateSupplier], [CanDeleteSupplier], [CanUpdateSupplier], [CanCreateLocation], [CanDeleteLocation], [CanUpdateLocation], [CanCreateInventoryCount], [CanDeleteInventoryCount], [CanViewInventoryCount], [CanCreateOrder], [CanDeleteOrder], [CanViewOrder], [CanChangeStoreProduct], [CanCreateUser], [CanDeleteUser], [CanUpdateUser], [CanCreatePermissionGroup], [CanDeletePermissionGroup], [CanUpdatePermissionGroup], [CanCreateStore], [CanDeleteStore], [CanUpdateStore]) VALUES (1, N'Default', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT INTO [dbo].[PermissionGroup] ([Id], [Name], [CanCreateProduct], [CanDeleteProduct], [CanUpdateProduct], [CanCreateSupplier], [CanDeleteSupplier], [CanUpdateSupplier], [CanCreateLocation], [CanDeleteLocation], [CanUpdateLocation], [CanCreateInventoryCount], [CanDeleteInventoryCount], [CanViewInventoryCount], [CanCreateOrder], [CanDeleteOrder], [CanViewOrder], [CanChangeStoreProduct], [CanCreateUser], [CanDeleteUser], [CanUpdateUser], [CanCreatePermissionGroup], [CanDeletePermissionGroup], [CanUpdatePermissionGroup], [CanCreateStore], [CanDeleteStore], [CanUpdateStore]) VALUES (2, N'Admin', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[PermissionGroup] OFF

SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([Id], [Name], [Username], [Password], [PhoneNumber], [GroupId]) VALUES (1, N'Timm', N'timm', N'timm', 252525, 1)
INSERT INTO [dbo].[User] ([Id], [Name], [Username], [Password], [PhoneNumber], [GroupId]) VALUES (2, N'Anders Garbacz Hansen', N'anders1', N'anders1', 66666666, 2)
SET IDENTITY_INSERT [dbo].[User] OFF

SET IDENTITY_INSERT [dbo].[UserStore] ON
INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (1, 1, 1)
INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (2, 2, 1)
SET IDENTITY_INSERT [dbo].[UserStore] OFF


