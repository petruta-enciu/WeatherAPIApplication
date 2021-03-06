USE [master]
GO
/****** Object:  Database [weather]    Script Date: 05/29/2013 15:02:37 ******/
CREATE DATABASE [weather] ON  PRIMARY 
( NAME = N'weather', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\weather.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'weather_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\weather_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [weather] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [weather].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [weather] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [weather] SET ANSI_NULLS OFF
GO
ALTER DATABASE [weather] SET ANSI_PADDING OFF
GO
ALTER DATABASE [weather] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [weather] SET ARITHABORT OFF
GO
ALTER DATABASE [weather] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [weather] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [weather] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [weather] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [weather] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [weather] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [weather] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [weather] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [weather] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [weather] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [weather] SET  DISABLE_BROKER
GO
ALTER DATABASE [weather] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [weather] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [weather] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [weather] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [weather] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [weather] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [weather] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [weather] SET  READ_WRITE
GO
ALTER DATABASE [weather] SET RECOVERY SIMPLE
GO
ALTER DATABASE [weather] SET  MULTI_USER
GO
ALTER DATABASE [weather] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [weather] SET DB_CHAINING OFF
GO
USE [weather]
GO
/****** Object:  Table [dbo].[user]    Script Date: 05/29/2013 15:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](255) NULL,
	[user_passwd] [varchar](32) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[provider]    Script Date: 05/29/2013 15:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[provider](
	[id_provider] [int] IDENTITY(1,1) NOT NULL,
	[provider_label] [varchar](32) NULL,
	[provider_url] [varchar](255) NULL,
	[provider_key] [varchar](255) NULL,
 CONSTRAINT [PK_provider] PRIMARY KEY CLUSTERED 
(
	[id_provider] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[jobtype]    Script Date: 05/29/2013 15:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[jobtype](
	[id_jobtype] [int] IDENTITY(1,1) NOT NULL,
	[jobtype_label] [varchar](30) NULL,
 CONSTRAINT [PK_jobtype] PRIMARY KEY CLUSTERED 
(
	[id_jobtype] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[jobstatus]    Script Date: 05/29/2013 15:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[jobstatus](
	[id_jobstatus] [int] IDENTITY(1,1) NOT NULL,
	[jostatus_label] [varchar](32) NULL,
 CONSTRAINT [PK_jobstatus] PRIMARY KEY CLUSTERED 
(
	[id_jobstatus] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[joblogtype]    Script Date: 05/29/2013 15:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[joblogtype](
	[id_joblogtype] [int] IDENTITY(1,1) NOT NULL,
	[joblogtype_label] [varchar](32) NULL,
 CONSTRAINT [PK_joblogtype] PRIMARY KEY CLUSTERED 
(
	[id_joblogtype] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[joblog]    Script Date: 05/29/2013 15:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[joblog](
	[id_jobexec] [int] IDENTITY(1,1) NOT NULL,
	[id_city] [int] NULL,
	[id_joblogtype] [int] NULL,
	[joblog_text] [text] NULL,
 CONSTRAINT [PK_joblog] PRIMARY KEY CLUSTERED 
(
	[id_jobexec] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[jobexec]    Script Date: 05/29/2013 15:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jobexec](
	[id_jobexec] [int] IDENTITY(1,1) NOT NULL,
	[id_job] [int] NULL,
	[id_jobstatus] [int] NULL,
	[jobexec_start] [datetime] NULL,
	[jobexec_end] [datetime] NULL,
 CONSTRAINT [PK_jobexec] PRIMARY KEY CLUSTERED 
(
	[id_jobexec] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[job_city]    Script Date: 05/29/2013 15:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[job_city](
	[id_job] [int] IDENTITY(1,1) NOT NULL,
	[id_city] [int] NULL,
 CONSTRAINT [PK_job_city] PRIMARY KEY CLUSTERED 
(
	[id_job] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[job]    Script Date: 05/29/2013 15:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[job](
	[id_job] [int] IDENTITY(1,1) NOT NULL,
	[id_jobtype] [int] NULL,
	[id_user] [varchar](32) NULL,
	[job_label] [varchar](32) NULL,
	[job_hour] [varchar](8) NULL,
	[job_dayofweek] [int] NULL,
	[job_dayofmonth] [int] NULL,
	[id_ftp] [int] NULL,
	[ftp_path] [varchar](255) NULL,
	[ftp_filename] [varchar](255) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ftp]    Script Date: 05/29/2013 15:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ftp](
	[id_ftp] [int] IDENTITY(1,1) NOT NULL,
	[ftp_host] [varchar](32) NULL,
	[ftp_port] [int] NULL,
	[ftp_user] [varchar](32) NULL,
	[ftp_passive] [tinyint] NULL,
 CONSTRAINT [PK_ftp] PRIMARY KEY CLUSTERED 
(
	[id_ftp] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[conversiontype]    Script Date: 05/29/2013 15:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[conversiontype](
	[id_conversiontype] [int] IDENTITY(1,1) NOT NULL,
	[conversiontype_label] [varchar](32) NULL,
	[conversiontype_field] [varchar](32) NULL,
 CONSTRAINT [PK_conversiontype] PRIMARY KEY CLUSTERED 
(
	[id_conversiontype] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[conversion]    Script Date: 05/29/2013 15:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[conversion](
	[id_conversion] [int] IDENTITY(1,1) NOT NULL,
	[id_conversiontype] [int] NULL,
	[conversion_source] [varchar](255) NULL,
	[conversion_destination] [varchar](255) NULL,
 CONSTRAINT [PK_conversion] PRIMARY KEY CLUSTERED 
(
	[id_conversion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[city_weather]    Script Date: 05/29/2013 15:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[city_weather](
	[id_provider] [int] IDENTITY(1,1) NOT NULL,
	[id_city] [int] NULL,
	[weather_date] [date] NULL,
	[weather_hour] [varchar](8) NULL,
	[weather_sunrise] [varchar](8) NULL,
	[weather_sunset] [varchar](8) NULL,
	[weather_temperature_low_c] [int] NULL,
	[weather_temperature_high_c] [int] NULL,
	[weather_temperature_low_f] [int] NULL,
	[weather_temperature_high_f] [int] NULL,
	[weather_icon] [varchar](255) NULL,
	[weather_skyicon] [varchar](255) NULL,
	[weather_condition] [varchar](255) NULL,
	[id_joblog] [int] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[id_provider] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[city]    Script Date: 05/29/2013 15:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[city](
	[id_city] [int] IDENTITY(1,1) NOT NULL,
	[city_name] [varchar](64) NULL,
	[city_provider] [varchar](64) NULL,
	[city_countrycode] [varchar](8) NULL,
 CONSTRAINT [PK_city] PRIMARY KEY CLUSTERED 
(
	[id_city] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
