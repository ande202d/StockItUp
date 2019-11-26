USE [StockItUpDB]
GO
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
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (1, N'loc1', 1)
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (2, N'loc2', 1)
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (4, N'loc3', 1)
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (5, N'loc4', 1)
INSERT INTO [dbo].[Location] ([Id], [Name], [Store]) VALUES (6, N'loc5', 1)
SET IDENTITY_INSERT [dbo].[Location] OFF

SET IDENTITY_INSERT [dbo].[Supplier] ON
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (1, N'Carlsberg', N'www.carlsberg.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (2, N'Nørrebro Bryghus', N'www.noerrebrobryghus.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (3, N'One Pint', N'www.onepint.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (4, N'Det Belgiske Hus', N'www.detbelgiskehus.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (5, N'Klosterbyggeriet', N'www.klosterbyggeriet.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (7, N'Inco', N'www.inco.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (8, N'Dagrofa', N'www.dagrofa.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (9, N'leverandør 1', N'www.lev1.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (10, N'Klosterbyg', N'www.klosterbyg.dk')
INSERT INTO [dbo].[Supplier] ([Id], [Name], [Website]) VALUES (11, N'test1', N'www.test1.dk')
SET IDENTITY_INSERT [dbo].[Supplier] OFF

SET IDENTITY_INSERT [dbo].[Product] ON
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (1, N'Smirnoff Vodka', 6, 1)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (2, N'Grøn Tuborg', 24, 4)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (3, N'Bacardi Breezer', 24, 2)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (4, N'Klosterøl', 8, 3)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (5, N'Royal', 12, 7)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (6, N'Anders is Awesome', 69, NULL)
INSERT INTO [dbo].[Product] ([Id], [Name], [AmountPerBox], [Supplier]) VALUES (7, N'Tuborg', 24, 7)
SET IDENTITY_INSERT [dbo].[Product] OFF

SET IDENTITY_INSERT [dbo].[StoreProduct] ON
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (1, 1, 1, 48)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (2, 1, 2, 30)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (3, 1, 3, 45)
INSERT INTO [dbo].[StoreProduct] ([Id], [Store], [Product], [Amount]) VALUES (4, 1, 6, 690)
SET IDENTITY_INSERT [dbo].[StoreProduct] OFF

SET IDENTITY_INSERT [dbo].[InventoryCount] ON
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (2, 1, N'2019-11-25 00:00:00')
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (3, 2, N'2019-11-27 00:00:00')
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (4, 1, N'2019-11-28 00:00:00')
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (7, 4, N'2019-11-28 00:00:00')
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (8, 2, N'2019-11-29 00:00:00')
SET IDENTITY_INSERT [dbo].[InventoryCount] OFF

SET IDENTITY_INSERT [dbo].[InventoryCountProduct] ON
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (3, 2, 1, 10)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (4, 2, 2, 11)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (5, 2, 3, 12)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (6, 3, 2, 21)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (7, 3, 3, 22)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8, 4, 1, 33)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (9, 4, 2, 10)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (10, 7, 1, 10)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (11, 7, 2, 12)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (12, 7, 3, 15)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (13, 8, 2, 5)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (14, 8, 3, 8)
SET IDENTITY_INSERT [dbo].[InventoryCountProduct] OFF



