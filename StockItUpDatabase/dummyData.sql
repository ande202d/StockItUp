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
INSERT INTO [dbo].[Store] ([Id], [Name], [Address]) VALUES (2, N'Hjorten', N'Herlev Hovedgade 5, 2730 Herlev')
INSERT INTO [dbo].[Store] ([Id], [Name], [Address]) VALUES (3, N'SOHO Musicbar', N'Kanalstræde 14, 4300 Holbæk')
SET IDENTITY_INSERT [dbo].[Store] OFF

SET IDENTITY_INSERT [dbo].[Location] ON
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (1, N'Baren', 1)
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (2, N'Lageret', 1)
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (3, N'Baglokalet', 1)

INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (4, N'Hylderne', 2)
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (5, N'Under disken', 2)
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (6, N'Kælderen', 2)

INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (7, N'Bar 1', 3)
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (8, N'Bar 2', 3)
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (9, N'Ølrum', 3)
SET IDENTITY_INSERT [dbo].[Location] OFF

SET IDENTITY_INSERT [dbo].[Supplier] ON
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (1, N'Carlsberg', N'kontakt@carlsberg.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (2, N'Nørrebro Bryghus', N'kontakt@noerrebrobryghus.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (3, N'One Pint', N'kontakt@onepint.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (4, N'Det Belgiske Hus', N'kontakt@detbelgiskehus.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (5, N'Klosterbyggeriet', N'kontakt@klosterbyggeriet.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (6, N'Primabeer', N'kontakt@primabeer.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (7, N'Inco', N'kontakt@inco.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (8, N'Dagrofa', N'kontakt@dagrofa.dk')
SET IDENTITY_INSERT [dbo].[Supplier] OFF

SET IDENTITY_INSERT [dbo].[Product] ON
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (1, N'Carlsberg', 24, 1)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (2, N'Tuborg Classic', 24, 1)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (3, N'Royal Export', 12, 7)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (4, N'Beavertown Neck Oil', 6, 3)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (5, N'Jack Daniels', 6, 8)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (6, N'Toilet papir', 12, NULL)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (7, N'Sølv papir', 2, NULL)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (8, N'Instant kaffe', 12, 7)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (9, N'Bacardi', 6, 8)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (10, N'Smirnoff Vodka', 6, 8)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (11, N'Smirnoff Ice', 24, 7)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (12, N'Captain Morgan', 6, 8)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (13, N'Jule Dubbel', 12, 2)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (14, N'Nørrebro Jule IPA', 12, 2)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (15, N'Belhaven Craft Pilsner', 6, 3)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (16, N'Neo Human Cannonball', 6, 4)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (17, N'Unhuman Cannonball', 12, 4)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (18, N'Saucery', 12, 4)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (19, N'Fantasma', 24, 4)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (20, N'PorterHouse Brainblasta', 1, 5)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (21, N'PorterHouse Yippy IPA', 1, 5)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (22, N'Herold Tjekkisk Pils', 1, 5)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (23, N'Herold Lys Lager', 24, 5)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (24, N'Weizenbier', 24, 6)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (25, N'Chipper', 12, 6)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (26, N'Premium Dark', 1, 6)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (27, N'Rørsukker', 1, NULL)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (28, N'Limefrugt', 48, NULL)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (29, N'Gin Mare', 6, 8)
SET IDENTITY_INSERT [dbo].[Product] OFF

SET IDENTITY_INSERT [dbo].[StoreProduct] ON
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (1, 1, 1, 240)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (2, 1, 2, 120)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (3, 1, 3, 72)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (4, 1, 6, 36)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (5, 1, 9, 30)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (6, 1, 12, 60)

INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (7, 2, 2, 96)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (8, 2, 4, 12)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (9, 2, 7, 10)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (10, 2, 10, 20)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (11, 2, 11, 48)

INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (12, 3, 4, 33)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (13, 3, 6, 48)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (14, 3, 8, 36)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (15, 3, 10, 80)
SET IDENTITY_INSERT [dbo].[StoreProduct] OFF

--SET IDENTITY_INSERT [dbo].[InventoryCount] ON
--INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (3005, 1001, N'2019-12-08 20:17:27')
--SET IDENTITY_INSERT [dbo].[InventoryCount] OFF

--SET IDENTITY_INSERT [dbo].[InventoryCountProduct] ON
--INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (3016, 3005, 2001, 53)
--INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (3017, 3005, 2003, 22)
--INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (3018, 3005, 2005, 40)
--SET IDENTITY_INSERT [dbo].[InventoryCountProduct] OFF

--INSERT INTO [dbo].[InventoryCountHistory] ([Id], [Location], [CountDate]) VALUES (3005, N'Baren', N'2019-12-08 20:17:27')

--INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (3016, N'Carlsberg', 53, 3005, 24)
--INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (3017, N'Royal Export', 22, 3005, 12)
--INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (3018, N'Jack Daniels', 40, 3005, 8)

--SET IDENTITY_INSERT [dbo].[Order] ON
--INSERT INTO [dbo].[Order] ([Id], [OrderDate]) VALUES (1003, N'2019-12-08 20:17:57')
--SET IDENTITY_INSERT [dbo].[Order] OFF

--SET IDENTITY_INSERT [dbo].[OrderProduct] ON
--INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (1008, 1003, 2001, 10)
--INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (1009, 1003, 2003, 6)
--INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (1010, 1003, 2005, 2)
--SET IDENTITY_INSERT [dbo].[OrderProduct] OFF

--INSERT INTO [dbo].[OrderHistory] ([Id], [OrderedDate]) VALUES (1003, N'2019-12-08 20:17:57')

--SET IDENTITY_INSERT [dbo].[OrderHistoryData] ON
--INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier]) VALUES (1009, 1003, N'Carlsberg', 187, 24, 8, 10, N'Carlsberg')
--INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier]) VALUES (1010, 1003, N'Royal Export', 38, 12, 4, 6, N'Royal')
--INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier]) VALUES (1011, 1003, N'Jack Daniels', 0, 8, 0, 2, N'')
--SET IDENTITY_INSERT [dbo].[OrderHistoryData] OFF

SET IDENTITY_INSERT [dbo].[PermissionGroup] ON
INSERT INTO [dbo].[PermissionGroup] ([Id], [Name], [CanCreateProduct], [CanDeleteProduct], [CanUpdateProduct], [CanCreateSupplier], [CanDeleteSupplier], [CanUpdateSupplier], [CanCreateLocation], [CanDeleteLocation], [CanUpdateLocation], [CanCreateInventoryCount], [CanDeleteInventoryCount], [CanViewInventoryCount], [CanCreateOrder], [CanDeleteOrder], [CanViewOrder], [CanChangeStoreProduct], [CanCreateUser], [CanDeleteUser], [CanUpdateUser], [CanCreatePermissionGroup], [CanDeletePermissionGroup], [CanUpdatePermissionGroup], [CanCreateStore], [CanDeleteStore], [CanUpdateStore]) VALUES (1, N'Default', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT INTO [dbo].[PermissionGroup] ([Id], [Name], [CanCreateProduct], [CanDeleteProduct], [CanUpdateProduct], [CanCreateSupplier], [CanDeleteSupplier], [CanUpdateSupplier], [CanCreateLocation], [CanDeleteLocation], [CanUpdateLocation], [CanCreateInventoryCount], [CanDeleteInventoryCount], [CanViewInventoryCount], [CanCreateOrder], [CanDeleteOrder], [CanViewOrder], [CanChangeStoreProduct], [CanCreateUser], [CanDeleteUser], [CanUpdateUser], [CanCreatePermissionGroup], [CanDeletePermissionGroup], [CanUpdatePermissionGroup], [CanCreateStore], [CanDeleteStore], [CanUpdateStore]) VALUES (2, N'Admin', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
INSERT INTO [dbo].[PermissionGroup] ([Id], [Name], [CanCreateProduct], [CanDeleteProduct], [CanUpdateProduct], [CanCreateSupplier], [CanDeleteSupplier], [CanUpdateSupplier], [CanCreateLocation], [CanDeleteLocation], [CanUpdateLocation], [CanCreateInventoryCount], [CanDeleteInventoryCount], [CanViewInventoryCount], [CanCreateOrder], [CanDeleteOrder], [CanViewOrder], [CanChangeStoreProduct], [CanCreateUser], [CanDeleteUser], [CanUpdateUser], [CanCreatePermissionGroup], [CanDeletePermissionGroup], [CanUpdatePermissionGroup], [CanCreateStore], [CanDeleteStore], [CanUpdateStore]) VALUES (3, N'CoOwner', 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1)
SET IDENTITY_INSERT [dbo].[PermissionGroup] OFF

SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([Id], [Name], [Username], [Password], [PhoneNumber], [GroupId]) VALUES (1, N'Timm Oleander Nielsen', N'timm', N'timm', 50417109, 2)
INSERT INTO [dbo].[User] ([Id], [Name], [Username], [Password], [PhoneNumber], [GroupId]) VALUES (2, N'Anders Garbacz Hansen', N'anders', N'anders', 66666666, 2)
INSERT INTO [dbo].[User] ([Id], [Name], [Username], [Password], [PhoneNumber], [GroupId]) VALUES (3, N'Jacob B Madvig', N'jacob', N'jacob', 29416828, 1)
INSERT INTO [dbo].[User] ([Id], [Name], [Username], [Password], [PhoneNumber], [GroupId]) VALUES (4, N'Jonas Andersen', N'jonas', N'jonas', 50578042, 1)
INSERT INTO [dbo].[User] ([Id], [Name], [Username], [Password], [PhoneNumber], [GroupId]) VALUES (5, N'Admin', N'admin', N'admin', 23501022, 1)
SET IDENTITY_INSERT [dbo].[User] OFF

SET IDENTITY_INSERT [dbo].[UserStore] ON
INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (1, 1, 1)

INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (2, 2, 1)
INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (3, 2, 3)

INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (4, 4, 1)
INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (5, 4, 2)
INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (6, 4, 3)
SET IDENTITY_INSERT [dbo].[UserStore] OFF


