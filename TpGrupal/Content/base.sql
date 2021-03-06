USE [QEQB06]
GO
/****** Object:  StoredProcedure [dbo].[VerificarSesion]    Script Date: 16/10/2018 09:08:02 ******/
DROP PROCEDURE [dbo].[VerificarSesion]
GO
/****** Object:  StoredProcedure [dbo].[sp_VerUsuario]    Script Date: 16/10/2018 09:08:02 ******/
DROP PROCEDURE [dbo].[sp_VerUsuario]
GO
/****** Object:  StoredProcedure [dbo].[sp_VerificarAdmin]    Script Date: 16/10/2018 09:08:02 ******/
DROP PROCEDURE [dbo].[sp_VerificarAdmin]
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarUsuario]    Script Date: 16/10/2018 09:08:02 ******/
DROP PROCEDURE [dbo].[sp_RegistrarUsuario]
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerRango]    Script Date: 16/10/2018 09:08:02 ******/
DROP PROCEDURE [dbo].[sp_ObtenerRango]
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarUsuario]    Script Date: 16/10/2018 09:08:02 ******/
DROP PROCEDURE [dbo].[sp_ModificarUsuario]
GO
/****** Object:  StoredProcedure [dbo].[sp_LoginUsuario]    Script Date: 16/10/2018 09:08:02 ******/
DROP PROCEDURE [dbo].[sp_LoginUsuario]
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarUsuario]    Script Date: 16/10/2018 09:08:02 ******/
DROP PROCEDURE [dbo].[sp_EliminarUsuario]
GO
/****** Object:  StoredProcedure [dbo].[Logout]    Script Date: 16/10/2018 09:08:02 ******/
DROP PROCEDURE [dbo].[Logout]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/10/2018 09:08:02 ******/
DROP TABLE [dbo].[Usuarios]
GO
/****** Object:  Table [dbo].[RankXBitcoins]    Script Date: 16/10/2018 09:08:02 ******/
DROP TABLE [dbo].[RankXBitcoins]
GO
/****** Object:  Table [dbo].[RankingXVic]    Script Date: 16/10/2018 09:08:02 ******/
DROP TABLE [dbo].[RankingXVic]
GO
/****** Object:  Table [dbo].[Pregunta]    Script Date: 16/10/2018 09:08:02 ******/
DROP TABLE [dbo].[Pregunta]
GO
/****** Object:  Table [dbo].[Personajes]    Script Date: 16/10/2018 09:08:02 ******/
DROP TABLE [dbo].[Personajes]
GO
/****** Object:  Table [dbo].[Partida]    Script Date: 16/10/2018 09:08:02 ******/
DROP TABLE [dbo].[Partida]
GO
/****** Object:  Table [dbo].[Detalle]    Script Date: 16/10/2018 09:08:02 ******/
DROP TABLE [dbo].[Detalle]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 16/10/2018 09:08:02 ******/
DROP TABLE [dbo].[Categorias]
GO
/****** Object:  User [QEQB06]    Script Date: 16/10/2018 09:08:02 ******/
DROP USER [QEQB06]
GO
USE [master]
GO
/****** Object:  Database [QEQB06]    Script Date: 16/10/2018 09:08:02 ******/
DROP DATABASE [QEQB06]
GO
/****** Object:  Database [QEQB06]    Script Date: 16/10/2018 09:08:02 ******/
CREATE DATABASE [QEQB06]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QEQB06', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QEQB06.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QEQB06_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QEQB06_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QEQB06] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QEQB06].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QEQB06] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QEQB06] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QEQB06] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QEQB06] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QEQB06] SET ARITHABORT OFF 
GO
ALTER DATABASE [QEQB06] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QEQB06] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QEQB06] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QEQB06] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QEQB06] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QEQB06] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QEQB06] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QEQB06] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QEQB06] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QEQB06] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QEQB06] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QEQB06] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QEQB06] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QEQB06] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QEQB06] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QEQB06] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QEQB06] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QEQB06] SET RECOVERY FULL 
GO
ALTER DATABASE [QEQB06] SET  MULTI_USER 
GO
ALTER DATABASE [QEQB06] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QEQB06] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QEQB06] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QEQB06] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QEQB06] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QEQB06', N'ON'
GO
ALTER DATABASE [QEQB06] SET QUERY_STORE = OFF
GO
USE [QEQB06]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [QEQB06]
GO
/****** Object:  User [QEQB06]    Script Date: 16/10/2018 09:08:02 ******/
CREATE USER [QEQB06] FOR LOGIN [QEQB06] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [QEQB06]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 16/10/2018 09:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle]    Script Date: 16/10/2018 09:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle](
	[IdDetalle] [int] NOT NULL,
	[IdPersonaje] [int] NOT NULL,
	[Atributo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Detalle] PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partida]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partida](
	[IDPartida] [int] NOT NULL,
	[Ganador] [int] NOT NULL,
	[Perdedor] [int] NOT NULL,
 CONSTRAINT [PK_Partida] PRIMARY KEY CLUSTERED 
(
	[IDPartida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personajes]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personajes](
	[IdPersonaje] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Categoria] [int] NOT NULL,
	[Imagen] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Personajes] PRIMARY KEY CLUSTERED 
(
	[IdPersonaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pregunta]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pregunta](
	[IDAtributo] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Pregunta] PRIMARY KEY CLUSTERED 
(
	[IDAtributo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RankingXVic]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RankingXVic](
	[IDRanking] [int] NOT NULL,
	[Puntaje] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RankingXVic] PRIMARY KEY CLUSTERED 
(
	[IDRanking] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RankXBitcoins]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RankXBitcoins](
	[IDRank] [int] NOT NULL,
	[Puntaje] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RankXBitcoins] PRIMARY KEY CLUSTERED 
(
	[IDRank] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
	[Mail] [varchar](50) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Bitcoins] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IDUsuario], [Nombre], [Contraseña], [Mail], [Tipo], [Bitcoins], [Activo]) VALUES (1, N'Guest', N'úÎƒî0½Èù‚Ì”âè’"E.', N'Guest', N'Usuario', 0, 0)
INSERT [dbo].[Usuarios] ([IDUsuario], [Nombre], [Contraseña], [Mail], [Tipo], [Bitcoins], [Activo]) VALUES (2, N'Nicolás', N'å×mô§}š¤Wìô‘Gcb˜', N'garnicanicolas32@gmail.com', N'Admin', 0, 1)
INSERT [dbo].[Usuarios] ([IDUsuario], [Nombre], [Contraseña], [Mail], [Tipo], [Bitcoins], [Activo]) VALUES (3, N'Juan', N' ‹ÊµÉ¯¬''}i5æ½†¾ž', N'juanchi.zulu@gmail.com', N'Usuario', 0, 0)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  StoredProcedure [dbo].[Logout]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Logout]
as
update Usuarios set Activo = 0 where Usuarios.Activo = 1
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarUsuario]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EliminarUsuario]
@pIdUsuario int
as
Delete from Usuarios where IdUsuario = @pIdUsuario
GO
/****** Object:  StoredProcedure [dbo].[sp_LoginUsuario]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_LoginUsuario]
@pMail varchar(50),
@pContraseña varchar(50)
as
Declare @pVer Varchar(50)
set @pVer = (select Mail from Usuarios where Mail = @pMail and Contraseña = hashbytes('SHA1',@pContraseña))
declare @pBool bit = 0 
if (@pVer = @pMail)
begin
declare @pId int = (select Usuarios.IDUsuario from Usuarios where Mail = @pMail and Contraseña = hashbytes('SHA1',@pContraseña))
update Usuarios set Activo = 1 where Usuarios.IDUsuario = @pId
set @pBool = 1
end
Select @pBool
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarUsuario]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_ModificarUsuario]
@pMail varchar(100),
@pNombre varchar(50),
@pContraseña varchar(50),
@pIdUsuario int
as
Update Usuarios set Nombre = @pNombre,Contraseña = HASHBYTES('SHA1', @pContraseña),Mail = @pMail
where Usuarios.IDUsuario = @pIdUsuario
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerRango]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ObtenerRango]

@ID int

AS

SELECT Tipo FROM Usuarios WHERE IDUsuario = @ID
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarUsuario]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_RegistrarUsuario]
@pMail varchar(100),
@pNombre varchar(50),
@pContraseña varchar(50)
as
insert into Usuarios(Nombre, Contraseña, Mail, Tipo, Bitcoins,Activo) values(@pNombre, HASHBYTES('SHA1', @pContraseña), @pMail, 'Usuario', 0, 0)
GO
/****** Object:  StoredProcedure [dbo].[sp_VerificarAdmin]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_VerificarAdmin]
AS 
declare @pActivo int = 0
set @pActivo = (select IDUsuario from Usuarios where Activo = 1)
if (@pActivo > 0)
begin
select Usuarios.Tipo from Usuarios where @pActivo = IDUsuario
end 
GO
/****** Object:  StoredProcedure [dbo].[sp_VerUsuario]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_VerUsuario]
@pIdUsuario int
as
select * from Usuarios where IdUsuario = @pIdUsuario
GO
/****** Object:  StoredProcedure [dbo].[VerificarSesion]    Script Date: 16/10/2018 09:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[VerificarSesion]
as
select Usuarios.IDUsuario from Usuarios where Usuarios.Activo = 1
 
GO
USE [master]
GO
ALTER DATABASE [QEQB06] SET  READ_WRITE 
GO
