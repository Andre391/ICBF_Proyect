SQL SERVER

USE [master]
GO
/****** Object:  Database [db_icbf]    Script Date: 26/06/2024 11:19:44 p. m. ******/
CREATE DATABASE [db_icbf]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_icbf_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER03\MSSQL\DATA\db_icbf.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_icbf_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER03\MSSQL\DATA\db_icbf.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [db_icbf] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_icbf].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_icbf] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_icbf] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_icbf] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_icbf] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_icbf] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_icbf] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_icbf] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_icbf] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_icbf] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_icbf] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_icbf] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_icbf] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_icbf] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_icbf] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_icbf] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_icbf] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_icbf] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_icbf] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_icbf] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_icbf] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_icbf] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_icbf] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_icbf] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_icbf] SET  MULTI_USER 
GO
ALTER DATABASE [db_icbf] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_icbf] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_icbf] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_icbf] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_icbf] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_icbf] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_icbf', N'ON'
GO
ALTER DATABASE [db_icbf] SET QUERY_STORE = ON
GO
ALTER DATABASE [db_icbf] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [db_icbf]
GO
/****** Object:  Table [dbo].[Asistencias]    Script Date: 26/06/2024 11:19:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistencias](
	[PkId_Asistencia] [int] IDENTITY(1,1) NOT NULL,
	[Fk_NUIP] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Estado_Nino] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Asistencias] PRIMARY KEY CLUSTERED 
(
	[PkId_Asistencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvanceAcademico]    Script Date: 26/06/2024 11:19:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvanceAcademico](
	[PkId_AvanceAcademico] [int] IDENTITY(1,1) NOT NULL,
	[Fk_NUIP] [int] NOT NULL,
	[Nivel] [varchar](50) NOT NULL,
	[Notas] [char](2) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Fecha_Entrega] [date] NOT NULL,
 CONSTRAINT [PK_AvanceAcademico] PRIMARY KEY CLUSTERED 
(
	[PkId_AvanceAcademico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jardines]    Script Date: 26/06/2024 11:19:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jardines](
	[PkId_Jardin] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Jardines] PRIMARY KEY CLUSTERED 
(
	[PkId_Jardin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ninos]    Script Date: 26/06/2024 11:19:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ninos](
	[Pk_NUIP] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Fecha_Nacimiento] [date] NOT NULL,
	[Tipo_Sangre] [varchar](4) NOT NULL,
	[Departamento] [varchar](50) NOT NULL,
	[Ciudad] [varchar](50) NOT NULL,
	[FkId_Usuario] [int] NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[EPS] [varchar](50) NOT NULL,
	[FkId_Jardin] [int] NOT NULL,
 CONSTRAINT [PK_Ninos] PRIMARY KEY CLUSTERED 
(
	[Pk_NUIP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 26/06/2024 11:19:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[PkId_Rol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Rol] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[PkId_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 26/06/2024 11:19:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[PkId_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Usuario] [varchar](50) NOT NULL,
	[Contrasena] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Cedula] [varchar](10) NOT NULL,
	[Telefono] [varchar](10) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Fecha_Nacimiento] [date] NOT NULL,
	[FkId_Rol] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[PkId_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asistencias]  WITH CHECK ADD  CONSTRAINT [FK_Asistencias_Ninos] FOREIGN KEY([Fk_NUIP])
REFERENCES [dbo].[Ninos] ([Pk_NUIP])
GO
ALTER TABLE [dbo].[Asistencias] CHECK CONSTRAINT [FK_Asistencias_Ninos]
GO
ALTER TABLE [dbo].[AvanceAcademico]  WITH CHECK ADD  CONSTRAINT [FK_AvanceAcademico_Ninos] FOREIGN KEY([Fk_NUIP])
REFERENCES [dbo].[Ninos] ([Pk_NUIP])
GO
ALTER TABLE [dbo].[AvanceAcademico] CHECK CONSTRAINT [FK_AvanceAcademico_Ninos]
GO
ALTER TABLE [dbo].[Ninos]  WITH CHECK ADD  CONSTRAINT [FK_Ninos_Jardines] FOREIGN KEY([FkId_Jardin])
REFERENCES [dbo].[Jardines] ([PkId_Jardin])
GO
ALTER TABLE [dbo].[Ninos] CHECK CONSTRAINT [FK_Ninos_Jardines]
GO
ALTER TABLE [dbo].[Ninos]  WITH CHECK ADD  CONSTRAINT [FK_Ninos_Usuarios] FOREIGN KEY([FkId_Usuario])
REFERENCES [dbo].[Usuarios] ([PkId_Usuario])
GO
ALTER TABLE [dbo].[Ninos] CHECK CONSTRAINT [FK_Ninos_Usuarios]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([FkId_Rol])
REFERENCES [dbo].[Roles] ([PkId_Rol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
USE [master]
GO
ALTER DATABASE [db_icbf] SET  READ_WRITE 
GO
