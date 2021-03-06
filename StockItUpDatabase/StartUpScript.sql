﻿USE [master]
GO
/****** Object:  Database [StockItUpDB]    Script Date: 17-12-2019 14:59:28 ******/
CREATE DATABASE [StockItUpDB]
GO
ALTER DATABASE [StockItUpDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StockItUpDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StockItUpDB] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [StockItUpDB] SET ANSI_NULLS ON 
GO
ALTER DATABASE [StockItUpDB] SET ANSI_PADDING ON 
GO
ALTER DATABASE [StockItUpDB] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [StockItUpDB] SET ARITHABORT ON 
GO
ALTER DATABASE [StockItUpDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StockItUpDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StockItUpDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StockItUpDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StockItUpDB] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [StockItUpDB] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [StockItUpDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StockItUpDB] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [StockItUpDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StockItUpDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StockItUpDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StockItUpDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StockItUpDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StockItUpDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StockItUpDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StockItUpDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StockItUpDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StockItUpDB] SET RECOVERY FULL 
GO
ALTER DATABASE [StockItUpDB] SET  MULTI_USER 
GO
ALTER DATABASE [StockItUpDB] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [StockItUpDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StockItUpDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StockItUpDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [StockItUpDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StockItUpDB] SET QUERY_STORE = OFF
GO
USE [StockItUpDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [StockItUpDB]
GO
/****** Object:  Table [dbo].[InventoryCount]    Script Date: 17-12-2019 14:59:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryCount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Location] [int] NOT NULL,
	[DateCounted] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryCountHistory]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryCountHistory](
	[Id] [int] NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[CountDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryCountHistoryData]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryCountHistoryData](
	[Id] [int] NOT NULL,
	[Product] [varchar](50) NOT NULL,
	[Amount] [int] NOT NULL,
	[InventoryCountHistory] [int] NOT NULL,
	[AmountPerBox] [int] NOT NULL,
 CONSTRAINT [PK_InventoryCountHistoryData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryCountProduct]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryCountProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InventoryCount] [int] NOT NULL,
	[Product] [int] NOT NULL,
	[Amount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Store] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderHistory]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderHistory](
	[Id] [int] NOT NULL,
	[OrderedDate] [datetime] NOT NULL,
	[StoreId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderHistoryData]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderHistoryData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderHistory] [int] NOT NULL,
	[Product] [varchar](50) NOT NULL,
	[MissingAmount] [int] NOT NULL,
	[AmountPerBox] [int] NOT NULL,
	[RecommendedAmount] [int] NOT NULL,
	[AmountOrdered] [int] NOT NULL,
	[Supplier] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Order] [int] NOT NULL,
	[Product] [int] NOT NULL,
	[OrderedAmount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionGroup]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CanCreateProduct] [bit] NOT NULL,
	[CanDeleteProduct] [bit] NOT NULL,
	[CanUpdateProduct] [bit] NOT NULL,
	[CanCreateSupplier] [bit] NOT NULL,
	[CanDeleteSupplier] [bit] NOT NULL,
	[CanUpdateSupplier] [bit] NOT NULL,
	[CanCreateLocation] [bit] NOT NULL,
	[CanDeleteLocation] [bit] NOT NULL,
	[CanUpdateLocation] [bit] NOT NULL,
	[CanCreateInventoryCount] [bit] NOT NULL,
	[CanDeleteInventoryCount] [bit] NOT NULL,
	[CanViewInventoryCount] [bit] NOT NULL,
	[CanCreateOrder] [bit] NOT NULL,
	[CanDeleteOrder] [bit] NOT NULL,
	[CanViewOrder] [bit] NOT NULL,
	[CanChangeStoreProduct] [bit] NOT NULL,
	[CanCreateUser] [bit] NOT NULL,
	[CanDeleteUser] [bit] NOT NULL,
	[CanUpdateUser] [bit] NOT NULL,
	[CanCreatePermissionGroup] [bit] NOT NULL,
	[CanDeletePermissionGroup] [bit] NOT NULL,
	[CanUpdatePermissionGroup] [bit] NOT NULL,
	[CanCreateStore] [bit] NOT NULL,
	[CanDeleteStore] [bit] NOT NULL,
	[CanUpdateStore] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[AmountPerBox] [int] NOT NULL,
	[Supplier] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoreProduct]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Store] [int] NOT NULL,
	[Product] [int] NOT NULL,
	[Amount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Website] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[PhoneNumber] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserStore]    Script Date: 17-12-2019 14:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStore](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((1)) FOR [GroupId]
GO
ALTER TABLE [dbo].[InventoryCount]  WITH CHECK ADD  CONSTRAINT [FK_InventoryCount_Location] FOREIGN KEY([Location])
REFERENCES [dbo].[Location] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InventoryCount] CHECK CONSTRAINT [FK_InventoryCount_Location]
GO
ALTER TABLE [dbo].[InventoryCountHistoryData]  WITH CHECK ADD  CONSTRAINT [FK_InventoryCountHistoryData_ToTable] FOREIGN KEY([InventoryCountHistory])
REFERENCES [dbo].[InventoryCountHistory] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InventoryCountHistoryData] CHECK CONSTRAINT [FK_InventoryCountHistoryData_ToTable]
GO
ALTER TABLE [dbo].[InventoryCountProduct]  WITH CHECK ADD  CONSTRAINT [FK_InventoryCountProduct_InventoryCount] FOREIGN KEY([InventoryCount])
REFERENCES [dbo].[InventoryCount] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InventoryCountProduct] CHECK CONSTRAINT [FK_InventoryCountProduct_InventoryCount]
GO
ALTER TABLE [dbo].[InventoryCountProduct]  WITH CHECK ADD  CONSTRAINT [FK_InventoryCountProduct_Product] FOREIGN KEY([Product])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InventoryCountProduct] CHECK CONSTRAINT [FK_InventoryCountProduct_Product]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_ToTable] FOREIGN KEY([Store])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_ToTable]
GO
ALTER TABLE [dbo].[OrderHistory]  WITH CHECK ADD  CONSTRAINT [FK_OrderHistory_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[OrderHistory] CHECK CONSTRAINT [FK_OrderHistory_Store]
GO
ALTER TABLE [dbo].[OrderHistoryData]  WITH CHECK ADD  CONSTRAINT [FK_OrderHistoryData_ToTable] FOREIGN KEY([OrderHistory])
REFERENCES [dbo].[OrderHistory] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderHistoryData] CHECK CONSTRAINT [FK_OrderHistoryData_ToTable]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY([Order])
REFERENCES [dbo].[Order] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Order]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY([Product])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ToTable] FOREIGN KEY([Supplier])
REFERENCES [dbo].[Supplier] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ToTable]
GO
ALTER TABLE [dbo].[StoreProduct]  WITH CHECK ADD  CONSTRAINT [FK_StoreProduct_Procut] FOREIGN KEY([Product])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StoreProduct] CHECK CONSTRAINT [FK_StoreProduct_Procut]
GO
ALTER TABLE [dbo].[StoreProduct]  WITH CHECK ADD  CONSTRAINT [FK_StoreProduct_ToTable] FOREIGN KEY([Store])
REFERENCES [dbo].[Store] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StoreProduct] CHECK CONSTRAINT [FK_StoreProduct_ToTable]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[PermissionGroup] ([Id])
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Group]
GO
ALTER TABLE [dbo].[UserStore]  WITH CHECK ADD  CONSTRAINT [FK_UserStore_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserStore] CHECK CONSTRAINT [FK_UserStore_Store]
GO
ALTER TABLE [dbo].[UserStore]  WITH CHECK ADD  CONSTRAINT [FK_UserStore_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserStore] CHECK CONSTRAINT [FK_UserStore_User]
GO
USE [master]
GO
ALTER DATABASE [StockItUpDB] SET  READ_WRITE 
GO

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

SET IDENTITY_INSERT [dbo].[InventoryCount] ON
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (8016, 1, N'2019-12-17 13:16:01')
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (8017, 2, N'2019-12-17 13:16:44')
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (8018, 3, N'2019-12-17 13:17:26')
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (8019, 4, N'2019-12-17 13:19:20')
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (8020, 5, N'2019-12-17 13:19:29')
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (8021, 6, N'2019-12-17 13:19:52')
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (8022, 7, N'2019-12-17 13:21:02')
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (8023, 8, N'2019-12-17 13:21:10')
INSERT INTO [dbo].[InventoryCount] ([Id], [Location], [DateCounted]) VALUES (8024, 9, N'2019-12-17 13:21:26')
SET IDENTITY_INSERT [dbo].[InventoryCount] OFF

SET IDENTITY_INSERT [dbo].[InventoryCountProduct] ON
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8046, 8016, 9, 4)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8047, 8016, 12, 2)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8048, 8016, 1, 24)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8049, 8016, 3, 24)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8050, 8016, 6, 2)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8051, 8016, 2, 12)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8052, 8017, 9, 18)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8053, 8017, 12, 24)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8054, 8017, 1, 48)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8055, 8017, 3, 36)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8056, 8017, 6, 24)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8057, 8017, 2, 48)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8058, 8018, 1, 72)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8059, 8018, 2, 48)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8060, 8019, 4, 4)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8061, 8019, 11, 4)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8062, 8019, 10, 4)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8063, 8019, 7, 4)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8064, 8019, 2, 4)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8065, 8020, 4, 10)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8066, 8020, 11, 10)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8067, 8020, 10, 10)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8068, 8020, 7, 10)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8069, 8020, 2, 10)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8070, 8021, 11, 48)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8071, 8021, 2, 48)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8072, 8022, 4, 2)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8073, 8022, 8, 3)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8074, 8022, 10, 4)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8075, 8022, 6, 1)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8076, 8023, 4, 1)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8077, 8023, 8, 4)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8078, 8023, 10, 2)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8079, 8023, 6, 5)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8080, 8024, 4, 6)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8081, 8024, 8, 24)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8082, 8024, 10, 18)
INSERT INTO [dbo].[InventoryCountProduct] ([Id], [InventoryCount], [Product], [Amount]) VALUES (8083, 8024, 6, 24)
SET IDENTITY_INSERT [dbo].[InventoryCountProduct] OFF

INSERT INTO [dbo].[InventoryCountHistory] ([Id], [Location], [CountDate]) VALUES (8016, N'Baren', N'2019-12-17 13:16:01')
INSERT INTO [dbo].[InventoryCountHistory] ([Id], [Location], [CountDate]) VALUES (8017, N'Lageret', N'2019-12-17 13:16:44')
INSERT INTO [dbo].[InventoryCountHistory] ([Id], [Location], [CountDate]) VALUES (8018, N'Baglokalet', N'2019-12-17 13:17:26')
INSERT INTO [dbo].[InventoryCountHistory] ([Id], [Location], [CountDate]) VALUES (8019, N'Hylderne', N'2019-12-17 13:19:20')
INSERT INTO [dbo].[InventoryCountHistory] ([Id], [Location], [CountDate]) VALUES (8020, N'Under disken', N'2019-12-17 13:19:29')
INSERT INTO [dbo].[InventoryCountHistory] ([Id], [Location], [CountDate]) VALUES (8021, N'Kælderen', N'2019-12-17 13:19:52')
INSERT INTO [dbo].[InventoryCountHistory] ([Id], [Location], [CountDate]) VALUES (8022, N'Bar 1', N'2019-12-17 13:21:02')
INSERT INTO [dbo].[InventoryCountHistory] ([Id], [Location], [CountDate]) VALUES (8023, N'Bar 2', N'2019-12-17 13:21:10')
INSERT INTO [dbo].[InventoryCountHistory] ([Id], [Location], [CountDate]) VALUES (8024, N'Ølrum', N'2019-12-17 13:21:26')

INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8046, N'Bacardi', 4, 8016, 6)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8047, N'Captain Morgan', 2, 8016, 6)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8048, N'Carlsberg', 24, 8016, 24)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8049, N'Royal Export', 24, 8016, 12)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8050, N'Toilet papir', 2, 8016, 12)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8051, N'Tuborg Classic', 12, 8016, 24)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8052, N'Bacardi', 18, 8017, 6)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8053, N'Captain Morgan', 24, 8017, 6)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8054, N'Carlsberg', 48, 8017, 24)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8055, N'Royal Export', 36, 8017, 12)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8056, N'Toilet papir', 24, 8017, 12)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8057, N'Tuborg Classic', 48, 8017, 24)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8058, N'Carlsberg', 72, 8018, 24)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8059, N'Tuborg Classic', 48, 8018, 24)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8060, N'Beavertown Neck Oil', 4, 8019, 6)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8061, N'Smirnoff Ice', 4, 8019, 24)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8062, N'Smirnoff Vodka', 4, 8019, 6)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8063, N'Sølv papir', 4, 8019, 2)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8064, N'Tuborg Classic', 4, 8019, 24)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8065, N'Beavertown Neck Oil', 10, 8020, 6)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8066, N'Smirnoff Ice', 10, 8020, 24)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8067, N'Smirnoff Vodka', 10, 8020, 6)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8068, N'Sølv papir', 10, 8020, 2)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8069, N'Tuborg Classic', 10, 8020, 24)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8070, N'Smirnoff Ice', 48, 8021, 24)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8071, N'Tuborg Classic', 48, 8021, 24)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8072, N'Beavertown Neck Oil', 2, 8022, 6)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8073, N'Instant kaffe', 3, 8022, 12)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8074, N'Smirnoff Vodka', 4, 8022, 6)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8075, N'Toilet papir', 1, 8022, 12)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8076, N'Beavertown Neck Oil', 1, 8023, 6)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8077, N'Instant kaffe', 4, 8023, 12)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8078, N'Smirnoff Vodka', 2, 8023, 6)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8079, N'Toilet papir', 5, 8023, 12)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8080, N'Beavertown Neck Oil', 6, 8024, 6)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8081, N'Instant kaffe', 24, 8024, 12)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8082, N'Smirnoff Vodka', 18, 8024, 6)
INSERT INTO [dbo].[InventoryCountHistoryData] ([Id], [Product], [Amount], [InventoryCountHistory], [AmountPerBox]) VALUES (8083, N'Toilet papir', 24, 8024, 12)

SET IDENTITY_INSERT [dbo].[Order] ON
INSERT INTO [dbo].[Order] ([Id], [OrderDate]) VALUES (2047, N'2019-12-17 13:18:01')
INSERT INTO [dbo].[Order] ([Id], [OrderDate]) VALUES (2048, N'2019-12-17 13:20:11')
INSERT INTO [dbo].[Order] ([Id], [OrderDate]) VALUES (2049, N'2019-12-17 13:21:43')
SET IDENTITY_INSERT [dbo].[Order] OFF

SET IDENTITY_INSERT [dbo].[OrderProduct] ON
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (2103, 2047, 1, 6)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (2104, 2047, 2, 3)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (2105, 2047, 3, 2)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (2106, 2047, 6, 5)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (2107, 2047, 9, 3)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (2108, 2047, 12, 7)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (2109, 2048, 2, 1)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (2110, 2048, 4, 2)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (2111, 2048, 7, 1)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (2112, 2048, 10, 3)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (2113, 2049, 4, 6)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (2114, 2049, 6, 4)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (2115, 2049, 8, 2)
INSERT INTO [dbo].[OrderProduct] ([Id], [Order], [Product], [OrderedAmount]) VALUES (2116, 2049, 10, 8)
SET IDENTITY_INSERT [dbo].[OrderProduct] OFF

INSERT INTO [dbo].[OrderHistory] ([Id], [OrderedDate], [StoreId]) VALUES (2047, N'2019-12-17 13:18:01', 1)
INSERT INTO [dbo].[OrderHistory] ([Id], [OrderedDate], [StoreId]) VALUES (2048, N'2019-12-17 13:20:11', 2)
INSERT INTO [dbo].[OrderHistory] ([Id], [OrderedDate], [StoreId]) VALUES (2049, N'2019-12-17 13:21:43', 3)

SET IDENTITY_INSERT [dbo].[OrderHistoryData] ON
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier], [Email]) VALUES (2093, 2047, N'Carlsberg', 96, 24, 4, 6, N'Carlsberg', N'kontakt@carlsberg.dk')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier], [Email]) VALUES (2094, 2047, N'Tuborg Classic', 12, 24, 1, 3, N'Carlsberg', N'kontakt@carlsberg.dk')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier], [Email]) VALUES (2095, 2047, N'Royal Export', 12, 12, 1, 2, N'Inco', N'kontakt@inco.dk')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier], [Email]) VALUES (2096, 2047, N'Toilet papir', 10, 12, 1, 5, N'N/A', N'N/A')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier], [Email]) VALUES (2097, 2047, N'Bacardi', 8, 6, 2, 3, N'Dagrofa', N'kontakt@dagrofa.dk')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier], [Email]) VALUES (2098, 2047, N'Captain Morgan', 34, 6, 6, 7, N'Dagrofa', N'kontakt@dagrofa.dk')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier], [Email]) VALUES (2099, 2048, N'Tuborg Classic', 34, 24, 2, 1, N'Carlsberg', N'kontakt@carlsberg.dk')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier], [Email]) VALUES (2100, 2048, N'Beavertown Neck Oil', 0, 6, 0, 2, N'One Pint', N'kontakt@onepint.dk')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier], [Email]) VALUES (2101, 2048, N'Sølv papir', 0, 2, 0, 1, N'N/A', N'N/A')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier], [Email]) VALUES (2102, 2048, N'Smirnoff Vodka', 6, 6, 1, 3, N'Dagrofa', N'kontakt@dagrofa.dk')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier], [Email]) VALUES (2103, 2049, N'Beavertown Neck Oil', 24, 6, 4, 6, N'One Pint', N'kontakt@onepint.dk')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier], [Email]) VALUES (2104, 2049, N'Toilet papir', 18, 12, 2, 4, N'N/A', N'N/A')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier], [Email]) VALUES (2105, 2049, N'Instant kaffe', 5, 12, 1, 2, N'Inco', N'kontakt@inco.dk')
INSERT INTO [dbo].[OrderHistoryData] ([Id], [OrderHistory], [Product], [MissingAmount], [AmountPerBox], [RecommendedAmount], [AmountOrdered], [Supplier], [Email]) VALUES (2106, 2049, N'Smirnoff Vodka', 56, 6, 10, 8, N'Dagrofa', N'kontakt@dagrofa.dk')
SET IDENTITY_INSERT [dbo].[OrderHistoryData] OFF

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
INSERT INTO [dbo].[User] ([Id], [Name], [Username], [Password], [PhoneNumber], [GroupId]) VALUES (5, N'Admin', N'admin', N'admin', 23501022, 2)
SET IDENTITY_INSERT [dbo].[User] OFF

SET IDENTITY_INSERT [dbo].[UserStore] ON
INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (1, 1, 1)

INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (2, 2, 1)
INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (3, 2, 3)

INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (4, 4, 1)
INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (5, 4, 2)
INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (6, 4, 3)

INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (7, 5, 1)
INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (8, 5, 2)
INSERT INTO [dbo].[UserStore] ([Id], [UserId], [StoreId]) VALUES (9, 5, 3)
SET IDENTITY_INSERT [dbo].[UserStore] OFF


