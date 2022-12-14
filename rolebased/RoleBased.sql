USE [master]
GO
/****** Object:  Database [RoleBased]    Script Date: 8/20/2022 10:49:42 PM ******/
CREATE DATABASE [RoleBased]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RoleBased', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RoleBased.mdf' , SIZE = 20480KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RoleBased_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RoleBased_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RoleBased] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RoleBased].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RoleBased] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RoleBased] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RoleBased] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RoleBased] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RoleBased] SET ARITHABORT OFF 
GO
ALTER DATABASE [RoleBased] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RoleBased] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RoleBased] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RoleBased] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RoleBased] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RoleBased] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RoleBased] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RoleBased] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RoleBased] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RoleBased] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RoleBased] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RoleBased] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RoleBased] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RoleBased] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RoleBased] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RoleBased] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RoleBased] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RoleBased] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RoleBased] SET  MULTI_USER 
GO
ALTER DATABASE [RoleBased] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RoleBased] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RoleBased] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RoleBased] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RoleBased] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RoleBased] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [RoleBased] SET QUERY_STORE = OFF
GO
USE [RoleBased]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 8/20/2022 10:49:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[customerID] [int] IDENTITY(1,1) NOT NULL,
	[customerName] [nvarchar](50) NOT NULL,
	[customerSurname] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[department]    Script Date: 8/20/2022 10:49:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[departmantName] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[food]    Script Date: 8/20/2022 10:49:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[food](
	[foodID] [int] IDENTITY(1,1) NOT NULL,
	[foodName] [nvarchar](50) NULL,
	[foodPrice] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personel]    Script Date: 8/20/2022 10:49:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personel](
	[personelID] [int] IDENTITY(1,1) NOT NULL,
	[personelName] [nvarchar](50) NOT NULL,
	[personelSurname] [nvarchar](50) NULL,
 CONSTRAINT [PK_personel] PRIMARY KEY CLUSTERED 
(
	[personelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[customer] ON 

INSERT [dbo].[customer] ([customerID], [customerName], [customerSurname]) VALUES (1, N'mergiz', N'sonkavak')
INSERT [dbo].[customer] ([customerID], [customerName], [customerSurname]) VALUES (2, N'eray', NULL)
INSERT [dbo].[customer] ([customerID], [customerName], [customerSurname]) VALUES (3, N'fatma', N'uzun')
INSERT [dbo].[customer] ([customerID], [customerName], [customerSurname]) VALUES (4, N'veli', NULL)
INSERT [dbo].[customer] ([customerID], [customerName], [customerSurname]) VALUES (5, N'mustafa', N'bayrak')
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
SET IDENTITY_INSERT [dbo].[department] ON 

INSERT [dbo].[department] ([id], [departmantName]) VALUES (1, N'Insan Kaynaklari')
INSERT [dbo].[department] ([id], [departmantName]) VALUES (2, N'Satis Departmani')
INSERT [dbo].[department] ([id], [departmantName]) VALUES (3, N'IT Ekibi')
SET IDENTITY_INSERT [dbo].[department] OFF
GO
SET IDENTITY_INSERT [dbo].[food] ON 

INSERT [dbo].[food] ([foodID], [foodName], [foodPrice]) VALUES (1, N'cikolata', 23)
INSERT [dbo].[food] ([foodID], [foodName], [foodPrice]) VALUES (2, N'su', 2)
INSERT [dbo].[food] ([foodID], [foodName], [foodPrice]) VALUES (3, N'kofte', 40)
INSERT [dbo].[food] ([foodID], [foodName], [foodPrice]) VALUES (4, N'tavuk', 20)
INSERT [dbo].[food] ([foodID], [foodName], [foodPrice]) VALUES (5, N'pepsi', 5)
SET IDENTITY_INSERT [dbo].[food] OFF
GO
SET IDENTITY_INSERT [dbo].[personel] ON 

INSERT [dbo].[personel] ([personelID], [personelName], [personelSurname]) VALUES (1, N'ahmet', N'senturk')
INSERT [dbo].[personel] ([personelID], [personelName], [personelSurname]) VALUES (2, N'melike', NULL)
INSERT [dbo].[personel] ([personelID], [personelName], [personelSurname]) VALUES (3, N'asli', NULL)
INSERT [dbo].[personel] ([personelID], [personelName], [personelSurname]) VALUES (4, N'mehmet', N'sonmez')
INSERT [dbo].[personel] ([personelID], [personelName], [personelSurname]) VALUES (5, N'adal', N'kokulu')
INSERT [dbo].[personel] ([personelID], [personelName], [personelSurname]) VALUES (6, N'melisa', NULL)
INSERT [dbo].[personel] ([personelID], [personelName], [personelSurname]) VALUES (7, N'zehra', N'gumus')
INSERT [dbo].[personel] ([personelID], [personelName], [personelSurname]) VALUES (8, N'zubeyir', N'cakir')
INSERT [dbo].[personel] ([personelID], [personelName], [personelSurname]) VALUES (10, N'alp', N'soylu')
INSERT [dbo].[personel] ([personelID], [personelName], [personelSurname]) VALUES (11, N'cenk', N'akcadogan')
SET IDENTITY_INSERT [dbo].[personel] OFF
GO
USE [master]
GO
ALTER DATABASE [RoleBased] SET  READ_WRITE 
GO
