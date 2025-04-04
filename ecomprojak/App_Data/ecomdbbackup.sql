USE [master]
GO
/****** Object:  Database [ecomado]    Script Date: 01/27/2025 11:48:50 ******/
CREATE DATABASE [ecomado] ON  PRIMARY 
( NAME = N'ecomado', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ecomado.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ecomado_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ecomado_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ecomado] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ecomado].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ecomado] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ecomado] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ecomado] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ecomado] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ecomado] SET ARITHABORT OFF
GO
ALTER DATABASE [ecomado] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ecomado] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ecomado] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ecomado] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ecomado] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ecomado] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ecomado] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ecomado] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ecomado] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ecomado] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ecomado] SET  DISABLE_BROKER
GO
ALTER DATABASE [ecomado] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ecomado] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ecomado] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ecomado] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ecomado] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ecomado] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ecomado] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ecomado] SET  READ_WRITE
GO
ALTER DATABASE [ecomado] SET RECOVERY SIMPLE
GO
ALTER DATABASE [ecomado] SET  MULTI_USER
GO
ALTER DATABASE [ecomado] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ecomado] SET DB_CHAINING OFF
GO
USE [ecomado]
GO
/****** Object:  Table [dbo].[Tbl_Register]    Script Date: 01/27/2025 11:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Register](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[email] [varchar](200) NOT NULL,
	[password] [varchar](200) NULL,
	[mob] [varchar](20) NOT NULL,
	[profile] [varchar](max) NULL,
	[address] [varchar](200) NULL,
	[regdate] [varchar](50) NULL,
 CONSTRAINT [PK_Tbl_Register] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_Tbl_Register] ON [dbo].[Tbl_Register] 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Register] ON
INSERT [dbo].[Tbl_Register] ([id], [name], [email], [password], [mob], [profile], [address], [regdate]) VALUES (1, N'Arpit', N'ARTISAHU799141@GMAIL.COM', N'12345', N'8303369524', N'IMG_20241121_170528.jpg', N'LALITPUR UP', N'06-01-2025')
SET IDENTITY_INSERT [dbo].[Tbl_Register] OFF
/****** Object:  Table [dbo].[Tbl_Product]    Script Date: 01/27/2025 11:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Product](
	[pid] [int] IDENTITY(1,1) NOT NULL,
	[pname] [varchar](100) NOT NULL,
	[pcate] [varchar](200) NOT NULL,
	[price] [varchar](200) NOT NULL,
	[disprice] [varchar](200) NOT NULL,
	[pquantity] [varchar](200) NOT NULL,
	[ppic] [varchar](max) NOT NULL,
	[description] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Product] ON
INSERT [dbo].[Tbl_Product] ([pid], [pname], [pcate], [price], [disprice], [pquantity], [ppic], [description]) VALUES (1, N'Apple', N'Fruits', N'150', N'130', N'1', N'best-product-6.jpg', N'it is good for health.fresh food')
INSERT [dbo].[Tbl_Product] ([pid], [pname], [pcate], [price], [disprice], [pquantity], [ppic], [description]) VALUES (2, N'Tomato', N'Vegetable', N'50', N'39', N'1', N'360_F_34617669_p9r4GrR83TBEXCZrRny6AaigqPUEPFp5.jpg', N'it is tomato good for health')
INSERT [dbo].[Tbl_Product] ([pid], [pname], [pcate], [price], [disprice], [pquantity], [ppic], [description]) VALUES (3, N'Potato', N'Vegetable', N'40', N'29', N'1', N'aa3ccaee-f570-466f-a314-80edd0e0e911.jpg', N'it is potato good for health')
INSERT [dbo].[Tbl_Product] ([pid], [pname], [pcate], [price], [disprice], [pquantity], [ppic], [description]) VALUES (4, N'Orange ', N'Fruits', N'90', N'70', N'1', N'orange-isolated-on-white-background-clipping-path-full-depth-of-field.jpg', N'it is good ')
INSERT [dbo].[Tbl_Product] ([pid], [pname], [pcate], [price], [disprice], [pquantity], [ppic], [description]) VALUES (5, N'Onion', N'Vegetable', N'150', N'130', N'2.5 ', N'Fresh-Onion-OR-Pyaaz.png', N'it is good')
SET IDENTITY_INSERT [dbo].[Tbl_Product] OFF
/****** Object:  Table [dbo].[Tbl_Login]    Script Date: 01/27/2025 11:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Login](
	[email] [varchar](200) NOT NULL,
	[password] [varchar](200) NULL,
 CONSTRAINT [PK_Tbl_Login] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Tbl_Login] ([email], [password]) VALUES (N'admin@gmail.com', N'1234')
/****** Object:  Table [dbo].[Tbl_Contact]    Script Date: 01/27/2025 11:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[email] [varchar](200) NULL,
	[enquiry] [varchar](200) NULL,
	[regdate] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Category]    Script Date: 01/27/2025 11:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Category](
	[cid] [int] IDENTITY(1,1) NOT NULL,
	[cname] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[cid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Category] ON
INSERT [dbo].[Tbl_Category] ([cid], [cname]) VALUES (1, N'Fruits')
INSERT [dbo].[Tbl_Category] ([cid], [cname]) VALUES (2, N'Vegetable')
SET IDENTITY_INSERT [dbo].[Tbl_Category] OFF
