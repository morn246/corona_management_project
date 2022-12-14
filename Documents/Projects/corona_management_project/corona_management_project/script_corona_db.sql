USE [master]
GO
/****** Object:  Database [CoronaDB]    Script Date: 23/10/2022 17:41:04 ******/
CREATE DATABASE [CoronaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CoronaDB', FILENAME = N'C:\Users\97252\CoronaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CoronaDB_log', FILENAME = N'C:\Users\97252\CoronaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CoronaDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CoronaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CoronaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CoronaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CoronaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CoronaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CoronaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CoronaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CoronaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CoronaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CoronaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CoronaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CoronaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CoronaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CoronaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CoronaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CoronaDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CoronaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CoronaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CoronaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CoronaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CoronaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CoronaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CoronaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CoronaDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CoronaDB] SET  MULTI_USER 
GO
ALTER DATABASE [CoronaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CoronaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CoronaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CoronaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CoronaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CoronaDB] SET QUERY_STORE = OFF
GO
USE [CoronaDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CoronaDB]
GO
/****** Object:  Table [dbo].[HMO_member]    Script Date: 23/10/2022 17:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HMO_member](
	[code_HMO_member] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](20) NOT NULL,
	[identity_card] [nchar](10) NOT NULL,
	[address] [nvarchar](30) NULL,
	[mobile_phone] [nchar](10) NULL,
	[phone] [nchar](10) NULL,
	[date_birth] [date] NULL,
 CONSTRAINT [PK_HMO_member1] PRIMARY KEY CLUSTERED 
(
	[code_HMO_member] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[manufacturer_table]    Script Date: 23/10/2022 17:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[manufacturer_table](
	[code_manufacturer] [int] IDENTITY(1,1) NOT NULL,
	[name_manufacturer] [nvarchar](20) NULL,
 CONSTRAINT [PK_manufacturer_table1] PRIMARY KEY CLUSTERED 
(
	[code_manufacturer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[positive_corona_member]    Script Date: 23/10/2022 17:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[positive_corona_member](
	[code_HMO_member] [int] NOT NULL,
	[date_recovery_corona] [date] NULL,
	[date_positive_corona] [date] NULL,
 CONSTRAINT [PK_positive_corona_member1] PRIMARY KEY CLUSTERED 
(
	[code_HMO_member] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vaccination_member_details]    Script Date: 23/10/2022 17:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vaccination_member_details](
	[code_HMO_member] [int] NOT NULL,
	[vaccination_date] [date] NOT NULL,
	[code_manufacturer] [int] NULL,
 CONSTRAINT [PK_vaccination_member_details1] PRIMARY KEY CLUSTERED 
(
	[code_HMO_member] ASC,
	[vaccination_date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[HMO_member] ON 

INSERT [dbo].[HMO_member] ([code_HMO_member], [full_name], [identity_card], [address], [mobile_phone], [phone], [date_birth]) VALUES (1, N'Hannah Levin', N'207852963 ', N'Solomon the King 100 Tel Aviv', N'0586542899', N'049874512 ', CAST(N'1985-08-10' AS Date))
INSERT [dbo].[HMO_member] ([code_HMO_member], [full_name], [identity_card], [address], [mobile_phone], [phone], [date_birth]) VALUES (2, N'Gal Bitton', N'304856775 ', N'Herzl 5 Jerusalem', N'052741255 ', N'029542147 ', CAST(N'1990-08-12' AS Date))
INSERT [dbo].[HMO_member] ([code_HMO_member], [full_name], [identity_card], [address], [mobile_phone], [phone], [date_birth]) VALUES (3, N'Danny Reshef', N'10245775  ', N'Rothschild 7 Tel Aviv', N'0549775444', N'          ', CAST(N'1974-09-10' AS Date))
INSERT [dbo].[HMO_member] ([code_HMO_member], [full_name], [identity_card], [address], [mobile_phone], [phone], [date_birth]) VALUES (4, N'Shoshana Cohen', N'201452665 ', N'The Flower 6 Netanya', N'0524287512', N'049756214 ', CAST(N'1983-11-04' AS Date))
INSERT [dbo].[HMO_member] ([code_HMO_member], [full_name], [identity_card], [address], [mobile_phone], [phone], [date_birth]) VALUES (5, N'Meni kim', N'204805772 ', N'dgdgd 75ggf', N'          ', N'1234567891', NULL)
INSERT [dbo].[HMO_member] ([code_HMO_member], [full_name], [identity_card], [address], [mobile_phone], [phone], [date_birth]) VALUES (14, N'Jane gol', N'159753951 ', N'ggh7fhfh fgf', N'1234567890', N'1234567890', CAST(N'2022-10-05' AS Date))
INSERT [dbo].[HMO_member] ([code_HMO_member], [full_name], [identity_card], [address], [mobile_phone], [phone], [date_birth]) VALUES (1005, N'Mpg Chg', N'852753951 ', N'Hrab 6', N'0258963741', N'9517894561', CAST(N'1990-06-08' AS Date))
INSERT [dbo].[HMO_member] ([code_HMO_member], [full_name], [identity_card], [address], [mobile_phone], [phone], [date_birth]) VALUES (2005, N'nb gg', N'951753852 ', N'78', N'          ', N'          ', NULL)
INSERT [dbo].[HMO_member] ([code_HMO_member], [full_name], [identity_card], [address], [mobile_phone], [phone], [date_birth]) VALUES (4016, N'hbhb hhhn', N'159753852 ', NULL, NULL, NULL, NULL)
INSERT [dbo].[HMO_member] ([code_HMO_member], [full_name], [identity_card], [address], [mobile_phone], [phone], [date_birth]) VALUES (4017, N'Daniel Levi', N'205423651 ', N'the rose 12 Tel-Aviv', N'0526485472', N'039457261 ', CAST(N'1984-06-08' AS Date))
SET IDENTITY_INSERT [dbo].[HMO_member] OFF
GO
SET IDENTITY_INSERT [dbo].[manufacturer_table] ON 

INSERT [dbo].[manufacturer_table] ([code_manufacturer], [name_manufacturer]) VALUES (1, N'Pfizer')
INSERT [dbo].[manufacturer_table] ([code_manufacturer], [name_manufacturer]) VALUES (2, N'Moderna')
INSERT [dbo].[manufacturer_table] ([code_manufacturer], [name_manufacturer]) VALUES (3, N'Novavax ')
INSERT [dbo].[manufacturer_table] ([code_manufacturer], [name_manufacturer]) VALUES (4, N'Astrazeneca')
SET IDENTITY_INSERT [dbo].[manufacturer_table] OFF
GO
INSERT [dbo].[positive_corona_member] ([code_HMO_member], [date_recovery_corona], [date_positive_corona]) VALUES (1, CAST(N'2020-12-12' AS Date), CAST(N'2020-06-25' AS Date))
INSERT [dbo].[positive_corona_member] ([code_HMO_member], [date_recovery_corona], [date_positive_corona]) VALUES (2, CAST(N'2021-06-05' AS Date), CAST(N'2020-06-25' AS Date))
INSERT [dbo].[positive_corona_member] ([code_HMO_member], [date_recovery_corona], [date_positive_corona]) VALUES (4, NULL, CAST(N'2020-05-25' AS Date))
INSERT [dbo].[positive_corona_member] ([code_HMO_member], [date_recovery_corona], [date_positive_corona]) VALUES (5, NULL, CAST(N'2022-05-25' AS Date))
INSERT [dbo].[positive_corona_member] ([code_HMO_member], [date_recovery_corona], [date_positive_corona]) VALUES (14, NULL, CAST(N'2022-05-25' AS Date))
GO
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (1, CAST(N'2018-05-08' AS Date), 3)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (1, CAST(N'2022-01-21' AS Date), 3)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (1, CAST(N'2022-10-01' AS Date), 2)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (2, CAST(N'2021-01-18' AS Date), 1)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (2, CAST(N'2021-01-21' AS Date), 1)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (3, CAST(N'2020-06-06' AS Date), 1)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (3, CAST(N'2020-09-07' AS Date), 1)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (3, CAST(N'2021-06-08' AS Date), 2)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (3, CAST(N'2022-10-21' AS Date), 1)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (5, CAST(N'2021-06-08' AS Date), 2)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (14, CAST(N'2020-06-06' AS Date), 1)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (14, CAST(N'2021-01-21' AS Date), 2)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (14, CAST(N'2021-06-12' AS Date), 1)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (14, CAST(N'2021-12-21' AS Date), 1)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (1005, CAST(N'2022-10-01' AS Date), 1)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (1005, CAST(N'2022-10-21' AS Date), 1)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (1005, CAST(N'2022-10-22' AS Date), 1)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (2005, CAST(N'2022-10-01' AS Date), 1)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (2005, CAST(N'2022-10-10' AS Date), 1)
INSERT [dbo].[vaccination_member_details] ([code_HMO_member], [vaccination_date], [code_manufacturer]) VALUES (2005, CAST(N'2022-10-15' AS Date), 1)
GO
USE [master]
GO
ALTER DATABASE [CoronaDB] SET  READ_WRITE 
GO
