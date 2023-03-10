USE [master]
GO
/****** Object:  Database [BD_Sistema_Logitica]    Script Date: 22/11/2022 22:54:27 ******/
CREATE DATABASE [BD_Sistema_Logitica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_Sistema_Logitica', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BD_Sistema_Logitica.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_Sistema_Logitica_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BD_Sistema_Logitica_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BD_Sistema_Logitica] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_Sistema_Logitica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_Sistema_Logitica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET  MULTI_USER 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_Sistema_Logitica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BD_Sistema_Logitica] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BD_Sistema_Logitica] SET QUERY_STORE = OFF
GO
USE [BD_Sistema_Logitica]
GO
/****** Object:  UserDefinedTableType [dbo].[Ty_detalle_ep]    Script Date: 22/11/2022 22:54:27 ******/
CREATE TYPE [dbo].[Ty_detalle_ep] AS TABLE(
	[descripcion_pr] [varchar](100) NULL,
	[descripcion_ma] [varchar](40) NULL,
	[descripcion_um] [varchar](20) NULL,
	[cantidad] [decimal](10, 2) NULL,
	[pu_compra] [decimal](10, 2) NULL,
	[total] [decimal](10, 2) NULL,
	[codigo_pr] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Ty_detalle_sp]    Script Date: 22/11/2022 22:54:27 ******/
CREATE TYPE [dbo].[Ty_detalle_sp] AS TABLE(
	[descripcion_pr] [varchar](100) NULL,
	[descripcion_ma] [varchar](40) NULL,
	[descripcion_um] [varchar](20) NULL,
	[cantidad] [decimal](10, 2) NULL,
	[pu_venta] [decimal](10, 2) NULL,
	[total] [decimal](10, 2) NULL,
	[codigo_pr] [int] NULL
)
GO
/****** Object:  Table [dbo].[ALMACENES]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ALMACENES](
	[codigo_al] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_al] [varchar](50) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Almacenes] PRIMARY KEY CLUSTERED 
(
	[codigo_al] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIAS](
	[codigo_ca] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_ca] [varchar](50) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
	[codigo_ca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CIUDADES]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CIUDADES](
	[codigo_ci] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_ci] [varchar](100) NULL,
	[codigo_po] [int] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_CIUDAD] PRIMARY KEY CLUSTERED 
(
	[codigo_ci] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTES]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTES](
	[codigo_cl] [int] IDENTITY(1,1) NOT NULL,
	[codigo_tdpc] [int] NULL,
	[nrodocumento_cl] [varchar](20) NULL,
	[razon_social_cl] [varchar](150) NULL,
	[nombres] [varchar](100) NULL,
	[apellidos] [varchar](100) NULL,
	[codigo_sx] [int] NULL,
	[codigo_ru] [int] NULL,
	[email_cl] [varchar](150) NULL,
	[telefono_cl] [varchar](20) NULL,
	[celular_cl] [varchar](20) NULL,
	[direccion_cl] [text] NULL,
	[codigo_ci] [nchar](10) NULL,
	[observacion_cl] [text] NULL,
	[fecha_crea] [datetime] NULL,
	[fecha_modifica] [datetime] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_CLIENTES] PRIMARY KEY CLUSTERED 
(
	[codigo_cl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DET_ENTRADA_PRODUCTOS]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DET_ENTRADA_PRODUCTOS](
	[codigo_ep] [int] NOT NULL,
	[codigo_pr] [int] NULL,
	[cantidad] [decimal](10, 2) NULL,
	[pu_compra] [decimal](10, 2) NULL,
	[total] [decimal](10, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DET_SALIDA_PRODUCTOS]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DET_SALIDA_PRODUCTOS](
	[codigo_sp] [int] NULL,
	[codigo_pr] [int] NULL,
	[cantidad] [decimal](10, 2) NULL,
	[pu_venta] [decimal](10, 2) NULL,
	[total] [decimal](10, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ENC_ENTRADA_PRODUCTOS]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ENC_ENTRADA_PRODUCTOS](
	[codigo_ep] [int] IDENTITY(1,1) NOT NULL,
	[codigo_tde] [int] NULL,
	[nrodocumento_ep] [varchar](30) NULL,
	[codigo_pv] [int] NULL,
	[fecha_ep] [date] NULL,
	[codgo_al] [int] NULL,
	[observacionnes_ep] [text] NULL,
	[subtotal] [decimal](10, 2) NULL,
	[iva] [decimal](10, 2) NULL,
	[total_importe] [decimal](10, 2) NULL,
	[fecha_crea] [datetime] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_ENC_ENTRADA_PRODUCTOS] PRIMARY KEY CLUSTERED 
(
	[codigo_ep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ENC_SALIDA_PRODUCTOS]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ENC_SALIDA_PRODUCTOS](
	[codigo_sp] [int] IDENTITY(1,1) NOT NULL,
	[codigo_tde] [int] NULL,
	[nrodocumento_sp] [varchar](30) NULL,
	[codigo_cl] [int] NULL,
	[nrodocumento_cl] [varchar](20) NULL,
	[razonsocial_cl] [varchar](150) NULL,
	[fecha_sp] [date] NULL,
	[observacion_sp] [text] NULL,
	[subtotal] [decimal](10, 2) NULL,
	[iva] [decimal](10, 2) NULL,
	[total_importe] [decimal](10, 2) NULL,
	[fecha_crea] [datetime] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_ENC_SALIDA_PRODUCTOS] PRIMARY KEY CLUSTERED 
(
	[codigo_sp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MARCAS]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MARCAS](
	[codigo_ma] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_ma] [varchar](50) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_MARCAS] PRIMARY KEY CLUSTERED 
(
	[codigo_ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulo](
	[id_modulo] [int] IDENTITY(1,1) NOT NULL,
	[ModuloNombre] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Modulo] PRIMARY KEY CLUSTERED 
(
	[id_modulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Opcion]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Opcion](
	[Id_opcion] [int] IDENTITY(1,1) NOT NULL,
	[opcion_nombre] [varchar](30) NOT NULL,
	[modulo_id] [int] NOT NULL,
 CONSTRAINT [PK_Opcion] PRIMARY KEY CLUSTERED 
(
	[Id_opcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAISES]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAISES](
	[codigo_pa] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_pa] [varchar](100) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_PAIS] PRIMARY KEY CLUSTERED 
(
	[codigo_pa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[IdPermisos] [int] IDENTITY(1,1) NOT NULL,
	[RolUsuid] [int] NOT NULL,
	[opcion_id] [int] NOT NULL,
	[permitido] [bit] NOT NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[IdPermisos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTOS]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTOS](
	[codigo_pr] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[codigo_ma] [int] NULL,
	[codigo_um] [int] NOT NULL,
	[codigo_ca] [int] NOT NULL,
	[stock_min] [decimal](10, 2) NULL,
	[stock_max] [decimal](10, 2) NULL,
	[pu_venta] [decimal](10, 2) NULL,
	[fecha_crea] [datetime] NULL,
	[fecha_modifica] [datetime] NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_PRODUCTOS] PRIMARY KEY CLUSTERED 
(
	[codigo_pr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROVEEDORES]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROVEEDORES](
	[codigo_pv] [int] IDENTITY(1,1) NOT NULL,
	[codigo_tdpc] [int] NULL,
	[nrodocumento_pv] [varchar](20) NULL,
	[razon_social_pv] [varchar](150) NULL,
	[nombres] [varchar](100) NULL,
	[apellidos] [varchar](100) NULL,
	[codigo_sx] [int] NULL,
	[codigo_ru] [int] NULL,
	[email_pv] [varchar](150) NULL,
	[telefono] [varchar](20) NULL,
	[celular] [varchar](20) NULL,
	[direccion_pv] [text] NULL,
	[codigo_ci] [int] NULL,
	[observacion_pv] [text] NULL,
	[fecha_crea] [datetime] NULL,
	[fecha_modifica] [datetime] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_PROVEEDORES] PRIMARY KEY CLUSTERED 
(
	[codigo_pv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROVINCIAS]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROVINCIAS](
	[codigo_po] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_po] [varchar](100) NULL,
	[codigo_pa] [int] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_PROVINCIAS] PRIMARY KEY CLUSTERED 
(
	[codigo_po] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol_Usuario]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol_Usuario](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[RolNombre] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Rol_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RUBROS]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RUBROS](
	[codigo_ru] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_ru] [varchar](60) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_RUBROS] PRIMARY KEY CLUSTERED 
(
	[codigo_ru] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SEXOS]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEXOS](
	[codigo_sx] [int] IDENTITY(0,1) NOT NULL,
	[descripcion_sx] [varchar](20) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_SEXOS] PRIMARY KEY CLUSTERED 
(
	[codigo_sx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STOCK_PRODUCTOS]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STOCK_PRODUCTOS](
	[codigo_pr] [int] NULL,
	[codigo_al] [int] NULL,
	[stock_actual] [decimal](10, 2) NULL,
	[pu_compra] [decimal](10, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPOS_DOCUMENTOS_EMITIR]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPOS_DOCUMENTOS_EMITIR](
	[codigo_tde] [int] IDENTITY(0,1) NOT NULL,
	[descripcion_tde] [varchar](30) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_TIPOS_DOCUMENTOS_EMITIR] PRIMARY KEY CLUSTERED 
(
	[codigo_tde] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPOS_DOCUMENTOS_PV_CL]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPOS_DOCUMENTOS_PV_CL](
	[codigo_tdpc] [int] IDENTITY(0,1) NOT NULL,
	[descripcion_tdpc] [varchar](30) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_TIPOS_DOCUMENTOS_PV_CL] PRIMARY KEY CLUSTERED 
(
	[codigo_tdpc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UNIDADES_MEDIDAS]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UNIDADES_MEDIDAS](
	[codigo_um] [int] IDENTITY(1,1) NOT NULL,
	[abreviatura_um] [varchar](3) NULL,
	[descripcion_um] [varchar](20) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_UNIDADES_MEDIDAS] PRIMARY KEY CLUSTERED 
(
	[codigo_um] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](30) NULL,
	[password] [varchar](30) NULL,
	[Rol_id] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 22/11/2022 22:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[codigo_us] [int] IDENTITY(1,1) NOT NULL,
	[login_us] [varchar](20) NULL,
	[password_us] [varchar](20) NULL,
	[nombre_us] [varchar](100) NULL,
	[cargo_us] [varchar](50) NULL,
	[admin] [bit] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED 
(
	[codigo_us] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ALMACENES] ON 

INSERT [dbo].[ALMACENES] ([codigo_al], [descripcion_al], [estado]) VALUES (4, N'ALMACEN PRINCIPAL', 1)
INSERT [dbo].[ALMACENES] ([codigo_al], [descripcion_al], [estado]) VALUES (5, N'ALMACEN SECUNDARIO', 1)
SET IDENTITY_INSERT [dbo].[ALMACENES] OFF
GO
SET IDENTITY_INSERT [dbo].[CATEGORIAS] ON 

INSERT [dbo].[CATEGORIAS] ([codigo_ca], [descripcion_ca], [estado]) VALUES (1, N'Almacen', 1)
INSERT [dbo].[CATEGORIAS] ([codigo_ca], [descripcion_ca], [estado]) VALUES (2, N'Bebidas No Alcolicas', 1)
INSERT [dbo].[CATEGORIAS] ([codigo_ca], [descripcion_ca], [estado]) VALUES (3, N'Bebidad Alcoholicas', 1)
INSERT [dbo].[CATEGORIAS] ([codigo_ca], [descripcion_ca], [estado]) VALUES (4, N'Lacteos', 0)
INSERT [dbo].[CATEGORIAS] ([codigo_ca], [descripcion_ca], [estado]) VALUES (5, N'Otros', 1)
SET IDENTITY_INSERT [dbo].[CATEGORIAS] OFF
GO
SET IDENTITY_INSERT [dbo].[CIUDADES] ON 

INSERT [dbo].[CIUDADES] ([codigo_ci], [descripcion_ci], [codigo_po], [estado]) VALUES (2, N'', NULL, 1)
INSERT [dbo].[CIUDADES] ([codigo_ci], [descripcion_ci], [codigo_po], [estado]) VALUES (3, N'ROSARIO', 1, 1)
SET IDENTITY_INSERT [dbo].[CIUDADES] OFF
GO
SET IDENTITY_INSERT [dbo].[CLIENTES] ON 

INSERT [dbo].[CLIENTES] ([codigo_cl], [codigo_tdpc], [nrodocumento_cl], [razon_social_cl], [nombres], [apellidos], [codigo_sx], [codigo_ru], [email_cl], [telefono_cl], [celular_cl], [direccion_cl], [codigo_ci], [observacion_cl], [fecha_crea], [fecha_modifica], [estado]) VALUES (1, 1, N'2228228', N'CLIENTE VARIOS', N'N/s', N'N/s', 0, 1, N'', N'', N'', N'S/D', N'3         ', N'', CAST(N'2022-11-12T09:51:25.843' AS DateTime), CAST(N'2022-11-14T15:28:16.183' AS DateTime), 1)
INSERT [dbo].[CLIENTES] ([codigo_cl], [codigo_tdpc], [nrodocumento_cl], [razon_social_cl], [nombres], [apellidos], [codigo_sx], [codigo_ru], [email_cl], [telefono_cl], [celular_cl], [direccion_cl], [codigo_ci], [observacion_cl], [fecha_crea], [fecha_modifica], [estado]) VALUES (2, 2, N'34344490', N'EMPRESA1', N'', N'', 0, 2, N'', N'', N'', N'mi direccion', N'3         ', N'', CAST(N'2022-11-14T15:29:09.013' AS DateTime), CAST(N'2022-11-14T15:34:46.367' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[CLIENTES] OFF
GO
INSERT [dbo].[DET_ENTRADA_PRODUCTOS] ([codigo_ep], [codigo_pr], [cantidad], [pu_compra], [total]) VALUES (1, 6, CAST(15.00 AS Decimal(10, 2)), CAST(120.00 AS Decimal(10, 2)), CAST(1800.00 AS Decimal(10, 2)))
INSERT [dbo].[DET_ENTRADA_PRODUCTOS] ([codigo_ep], [codigo_pr], [cantidad], [pu_compra], [total]) VALUES (1, 5, CAST(23.00 AS Decimal(10, 2)), CAST(180.00 AS Decimal(10, 2)), CAST(4140.00 AS Decimal(10, 2)))
INSERT [dbo].[DET_ENTRADA_PRODUCTOS] ([codigo_ep], [codigo_pr], [cantidad], [pu_compra], [total]) VALUES (2, 6, CAST(10.00 AS Decimal(10, 2)), CAST(320.00 AS Decimal(10, 2)), CAST(3200.00 AS Decimal(10, 2)))
INSERT [dbo].[DET_ENTRADA_PRODUCTOS] ([codigo_ep], [codigo_pr], [cantidad], [pu_compra], [total]) VALUES (3, 6, CAST(21.00 AS Decimal(10, 2)), CAST(1222.00 AS Decimal(10, 2)), CAST(25662.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[DET_SALIDA_PRODUCTOS] ([codigo_sp], [codigo_pr], [cantidad], [pu_venta], [total]) VALUES (2, 5, CAST(1.00 AS Decimal(10, 2)), CAST(150.00 AS Decimal(10, 2)), CAST(150.00 AS Decimal(10, 2)))
INSERT [dbo].[DET_SALIDA_PRODUCTOS] ([codigo_sp], [codigo_pr], [cantidad], [pu_venta], [total]) VALUES (3, 5, CAST(3.00 AS Decimal(10, 2)), CAST(150.00 AS Decimal(10, 2)), CAST(450.00 AS Decimal(10, 2)))
GO
SET IDENTITY_INSERT [dbo].[ENC_ENTRADA_PRODUCTOS] ON 

INSERT [dbo].[ENC_ENTRADA_PRODUCTOS] ([codigo_ep], [codigo_tde], [nrodocumento_ep], [codigo_pv], [fecha_ep], [codgo_al], [observacionnes_ep], [subtotal], [iva], [total_importe], [fecha_crea], [estado]) VALUES (1, 1, N'B-0001', 1, CAST(N'2022-11-11' AS Date), 4, N'Ninguna', CAST(5670.00 AS Decimal(10, 2)), CAST(270.00 AS Decimal(10, 2)), CAST(5940.00 AS Decimal(10, 2)), CAST(N'2022-11-11T15:34:04.920' AS DateTime), 1)
INSERT [dbo].[ENC_ENTRADA_PRODUCTOS] ([codigo_ep], [codigo_tde], [nrodocumento_ep], [codigo_pv], [fecha_ep], [codgo_al], [observacionnes_ep], [subtotal], [iva], [total_importe], [fecha_crea], [estado]) VALUES (2, 2, N'Fact-001', 1, CAST(N'2022-11-11' AS Date), 4, N'-----', CAST(3054.55 AS Decimal(10, 2)), CAST(145.45 AS Decimal(10, 2)), CAST(3200.00 AS Decimal(10, 2)), CAST(N'2022-11-11T15:41:57.387' AS DateTime), 1)
INSERT [dbo].[ENC_ENTRADA_PRODUCTOS] ([codigo_ep], [codigo_tde], [nrodocumento_ep], [codigo_pv], [fecha_ep], [codgo_al], [observacionnes_ep], [subtotal], [iva], [total_importe], [fecha_crea], [estado]) VALUES (3, 0, N'n/n', 1, CAST(N'2022-11-11' AS Date), 4, N'Nada', CAST(24495.55 AS Decimal(10, 2)), CAST(1166.45 AS Decimal(10, 2)), CAST(25662.00 AS Decimal(10, 2)), CAST(N'2022-11-11T16:14:01.837' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[ENC_ENTRADA_PRODUCTOS] OFF
GO
SET IDENTITY_INSERT [dbo].[ENC_SALIDA_PRODUCTOS] ON 

INSERT [dbo].[ENC_SALIDA_PRODUCTOS] ([codigo_sp], [codigo_tde], [nrodocumento_sp], [codigo_cl], [nrodocumento_cl], [razonsocial_cl], [fecha_sp], [observacion_sp], [subtotal], [iva], [total_importe], [fecha_crea], [estado]) VALUES (1, 2, N'F-0004', 1, N'', N'', CAST(N'2022-11-14' AS Date), N'N/O', CAST(286.36 AS Decimal(10, 2)), CAST(13.64 AS Decimal(10, 2)), CAST(300.00 AS Decimal(10, 2)), CAST(N'2022-11-14T10:57:56.650' AS DateTime), 1)
INSERT [dbo].[ENC_SALIDA_PRODUCTOS] ([codigo_sp], [codigo_tde], [nrodocumento_sp], [codigo_cl], [nrodocumento_cl], [razonsocial_cl], [fecha_sp], [observacion_sp], [subtotal], [iva], [total_importe], [fecha_crea], [estado]) VALUES (2, 1, N'B-223232', 1, N'2228228', N'Cliente1', CAST(N'2022-11-14' AS Date), N'', CAST(143.18 AS Decimal(10, 2)), CAST(6.82 AS Decimal(10, 2)), CAST(150.00 AS Decimal(10, 2)), CAST(N'2022-11-14T11:40:12.243' AS DateTime), 1)
INSERT [dbo].[ENC_SALIDA_PRODUCTOS] ([codigo_sp], [codigo_tde], [nrodocumento_sp], [codigo_cl], [nrodocumento_cl], [razonsocial_cl], [fecha_sp], [observacion_sp], [subtotal], [iva], [total_importe], [fecha_crea], [estado]) VALUES (3, 1, N'B-7667', 2, N'34344490', N'EMPRESA1', CAST(N'2022-11-15' AS Date), N'', CAST(429.55 AS Decimal(10, 2)), CAST(20.45 AS Decimal(10, 2)), CAST(450.00 AS Decimal(10, 2)), CAST(N'2022-11-15T15:29:32.757' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[ENC_SALIDA_PRODUCTOS] OFF
GO
SET IDENTITY_INSERT [dbo].[MARCAS] ON 

INSERT [dbo].[MARCAS] ([codigo_ma], [descripcion_ma], [estado]) VALUES (1, N'Pasta Knork', 0)
INSERT [dbo].[MARCAS] ([codigo_ma], [descripcion_ma], [estado]) VALUES (2, N'Serenisima', 1)
INSERT [dbo].[MARCAS] ([codigo_ma], [descripcion_ma], [estado]) VALUES (3, N'Primera', 1)
SET IDENTITY_INSERT [dbo].[MARCAS] OFF
GO
SET IDENTITY_INSERT [dbo].[Modulo] ON 

INSERT [dbo].[Modulo] ([id_modulo], [ModuloNombre]) VALUES (1, N'DATOS')
INSERT [dbo].[Modulo] ([id_modulo], [ModuloNombre]) VALUES (2, N'MOVIMIENTOS')
INSERT [dbo].[Modulo] ([id_modulo], [ModuloNombre]) VALUES (3, N'REPORTES')
INSERT [dbo].[Modulo] ([id_modulo], [ModuloNombre]) VALUES (4, N'SISTEMA')
SET IDENTITY_INSERT [dbo].[Modulo] OFF
GO
SET IDENTITY_INSERT [dbo].[Opcion] ON 

INSERT [dbo].[Opcion] ([Id_opcion], [opcion_nombre], [modulo_id]) VALUES (2, N'PRODUCTOS', 1)
INSERT [dbo].[Opcion] ([Id_opcion], [opcion_nombre], [modulo_id]) VALUES (3, N'ALMACEN', 1)
INSERT [dbo].[Opcion] ([Id_opcion], [opcion_nombre], [modulo_id]) VALUES (4, N'CLIENTES_PROVEEDORES', 1)
INSERT [dbo].[Opcion] ([Id_opcion], [opcion_nombre], [modulo_id]) VALUES (5, N'UBICACION', 1)
INSERT [dbo].[Opcion] ([Id_opcion], [opcion_nombre], [modulo_id]) VALUES (6, N'ENTRADAS_PRODUCTOS', 2)
INSERT [dbo].[Opcion] ([Id_opcion], [opcion_nombre], [modulo_id]) VALUES (7, N'SALIDAS_PRODUCTOS', 2)
INSERT [dbo].[Opcion] ([Id_opcion], [opcion_nombre], [modulo_id]) VALUES (8, N'REPORTE_I', 3)
INSERT [dbo].[Opcion] ([Id_opcion], [opcion_nombre], [modulo_id]) VALUES (9, N'REPORTE_S', 3)
INSERT [dbo].[Opcion] ([Id_opcion], [opcion_nombre], [modulo_id]) VALUES (10, N'USUARIOS', 4)
SET IDENTITY_INSERT [dbo].[Opcion] OFF
GO
SET IDENTITY_INSERT [dbo].[PAISES] ON 

INSERT [dbo].[PAISES] ([codigo_pa], [descripcion_pa], [estado]) VALUES (1, N'ARGENTINA', 1)
SET IDENTITY_INSERT [dbo].[PAISES] OFF
GO
SET IDENTITY_INSERT [dbo].[Permisos] ON 

INSERT [dbo].[Permisos] ([IdPermisos], [RolUsuid], [opcion_id], [permitido]) VALUES (1, 1, 10, 1)
INSERT [dbo].[Permisos] ([IdPermisos], [RolUsuid], [opcion_id], [permitido]) VALUES (2, 1, 9, 1)
INSERT [dbo].[Permisos] ([IdPermisos], [RolUsuid], [opcion_id], [permitido]) VALUES (3, 1, 8, 1)
INSERT [dbo].[Permisos] ([IdPermisos], [RolUsuid], [opcion_id], [permitido]) VALUES (4, 1, 7, 1)
INSERT [dbo].[Permisos] ([IdPermisos], [RolUsuid], [opcion_id], [permitido]) VALUES (5, 1, 6, 1)
INSERT [dbo].[Permisos] ([IdPermisos], [RolUsuid], [opcion_id], [permitido]) VALUES (6, 1, 5, 1)
INSERT [dbo].[Permisos] ([IdPermisos], [RolUsuid], [opcion_id], [permitido]) VALUES (7, 1, 4, 1)
INSERT [dbo].[Permisos] ([IdPermisos], [RolUsuid], [opcion_id], [permitido]) VALUES (8, 1, 3, 1)
INSERT [dbo].[Permisos] ([IdPermisos], [RolUsuid], [opcion_id], [permitido]) VALUES (9, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[Permisos] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCTOS] ON 

INSERT [dbo].[PRODUCTOS] ([codigo_pr], [descripcion], [codigo_ma], [codigo_um], [codigo_ca], [stock_min], [stock_max], [pu_venta], [fecha_crea], [fecha_modifica], [estado]) VALUES (5, N'Generico2', 2, 2, 5, CAST(1.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(150.00 AS Decimal(10, 2)), CAST(N'2022-10-30T18:38:10.340' AS DateTime), CAST(N'2022-11-14T09:31:04.197' AS DateTime), 1)
INSERT [dbo].[PRODUCTOS] ([codigo_pr], [descripcion], [codigo_ma], [codigo_um], [codigo_ca], [stock_min], [stock_max], [pu_venta], [fecha_crea], [fecha_modifica], [estado]) VALUES (6, N'Generico', 3, 3, 1, CAST(12.00 AS Decimal(10, 2)), CAST(20.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2022-11-11T11:03:46.303' AS DateTime), CAST(N'2022-11-11T11:03:46.303' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[PRODUCTOS] OFF
GO
SET IDENTITY_INSERT [dbo].[PROVEEDORES] ON 

INSERT [dbo].[PROVEEDORES] ([codigo_pv], [codigo_tdpc], [nrodocumento_pv], [razon_social_pv], [nombres], [apellidos], [codigo_sx], [codigo_ru], [email_pv], [telefono], [celular], [direccion_pv], [codigo_ci], [observacion_pv], [fecha_crea], [fecha_modifica], [estado]) VALUES (1, 1, N'23999111', N'JES', N'Jesus', N'Vega', 1, 2, N'VV@gmail.com', N'4342112', N'112223332', N'AV.Brasil 3002', 3, N'Ninguna', CAST(N'2022-11-07T16:38:55.370' AS DateTime), CAST(N'2022-11-07T17:44:56.090' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[PROVEEDORES] OFF
GO
SET IDENTITY_INSERT [dbo].[PROVINCIAS] ON 

INSERT [dbo].[PROVINCIAS] ([codigo_po], [descripcion_po], [codigo_pa], [estado]) VALUES (1, N'SANTA FE', 1, 1)
INSERT [dbo].[PROVINCIAS] ([codigo_po], [descripcion_po], [codigo_pa], [estado]) VALUES (2, N'CORRIENTES', 1, 1)
SET IDENTITY_INSERT [dbo].[PROVINCIAS] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol_Usuario] ON 

INSERT [dbo].[Rol_Usuario] ([id_rol], [RolNombre]) VALUES (1, N'ADMINISTRACION')
SET IDENTITY_INSERT [dbo].[Rol_Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[RUBROS] ON 

INSERT [dbo].[RUBROS] ([codigo_ru], [descripcion_ru], [estado]) VALUES (1, N'BEBIDAS', 1)
INSERT [dbo].[RUBROS] ([codigo_ru], [descripcion_ru], [estado]) VALUES (2, N'VERDURAS', 1)
SET IDENTITY_INSERT [dbo].[RUBROS] OFF
GO
SET IDENTITY_INSERT [dbo].[SEXOS] ON 

INSERT [dbo].[SEXOS] ([codigo_sx], [descripcion_sx], [estado]) VALUES (0, N'NO DEFINIDO', 1)
INSERT [dbo].[SEXOS] ([codigo_sx], [descripcion_sx], [estado]) VALUES (1, N'MASCULINO', 1)
INSERT [dbo].[SEXOS] ([codigo_sx], [descripcion_sx], [estado]) VALUES (2, N'FEMENINO', 1)
SET IDENTITY_INSERT [dbo].[SEXOS] OFF
GO
INSERT [dbo].[STOCK_PRODUCTOS] ([codigo_pr], [codigo_al], [stock_actual], [pu_compra]) VALUES (5, 4, CAST(17.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
INSERT [dbo].[STOCK_PRODUCTOS] ([codigo_pr], [codigo_al], [stock_actual], [pu_compra]) VALUES (5, 5, CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
INSERT [dbo].[STOCK_PRODUCTOS] ([codigo_pr], [codigo_al], [stock_actual], [pu_compra]) VALUES (6, 4, CAST(-17.00 AS Decimal(10, 2)), CAST(1222.00 AS Decimal(10, 2)))
INSERT [dbo].[STOCK_PRODUCTOS] ([codigo_pr], [codigo_al], [stock_actual], [pu_compra]) VALUES (6, 5, CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
GO
SET IDENTITY_INSERT [dbo].[TIPOS_DOCUMENTOS_EMITIR] ON 

INSERT [dbo].[TIPOS_DOCUMENTOS_EMITIR] ([codigo_tde], [descripcion_tde], [estado]) VALUES (0, N'SIN DOCUMENTO', 1)
INSERT [dbo].[TIPOS_DOCUMENTOS_EMITIR] ([codigo_tde], [descripcion_tde], [estado]) VALUES (1, N'BOLETA', 1)
INSERT [dbo].[TIPOS_DOCUMENTOS_EMITIR] ([codigo_tde], [descripcion_tde], [estado]) VALUES (2, N'FACTURA', 1)
SET IDENTITY_INSERT [dbo].[TIPOS_DOCUMENTOS_EMITIR] OFF
GO
SET IDENTITY_INSERT [dbo].[TIPOS_DOCUMENTOS_PV_CL] ON 

INSERT [dbo].[TIPOS_DOCUMENTOS_PV_CL] ([codigo_tdpc], [descripcion_tdpc], [estado]) VALUES (0, N'SIN DOCUMENTO', 1)
INSERT [dbo].[TIPOS_DOCUMENTOS_PV_CL] ([codigo_tdpc], [descripcion_tdpc], [estado]) VALUES (1, N'DNI', 1)
INSERT [dbo].[TIPOS_DOCUMENTOS_PV_CL] ([codigo_tdpc], [descripcion_tdpc], [estado]) VALUES (2, N'CUIL', 1)
SET IDENTITY_INSERT [dbo].[TIPOS_DOCUMENTOS_PV_CL] OFF
GO
SET IDENTITY_INSERT [dbo].[UNIDADES_MEDIDAS] ON 

INSERT [dbo].[UNIDADES_MEDIDAS] ([codigo_um], [abreviatura_um], [descripcion_um], [estado]) VALUES (1, N'Kg', N'Kilogramos', 0)
INSERT [dbo].[UNIDADES_MEDIDAS] ([codigo_um], [abreviatura_um], [descripcion_um], [estado]) VALUES (2, N'Gr', N'Gramos', 1)
INSERT [dbo].[UNIDADES_MEDIDAS] ([codigo_um], [abreviatura_um], [descripcion_um], [estado]) VALUES (3, N'Kg', N'Kilogramos', 1)
SET IDENTITY_INSERT [dbo].[UNIDADES_MEDIDAS] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id_Usuario], [usuario], [password], [Rol_id]) VALUES (1, N'Jesus', N'12345', 1)
INSERT [dbo].[Usuario] ([id_Usuario], [usuario], [password], [Rol_id]) VALUES (2, N'Jesus', N'12345', 1)
INSERT [dbo].[Usuario] ([id_Usuario], [usuario], [password], [Rol_id]) VALUES (3, N'Jesus', N'12345', 1)
INSERT [dbo].[Usuario] ([id_Usuario], [usuario], [password], [Rol_id]) VALUES (4, N'Jesus', N'12345', 1)
INSERT [dbo].[Usuario] ([id_Usuario], [usuario], [password], [Rol_id]) VALUES (5, N'Jesus', N'12345', 1)
INSERT [dbo].[Usuario] ([id_Usuario], [usuario], [password], [Rol_id]) VALUES (6, N'Jesus', N'12345', 1)
INSERT [dbo].[Usuario] ([id_Usuario], [usuario], [password], [Rol_id]) VALUES (7, N'Jesus', N'12345', 1)
INSERT [dbo].[Usuario] ([id_Usuario], [usuario], [password], [Rol_id]) VALUES (8, N'Jesus', N'12345', 1)
INSERT [dbo].[Usuario] ([id_Usuario], [usuario], [password], [Rol_id]) VALUES (9, N'Jesus', N'12345', 1)
INSERT [dbo].[Usuario] ([id_Usuario], [usuario], [password], [Rol_id]) VALUES (10, N'Jesus', N'12345', 1)
INSERT [dbo].[Usuario] ([id_Usuario], [usuario], [password], [Rol_id]) VALUES (11, N'Jesus', N'12345', 1)
INSERT [dbo].[Usuario] ([id_Usuario], [usuario], [password], [Rol_id]) VALUES (12, N'Jesus', N'12345', 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[USUARIOS] ON 

INSERT [dbo].[USUARIOS] ([codigo_us], [login_us], [password_us], [nombre_us], [cargo_us], [admin], [estado]) VALUES (1, N'JVV', N'12345', N'JESUS VEGA', N'SISTEMAS', 1, 1)
INSERT [dbo].[USUARIOS] ([codigo_us], [login_us], [password_us], [nombre_us], [cargo_us], [admin], [estado]) VALUES (2, N'JW', N'12345', N'Pedro', N'Ventas', 0, 1)
SET IDENTITY_INSERT [dbo].[USUARIOS] OFF
GO
ALTER TABLE [dbo].[CIUDADES]  WITH CHECK ADD  CONSTRAINT [FK_CIUDAD_PROVINCIAS] FOREIGN KEY([codigo_po])
REFERENCES [dbo].[PROVINCIAS] ([codigo_po])
GO
ALTER TABLE [dbo].[CIUDADES] CHECK CONSTRAINT [FK_CIUDAD_PROVINCIAS]
GO
ALTER TABLE [dbo].[DET_ENTRADA_PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_DET_ENTRADA_PRODUCTOS_ENC_ENTRADA_PRODUCTOS] FOREIGN KEY([codigo_ep])
REFERENCES [dbo].[ENC_ENTRADA_PRODUCTOS] ([codigo_ep])
GO
ALTER TABLE [dbo].[DET_ENTRADA_PRODUCTOS] CHECK CONSTRAINT [FK_DET_ENTRADA_PRODUCTOS_ENC_ENTRADA_PRODUCTOS]
GO
ALTER TABLE [dbo].[DET_SALIDA_PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_DET_SALIDA_PRODUCTOS_ENC_SALIDA_PRODUCTOS] FOREIGN KEY([codigo_sp])
REFERENCES [dbo].[ENC_SALIDA_PRODUCTOS] ([codigo_sp])
GO
ALTER TABLE [dbo].[DET_SALIDA_PRODUCTOS] CHECK CONSTRAINT [FK_DET_SALIDA_PRODUCTOS_ENC_SALIDA_PRODUCTOS]
GO
ALTER TABLE [dbo].[ENC_ENTRADA_PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_ENC_ENTRADA_PRODUCTOS_ALMACENES] FOREIGN KEY([codgo_al])
REFERENCES [dbo].[ALMACENES] ([codigo_al])
GO
ALTER TABLE [dbo].[ENC_ENTRADA_PRODUCTOS] CHECK CONSTRAINT [FK_ENC_ENTRADA_PRODUCTOS_ALMACENES]
GO
ALTER TABLE [dbo].[ENC_ENTRADA_PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_ENC_ENTRADA_PRODUCTOS_PROVEEDORES] FOREIGN KEY([codigo_pv])
REFERENCES [dbo].[PROVEEDORES] ([codigo_pv])
GO
ALTER TABLE [dbo].[ENC_ENTRADA_PRODUCTOS] CHECK CONSTRAINT [FK_ENC_ENTRADA_PRODUCTOS_PROVEEDORES]
GO
ALTER TABLE [dbo].[ENC_ENTRADA_PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_ENC_ENTRADA_PRODUCTOS_TIPOS_DOCUMENTOS_EMITIR] FOREIGN KEY([codigo_tde])
REFERENCES [dbo].[TIPOS_DOCUMENTOS_EMITIR] ([codigo_tde])
GO
ALTER TABLE [dbo].[ENC_ENTRADA_PRODUCTOS] CHECK CONSTRAINT [FK_ENC_ENTRADA_PRODUCTOS_TIPOS_DOCUMENTOS_EMITIR]
GO
ALTER TABLE [dbo].[ENC_SALIDA_PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_ENC_SALIDA_PRODUCTOS_CLIENTES] FOREIGN KEY([codigo_cl])
REFERENCES [dbo].[CLIENTES] ([codigo_cl])
GO
ALTER TABLE [dbo].[ENC_SALIDA_PRODUCTOS] CHECK CONSTRAINT [FK_ENC_SALIDA_PRODUCTOS_CLIENTES]
GO
ALTER TABLE [dbo].[Opcion]  WITH CHECK ADD  CONSTRAINT [FK_Opcion_Modulo] FOREIGN KEY([modulo_id])
REFERENCES [dbo].[Modulo] ([id_modulo])
GO
ALTER TABLE [dbo].[Opcion] CHECK CONSTRAINT [FK_Opcion_Modulo]
GO
ALTER TABLE [dbo].[Permisos]  WITH CHECK ADD  CONSTRAINT [FK_Permisos_Opcion] FOREIGN KEY([opcion_id])
REFERENCES [dbo].[Opcion] ([Id_opcion])
GO
ALTER TABLE [dbo].[Permisos] CHECK CONSTRAINT [FK_Permisos_Opcion]
GO
ALTER TABLE [dbo].[Permisos]  WITH CHECK ADD  CONSTRAINT [FK_Permisos_Rol_Usuario] FOREIGN KEY([RolUsuid])
REFERENCES [dbo].[Rol_Usuario] ([id_rol])
GO
ALTER TABLE [dbo].[Permisos] CHECK CONSTRAINT [FK_Permisos_Rol_Usuario]
GO
ALTER TABLE [dbo].[PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTOS_CATEGORIAS] FOREIGN KEY([codigo_ca])
REFERENCES [dbo].[CATEGORIAS] ([codigo_ca])
GO
ALTER TABLE [dbo].[PRODUCTOS] CHECK CONSTRAINT [FK_PRODUCTOS_CATEGORIAS]
GO
ALTER TABLE [dbo].[PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTOS_MARCAS] FOREIGN KEY([codigo_ma])
REFERENCES [dbo].[MARCAS] ([codigo_ma])
GO
ALTER TABLE [dbo].[PRODUCTOS] CHECK CONSTRAINT [FK_PRODUCTOS_MARCAS]
GO
ALTER TABLE [dbo].[PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTOS_UNIDADES_MEDIDAS] FOREIGN KEY([codigo_um])
REFERENCES [dbo].[UNIDADES_MEDIDAS] ([codigo_um])
GO
ALTER TABLE [dbo].[PRODUCTOS] CHECK CONSTRAINT [FK_PRODUCTOS_UNIDADES_MEDIDAS]
GO
ALTER TABLE [dbo].[PROVEEDORES]  WITH CHECK ADD  CONSTRAINT [FK_PROVEEDORES_CIUDADES] FOREIGN KEY([codigo_ci])
REFERENCES [dbo].[CIUDADES] ([codigo_ci])
GO
ALTER TABLE [dbo].[PROVEEDORES] CHECK CONSTRAINT [FK_PROVEEDORES_CIUDADES]
GO
ALTER TABLE [dbo].[PROVEEDORES]  WITH CHECK ADD  CONSTRAINT [FK_PROVEEDORES_RUBROS] FOREIGN KEY([codigo_ru])
REFERENCES [dbo].[RUBROS] ([codigo_ru])
GO
ALTER TABLE [dbo].[PROVEEDORES] CHECK CONSTRAINT [FK_PROVEEDORES_RUBROS]
GO
ALTER TABLE [dbo].[PROVEEDORES]  WITH CHECK ADD  CONSTRAINT [FK_PROVEEDORES_SEXOS] FOREIGN KEY([codigo_sx])
REFERENCES [dbo].[SEXOS] ([codigo_sx])
GO
ALTER TABLE [dbo].[PROVEEDORES] CHECK CONSTRAINT [FK_PROVEEDORES_SEXOS]
GO
ALTER TABLE [dbo].[PROVEEDORES]  WITH CHECK ADD  CONSTRAINT [FK_PROVEEDORES_TIPOS_DOCUMENTOS_PV_CL] FOREIGN KEY([codigo_tdpc])
REFERENCES [dbo].[TIPOS_DOCUMENTOS_PV_CL] ([codigo_tdpc])
GO
ALTER TABLE [dbo].[PROVEEDORES] CHECK CONSTRAINT [FK_PROVEEDORES_TIPOS_DOCUMENTOS_PV_CL]
GO
ALTER TABLE [dbo].[PROVINCIAS]  WITH CHECK ADD  CONSTRAINT [FK_PROVINCIAS_PAIS] FOREIGN KEY([codigo_pa])
REFERENCES [dbo].[PAISES] ([codigo_pa])
GO
ALTER TABLE [dbo].[PROVINCIAS] CHECK CONSTRAINT [FK_PROVINCIAS_PAIS]
GO
ALTER TABLE [dbo].[STOCK_PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_STOCK_PRODUCTOS_ALMACENES] FOREIGN KEY([codigo_al])
REFERENCES [dbo].[ALMACENES] ([codigo_al])
GO
ALTER TABLE [dbo].[STOCK_PRODUCTOS] CHECK CONSTRAINT [FK_STOCK_PRODUCTOS_ALMACENES]
GO
ALTER TABLE [dbo].[STOCK_PRODUCTOS]  WITH CHECK ADD  CONSTRAINT [FK_STOCK_PRODUCTOS_PRODUCTOS] FOREIGN KEY([codigo_pr])
REFERENCES [dbo].[PRODUCTOS] ([codigo_pr])
GO
ALTER TABLE [dbo].[STOCK_PRODUCTOS] CHECK CONSTRAINT [FK_STOCK_PRODUCTOS_PRODUCTOS]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol_Usuario] FOREIGN KEY([Rol_id])
REFERENCES [dbo].[Rol_Usuario] ([id_rol])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarUsuario]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_BuscarUsuario]
@usuario varchar(30),
@contra varchar(30),
@IdUsuario int output

as
begin 
 set nocount on
 begin
 if exists(select * from Usuario where
 usuario=@usuario and password=@contra)
 select @IdUsuario=(select @IdUsuario from Usuario where usuario=@usuario and password=@contra)

 else
 select @IdUsuario=0
 end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ComboRol]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ComboRol]
as
begin
set nocount on
begin
select* from Rol_Usuario

end

end
GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarPermiso]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GuardarPermiso]
@RolId int,
@OpcionId int,
@Permitido bit
as
begin
set nocount on
begin
insert into Permisos(RolUsuid,opcion_id,permitido)
values(@RolId,@OpcionId,@Permitido)
end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_guardarUsuario]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_guardarUsuario]
@Usuario varchar(30),
@Contra varchar(30),
@RolId int

as
begin
 set nocount on
 begin
 insert into Usuario(usuario,password,Rol_id)
 values(@Usuario,@Contra,@RolId)

 End
end
GO
/****** Object:  StoredProcedure [dbo].[spSelectOption]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spSelectOption]
@IdRol int
as
begin 
 set nocount on
 begin
 select *from Permisos where RolUsuid=@IdRol

 
 end
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_al]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Eliminar_al]  
@nCodigo_al int=0  
as   
update ALMACENES set estado=0 where codigo_al=@nCodigo_al
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_ca]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[USP_Eliminar_ca]
@nCodigo_ca int=0
as 
update Categorias set estado=0 where codigo_ca=@nCodigo_ca
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_ci]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
       
create proc [dbo].[USP_Eliminar_ci]      
@nCodigo_ci int=0      
as       
update CIUDADES set estado=0 where Codigo_ci=@nCodigo_ci 
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_cl]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Eliminar_cl]      
@nCodigo_cl int=0      
as       
update CLIENTES set estado=0 where codigo_cl=@nCodigo_cl
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_ep]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Eliminar_ep]        
@nCodigo_ep int=0        
as         
update ENC_ENTRADA_PRODUCTOS set estado=0 where codigo_ep=@nCodigo_ep
--Anulacion
update a set a.stock_actual=(a.stock_actual - b.cantidad) 
from STOCK_PRODUCTOS a  
inner join DET_ENTRADA_PRODUCTOS b on a.codigo_pr=b.codigo_pr  
inner join ENC_ENTRADA_PRODUCTOS c on b.codigo_ep=c.codigo_ep and a.codigo_al=c.codgo_al  
where c.codigo_ep=@nCodigo_ep 
    
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_ma]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_Eliminar_ma]
@nCodigo_ma int=0
as 
update MARCAS set estado=0 where @nCodigo_ma=@nCodigo_ma
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_op]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
create proc [dbo].[USP_Eliminar_op]  
@nCodigo_op int=0  
as   
update Operador set estado=0 where id=@nCodigo_op
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_pa]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
create proc [dbo].[USP_Eliminar_pa]  
@nCodigo_pa int=0  
as   
update PAISES set estado=0 where Codigo_pa=@nCodigo_pa
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_po]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
create proc [dbo].[USP_Eliminar_po]    
@nCodigo_po int=0    
as     
update PROVINCIAS set estado=0 where Codigo_po=@nCodigo_po  
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_pr]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Eliminar_pr]  
@nCodigo_pr int=0  
as   
update PRODUCTOS set estado=0 where codigo_pr=@nCodigo_pr
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_pv]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Eliminar_pv]    
@nCodigo_pv int=0    
as     
update PROVEEDORES set estado=0 where codigo_pv=@nCodigo_pv
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_ru]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Eliminar_ru]  
@nCodigo_ru int=0  
as   
update RUBROS set estado=0 where codigo_ru=@nCodigo_ru
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_sp]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Eliminar_sp]          
@nCodigo_sp int=0          
as           
update ENC_SALIDA_PRODUCTOS set estado=0 where codigo_sp=@nCodigo_sp 
--Anulacion  
update a set a.stock_actual=(a.stock_actual + b.cantidad)   
from STOCK_PRODUCTOS a    
inner join DET_SALIDA_PRODUCTOS b on a.codigo_pr=b.codigo_pr    
inner join ENC_SALIDA_PRODUCTOS c on b.codigo_sp=c.codigo_sp and a.codigo_al=4    --Almacen Principal
where c.codigo_sp=@nCodigo_sp   
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_um]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
  create proc [dbo].[USP_Eliminar_um]  
@nCodigo_um int=0  
as   
update UNIDADES_MEDIDAS set estado=0 where @nCodigo_um=@nCodigo_um
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_us]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
create proc [dbo].[USP_Eliminar_us]    
@nCodigo_us int=0    
as     
update USUARIOS set estado=0 where @nCodigo_us=@nCodigo_us
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_al]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Guardar_al]    
@nOpcion int=0,    
@codigo int,    
@Descripcion varchar(50)    
as   
declare @xCodigo int=0
if @nOpcion=1    
begin     
insert into ALMACENES(descripcion_al,estado)values(@Descripcion,1) 
set @xCodigo=@@IDENTITY
insert into STOCK_PRODUCTOS(codigo_pr,
                            codigo_al,
							stock_actual,
							pu_compra) 
select  codigo_pr,
        @xCodigo,
		0.00,
		0.00

from PRODUCTOS;
end    
else    
begin     
update ALMACENES SET descripcion_al=@Descripcion where codigo_al=@codigo    
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_ca]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Guardar_ca]
@nOpcion int=0,
@codigo int,
@Descripcion varchar(50)
as
if @nOpcion=1
begin 
insert into CATEGORIAS(descripcion_ca,estado)values(@Descripcion,1)	
end
else
begin 
update CATEGORIAS SET descripcion_ca=@Descripcion where codigo_ca=@codigo
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_ci]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
        
Create proc [dbo].[USP_Guardar_ci]      
@nOpcion int=0,      
@codigo int,      
@Descripcion varchar(100),    
@cCodigo_po int=0  
as      
if @nOpcion=1      
begin       
insert into CIUDADES(descripcion_ci,codigo_po,estado)values(@Descripcion,@cCodigo_po,1)       
end      
else      
begin       
update CIUDADES SET descripcion_ci=@Descripcion,   
                      codigo_po=@cCodigo_po  
                  where codigo_ci=@codigo      
end 
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_cl]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Guardar_cl]      
@nOpcion int=0,      
@n_Codigo_cl int=0,      
@nCodigo_tdpc int=0,  
@cNrodoumento_cl varchar(20)='',  
@cRazon_social_cl varchar(150)='',  
@cNombres varchar(100)='',  
@cApellidos varchar(100)='',  
@nCodigo_sx int=0,  
@nCodigo_ru int=0,  
@cEmail_cl varchar(150)='',  
@cTelefono_cl varchar(20)='',  
@cCelular_cl varchar(20)='',  
@cDireccion text='',  
@nCodigo_ci int=0,  
@cObservacion_cl text=''  
as      
declare @xCodigo int =0    
declare @fFecha as datetime    
set @fFecha=convert(datetime,GETDATE())    
    
if @nOpcion=1   --Nuevo Registro   
begin       
   insert into CLIENTES(codigo_tdpc,  
                            nrodocumento_cl,  
       razon_social_cl,  
       nombres,  
       apellidos,  
       codigo_sx,  
       codigo_ru,  
       email_cl,  
       telefono_cl,  
       celular_cl,  
       direccion_cl,  
       codigo_ci,  
       observacion_cl,  
       fecha_crea,  
       fecha_modifica,  
       estado)  
                      values(@nCodigo_tdpc,  
              @cNrodoumento_cl,  
        @cRazon_social_cl,  
        @cNombres,  
        @cApellidos,  
        @nCodigo_sx,  
        @nCodigo_ru,  
        @cEmail_cl,  
        @cTelefono_cl,  
        @cCelular_cl,  
        @cDireccion,  
        @nCodigo_ci,  
        @cObservacion_cl,  
        @fFecha,  
        @fFecha,  
        1);  
  
end  
  
  
else   --Actualizar Registro  
begin       
     update CLIENTES set codigo_tdpc=@nCodigo_tdpc,  
                            nrodocumento_cl=@cNrodoumento_cl,  
       razon_social_cl=@cRazon_social_cl,  
       nombres=@cNombres,  
       apellidos=@cApellidos,  
       codigo_sx=@nCodigo_sx,  
       codigo_ru=@nCodigo_ru,  
       email_cl=@cEmail_cl,  
       telefono_cl=@cTelefono_cl,  
       celular_cl=@cCelular_cl,  
       direccion_cl=@cDireccion,  
       codigo_ci=@nCodigo_ci,  
       observacion_cl=@cObservacion_cl,  
       fecha_modifica=@fFecha  
where codigo_cl=@n_Codigo_cl  
                              
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_ep]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Guardar_ep]        
@nCodigo_tde int=0,  
@cNrodocumento_ep varchar(30)='',  
@nCodigo_pv int=0,  
@fFecha_ep date,  
@nCodigo_al int=0,  
@cObservacion_ep text='',  
@nSubtotal decimal(10,2)=0,  
@nIva decimal(10,2)=0,  
@nTotal_importe decimal(10,2)=0,  
@tDetalle Ty_detalle_ep Readonly  
as        
declare @xCodigo int =0      
declare @fFecha as datetime      
set @fFecha=convert(datetime,GETDATE())      
       
begin         
 insert into ENC_ENTRADA_PRODUCTOS(codigo_tde,nrodocumento_ep,codigo_pv,fecha_ep,codgo_al,observacionnes_ep,subtotal,iva,total_importe,fecha_crea,estado)  
                            values(@nCodigo_tde,@cNrodocumento_ep,@nCodigo_pv,@fFecha_ep,@nCodigo_al,@cObservacion_ep,@nSubtotal,@nIva,@nTotal_importe,@fFecha,1)  
set @xCodigo=@@IDENTITY   
 insert DET_ENTRADA_PRODUCTOS(codigo_ep,codigo_pr,cantidad,pu_compra,total)  
  
select @xCodigo,  
       x.codigo_pr,  
    x.cantidad,  
    x.pu_compra,  
    x.total  
from @tDetalle x;  

--ACTUALIZAR STOCK + NUEVA ENTRADA
update a set a.stock_actual=a.stock_actual + b.cantidad,a.pu_compra=b.pu_compra
from STOCK_PRODUCTOS a
inner join DET_ENTRADA_PRODUCTOS b on a.codigo_pr=b.codigo_pr
inner join ENC_ENTRADA_PRODUCTOS c on b.codigo_ep=c.codigo_ep and a.codigo_al=c.codgo_al
where c.codigo_ep=@xCodigo

end    
    
    
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_ma]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[USP_Guardar_ma]
@nOpcion int=0,
@codigo int,
@Descripcion varchar(50)
as
if @nOpcion=1
begin 
insert into MARCAS(descripcion_ma,estado)values(@Descripcion,1)	
end
else
begin 
update MARCAS SET descripcion_ma=@Descripcion where codigo_ma=@codigo
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_op]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE proc [dbo].[USP_Guardar_op]  
@nOpcion int=0,  
@Id int,  
@Apellido varchar(50),
@Nombre varchar(50),
@Email varchar(50),
@Clave varchar(11),
@rol int
as  
if @nOpcion=1  
begin   
insert into Operador(apellido,nombre,email,clave,estado,rol)values(@Apellido,@Nombre,@Email,@Clave,1,@rol)   
end  
else  
begin   
update Operador SET apellido=@Apellido,nombre=@Nombre,@Email=@Email,clave=@Clave,rol=@rol where id=@Id  
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_pa]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create proc [dbo].[USP_Guardar_pa]  
@nOpcion int=0,  
@codigo int,  
@Descripcion varchar(50)  
as  
if @nOpcion=1  
begin   
insert into PAISES(descripcion_pa,estado)values(@Descripcion,1)   
end  
else  
begin   
update PAISES SET descripcion_pa=@Descripcion where codigo_pa=@codigo  
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_po]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
Create proc [dbo].[USP_Guardar_po]    
@nOpcion int=0,    
@codigo int,    
@Descripcion varchar(100),  
@cCodigo_pa int=0
as    
if @nOpcion=1    
begin     
insert into PROVINCIAS(descripcion_po,codigo_pa,estado)values(@Descripcion,@cCodigo_pa,1)     
end    
else    
begin     
update PROVINCIAS SET descripcion_po=@Descripcion, 
                      codigo_pa=@cCodigo_pa
                  where codigo_po=@codigo    
end      
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_pr]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Guardar_pr]    
@nOpcion int=0,    
@n_Codigo_pr int,    
@cDescripcion_pr varchar(100),  
@n_Codigo_ma int=0,  
@n_Codigo_um int=0,  
@n_Codigo_ca int=0,  
@nStock_min decimal(10,2)=0,  
@nStock_max decimal(10,2)=0,  
@nPu_venta decimal(10,2)=0
as    
declare @xCodigo int =0  
declare @fFecha as datetime  
set @fFecha=convert(datetime,GETDATE())  
  
if @nOpcion=1    
begin     
insert into PRODUCTOS(descripcion,  
                      codigo_ma,  
       codigo_um,  
       codigo_ca,  
       stock_min,  
       stock_max, 
	   pu_venta,
       fecha_crea,  
       fecha_modifica,  
       estado)  
       values(@cDescripcion_pr,  
              @n_Codigo_ma,  
        @n_Codigo_um,  
        @n_Codigo_ca,  
        @nStock_min,  
        @nStock_max,  
		@nPu_venta,
        @fFecha,  
        @fFecha,  
        1);    
set @xCodigo=@@IDENTITY --obtine el codigo que se genera automaticamente  
insert into STOCK_PRODUCTOS(codigo_pr,  
                             codigo_al,  
        stock_actual,  
        pu_compra)  
select @xCodigo,  
       codigo_al,  
    0.00,  
    0.00  
from ALMACENES ;         
end    
else    
begin     
update PRODUCTOS SET descripcion=@cDescripcion_pr,  
                     codigo_ma=@n_Codigo_ma,  
      codigo_um=@n_Codigo_um,  
      codigo_ca=@n_Codigo_ca,  
      stock_min=@nStock_min,  
      stock_max=@nStock_max,  
	  pu_venta=@nPu_venta,
      fecha_modifica=@fFecha  
where codigo_pr=@n_Codigo_pr;  
  
insert into STOCK_PRODUCTOS(codigo_pr,  
                             codigo_al,  
        stock_actual,  
        pu_compra)  
select @n_Codigo_pr,  
       codigo_al,  
    0.00,  
    0.00  
from ALMACENES where codigo_al not in (select codigo_al from STOCK_PRODUCTOS where codigo_pr=@n_Codigo_pr);  
  
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_pv]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Guardar_pv]    
@nOpcion int=0,    
@n_Codigo_pv int=0,    
@nCodigo_tdpc int=0,
@cNrodoumento_pv varchar(20)='',
@cRazon_social_pv varchar(150)='',
@cNombres varchar(100)='',
@cApellidos varchar(100)='',
@nCodigo_sx int=0,
@nCodigo_ru int=0,
@cEmail_pv varchar(150)='',
@cTelefono_pv varchar(20)='',
@cCelular_pv varchar(20)='',
@cDireccion text='',
@nCodigo_ci int=0,
@cObservacion_pv text=''
as    
declare @xCodigo int =0  
declare @fFecha as datetime  
set @fFecha=convert(datetime,GETDATE())  
  
if @nOpcion=1   --Nuevo Registro 
begin     
   insert into PROVEEDORES(codigo_tdpc,
                            nrodocumento_pv,
							razon_social_pv,
							nombres,
							apellidos,
							codigo_sx,
							codigo_ru,
							email_pv,
							telefono,
							celular,
							direccion_pv,
							codigo_ci,
							observacion_pv,
							fecha_crea,
							fecha_modifica,
							estado)
                      values(@nCodigo_tdpc,
					         @cNrodoumento_pv,
							 @cRazon_social_pv,
							 @cNombres,
							 @cApellidos,
							 @nCodigo_sx,
							 @nCodigo_ru,
							 @cEmail_pv,
							 @cTelefono_pv,
							 @cCelular_pv,
							 @cDireccion,
							 @nCodigo_ci,
							 @cObservacion_pv,
							 @fFecha,
							 @fFecha,
							 1);

end


else   --Actualizar Registro
begin     
     update PROVEEDORES set codigo_tdpc=@nCodigo_tdpc,
                            nrodocumento_pv=@cNrodoumento_pv,
							razon_social_pv=@cRazon_social_pv,
							nombres=@cNombres,
							apellidos=@cApellidos,
							codigo_sx=@nCodigo_sx,
							codigo_ru=@nCodigo_ru,
							email_pv=@cEmail_pv,
							telefono=@cTelefono_pv,
							celular=@cCelular_pv,
							direccion_pv=@cDireccion,
							codigo_ci=@nCodigo_ci,
							observacion_pv=@cObservacion_pv,
							fecha_modifica=@fFecha
where codigo_pv=@n_Codigo_pv
                            
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_ru]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[USP_Guardar_ru]  
@nOpcion int=0,  
@codigo int,  
@Descripcion varchar(60)  
as  
if @nOpcion=1  
begin   
insert into RUBROS(descripcion_ru,estado)values(@Descripcion,1)   
end  
else  
begin   
update RUBROS SET descripcion_ru=@Descripcion where codigo_ru=@codigo  
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_sp]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Guardar_sp]            
@nCodigo_tde int=0,      
@cNrodocumento_sp varchar(30)='',      
@nCodigo_cl int=0,   
@cNrodocumento_cl varchar(20)='',  
@cRazon_social_cl varchar(150)='',  
@fFecha_sp date,        
@cObservacion_sp text='',      
@nSubtotal decimal(10,2)=0,      
@nIva decimal(10,2)=0,      
@nTotal_importe decimal(10,2)=0,      
@tDetalle Ty_detalle_sp Readonly,
@nCodigo_sp int=0  output
as            
declare @xCodigo int =0          
declare @fFecha as datetime          
set @fFecha=convert(datetime,GETDATE())          
           
begin             
 insert into ENC_SALIDA_PRODUCTOS(codigo_tde,  
                                  nrodocumento_sp,  
          codigo_cl,  
          nrodocumento_cl,  
          razonsocial_cl,  
          fecha_sp,  
          observacion_sp,  
          subtotal,  
          iva,  
          total_importe,  
          fecha_crea,  
          estado)      
                            values(@nCodigo_tde,  
              @cNrodocumento_sp,  
           @nCodigo_cl,  
           @cNrodocumento_cl,  
           @cRazon_social_cl,  
           @fFecha_sp,  
           @cObservacion_sp,  
           @nSubtotal,  
           @nIva,  
           @nTotal_importe,  
           @fFecha,1)      
 set @xCodigo=@@IDENTITY       
 insert DET_SALIDA_PRODUCTOS(codigo_sp,codigo_pr,cantidad,pu_venta,total)      
      
select @xCodigo,      
       x.codigo_pr,      
       x.cantidad,      
       x.pu_venta,      
       x.total      
from @tDetalle x;      
    
--ACTUALIZAR STOCK - NUEVA ENTRADA    
update a set a.stock_actual=a.stock_actual - b.cantidad  --a.pu_compra=b.pu_compra    
from STOCK_PRODUCTOS a    
inner join DET_SALIDA_PRODUCTOS b on a.codigo_pr=b.codigo_pr    
inner join ENC_SALIDA_PRODUCTOS c on b.codigo_sp=c.codigo_sp  and a.codigo_al=4  
where c.codigo_sp=@xCodigo    

set @nCodigo_sp=@xCodigo    
end        
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_um]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create proc [dbo].[USP_Guardar_um]  
@nOpcion int=0,  
@codigo int,  
@Abreviatura varchar(3),
@Descripcion varchar(20)  
as  
if @nOpcion=1  
begin   
insert into UNIDADES_MEDIDAS(abreviatura_um,descripcion_um,estado)values(@Abreviatura, @Descripcion,1)   
end  
else  
begin   
update UNIDADES_MEDIDAS SET abreviatura_um=@Abreviatura,descripcion_um=@Descripcion where codigo_um=@codigo  
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_us]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[USP_Guardar_us]      
@nOpcion int=0,      
@nCodigo_us int,      
@cLogin_us varchar(20)='',  
@cPassword_us varchar(20)='',  
@cNombre_us varchar(100)='',  
@cCargo_us varchar(50)='',  
@bAdmin bit  
as      
if @nOpcion=1      
begin       
insert into USUARIOS(login_us,  
                     password_us,  
      nombre_us,  
      cargo_us,  
      admin,  
      estado)  
                       
     values(@cLogin_us,  
            @cPassword_us,  
      @cNombre_us,  
      @cCargo_us,  
      @bAdmin,  
      1)  
              
end      
else      
begin       
update  USUARIOS set password_us=iif(len(trim(@cPassword_us))=0,password_us,@cPassword_us),  
                     nombre_us=@cNombre_us,  
                     cargo_us=@cCargo_us,  
                     admin=@bAdmin  
where codigo_us=@nCodigo_us  
  
end
GO
/****** Object:  StoredProcedure [dbo].[Usp_GuardarRol]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Usp_GuardarRol]
@Nom varchar(30),
@IdRol int Output

as
begin
  set nocount on
  Begin
    insert into Rol_Usuario(RolNombre)
	values (@Nom)
	select @IdRol= SCOPE_IDENTITY()
  end
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_al]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Listado_al]  
@Texto varchar(50)=''  
as  
select codigo_al,descripcion_al from ALMACENES where estado=1 and upper(trim(cast(codigo_al as char))+trim(descripcion_al)) like '%'+upper(trim(@Texto))+'%';  
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_al_ep]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Listado_al_ep]        
       
as        
select descripcion_al,codigo_al from ALMACENES where estado=1  and codigo_al=4    --El Almacen principal
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_ca]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Listado_ca]
@Texto varchar(100)=''
as
select codigo_ca,descripcion_ca from CATEGORIAS where estado=1 and upper(trim(cast(codigo_ca as char))+trim(descripcion_ca)) like '%'+upper(trim(@Texto))+'%';
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_ca_pr]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Listado_ca_pr]    
@Texto varchar(20)=''    
as    
select descripcion_ca,codigo_ca from CATEGORIAS where estado=1 and upper(trim(descripcion_ca)) like '%'+upper(trim(@Texto))+'%'; 
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_ci]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
create proc [dbo].[USP_Listado_ci]      
@Texto varchar(100)=''      
as      
select a.codigo_ci,  
       a.descripcion_ci,  
       b.descripcion_po,
	   c.descripcion_pa,
       a.codigo_po  
from CIUDADES a  
inner join PROVINCIAS b on a.codigo_po=b.codigo_po  
inner join PAISES c on b.codigo_pa=c.codigo_pa
where a.estado=1 and   
upper(trim(cast(a.codigo_ci as char))+  
trim(a.descripcion_ci) +  
trim(b.descripcion_po) +
trim(c.descripcion_pa)
) like '%'+upper(trim(@Texto))+'%'; 
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_ci_pv]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Listado_ci_pv]      
@Texto varchar(100)=''      
as      
select a.descripcion_ci,
       b.descripcion_po,
	   c.descripcion_pa,
       a.codigo_ci
from CIUDADES a
inner join PROVINCIAS b on a.codigo_po=b.codigo_po
inner join PAISES c on b.codigo_pa=c.codigo_pa
where a.estado=1 and
upper(trim(a.descripcion_ci)) like '%'+upper(trim(@Texto))+'%'; 
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_cl]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Listado_cl]          
@Texto varchar(150)=''          
as        
      
select  a.codigo_cl,       
        b.descripcion_tdpc,      
  a.nrodocumento_cl,      
  a.razon_social_cl,      
  a.nombres,      
  a.apellidos,      
  c.descripcion_ru,      
  a.email_cl,      
  a.telefono_cl,      
  a.celular_cl,      
  a.codigo_sx,      
  d.descripcion_sx,      
  a.direccion_cl,      
  a.codigo_ci,      
  e.descripcion_ci,      
  f.descripcion_po,      
  g.descripcion_pa,      
  a.observacion_cl,      
  a.codigo_tdpc,    
  a.codigo_ru    
from CLIENTES a      
inner join TIPOS_DOCUMENTOS_PV_CL b on a.codigo_tdpc=b.codigo_tdpc      
inner join RUBROS c on a.codigo_ru=c.codigo_ru      
inner join SEXOS d on a.codigo_sx=d.codigo_sx      
inner join CIUDADES e on a.codigo_ci=e.codigo_ci      
inner join PROVINCIAS f on e.codigo_po=f.codigo_po      
inner join PAISES g on  f.codigo_pa=g.codigo_pa      
      
where a.estado=1 and  
upper(trim(cast(a.codigo_cl as char)))+      
       trim(b.descripcion_tdpc)+      
    trim(a.nrodocumento_cl)+      
    trim(a.razon_social_cl)+      
    trim(a.nombres)+      
    trim(a.apellidos)+      
    trim(c.descripcion_ru)+      
    trim(a.email_cl)+      
    trim(a.telefono_cl)+      
    trim(a.celular_cl) like '%'+UPPER(trim(@Texto))+'%';
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_cl_sp]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Listado_cl_sp]  
@cTexto varchar(150)=''  
  
as   
select  a.razon_social_cl,  
        b.descripcion_tdpc,  
        a.nrodocumento_cl,  
        a.codigo_cl  
from CLIENTES a  
inner join TIPOS_DOCUMENTOS_PV_CL b on a.codigo_tdpc=b.codigo_tdpc  
where a.estado=1 and  
upper(trim(a.razon_social_cl)+  
trim(b.descripcion_tdpc)+  
trim(a.nrodocumento_cl))  like '%'+upper(trim(@cTexto))+'%'  
order by a.codigo_cl
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_Detalle_ep]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[USP_Listado_Detalle_ep]
@nCodigo_ep int=0
as
select b.descripcion,
       c.descripcion_ma,
	   d.descripcion_um,
	   a.cantidad,
	   a.pu_compra,
	   a.total,
	   a.codigo_pr

from DET_ENTRADA_PRODUCTOS a
inner join PRODUCTOS b on a.codigo_pr=b.codigo_pr
inner join MARCAS c on b.codigo_ma=c.codigo_ma
inner join UNIDADES_MEDIDAS d on b.codigo_um=d.codigo_um

where codigo_ep=@nCodigo_ep
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_Detalle_sp]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[USP_Listado_Detalle_sp] 
@nCodigo_sp int=0  
as  
select b.descripcion,  
       c.descripcion_ma,  
    d.descripcion_um,  
    a.cantidad,  
    a.pu_venta,  
    a.total,  
    a.codigo_pr  
  
from DET_SALIDA_PRODUCTOS a  
inner join PRODUCTOS b on a.codigo_pr=b.codigo_pr  
inner join MARCAS c on b.codigo_ma=c.codigo_ma  
inner join UNIDADES_MEDIDAS d on b.codigo_um=d.codigo_um  
  
where codigo_sp=@nCodigo_sp
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_ep]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Listado_ep]              
@Texto varchar(150)=''              
as            
select  a.codigo_ep,    
        b.descripcion_tde,    
        a.nrodocumento_ep,    
        a.fecha_ep,    
        c.razon_social_pv,    
        d.descripcion_al,    
        a.total_importe,    
        a.codigo_tde,  
  a.codigo_pv,  
  a.codgo_al,  
  a.subtotal,  
  a.iva,  
  a.observacionnes_ep
from ENC_ENTRADA_PRODUCTOS a    
inner join TIPOS_DOCUMENTOS_EMITIR b on a.codigo_tde=b.codigo_tde    
inner join PROVEEDORES c on a.codigo_pv=c.codigo_pv    
inner join ALMACENES d on a.codgo_al=d.codigo_al    
    
where a.estado=1 and     
    
upper(trim(cast(a.codigo_ep as char))+    
trim(b.descripcion_tde)+    
trim(a.nrodocumento_ep)+    
trim(c.razon_social_pv)+    
trim(d.descripcion_al)) like '%'+upper(trim(@Texto))+'%'    
order by a.codigo_ep  
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_ma]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_Listado_ma]
@Texto varchar(40)=''
as
select codigo_ma,descripcion_ma from MARCAS where estado=1 and upper(trim(cast(codigo_ma as char))+trim(descripcion_ma)) like '%'+upper(trim(@Texto))+'%';
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_ma_pr]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Listado_ma_pr]  
@Texto varchar(40)=''  
as  
select descripcion_ma,codigo_ma from MARCAS where estado=1 and upper(trim(descripcion_ma)) like '%'+upper(trim(@Texto))+'%'; 
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_op]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE proc [dbo].[USP_Listado_op]  
 
as  
select
a.id,
a.apellido,
a.nombre,
b.detalle
from Operador a 
inner join Rol b on a.id=rol 

where a.estado=1  
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_pa]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
create proc [dbo].[USP_Listado_pa]  
@Texto varchar(100)=''  
as  
select codigo_pa,descripcion_pa from PAISES where estado=1 and upper(trim(cast(codigo_pa as char))+trim(descripcion_pa)) like '%'+upper(trim(@Texto))+'%';  
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_pa_po]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
create proc [dbo].[USP_Listado_pa_po]    
@Texto varchar(100)=''    
as    
select descripcion_pa,codigo_pa
from PAISES
where estado=1 and 
upper(trim(descripcion_pa)) like '%'+upper(trim(@Texto))+'%';    
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_po]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
create proc [dbo].[USP_Listado_po]    
@Texto varchar(100)=''    
as    
select a.codigo_po,
       a.descripcion_po,
	   b.descripcion_pa,
	   a.codigo_pa
from PROVINCIAS a
inner join Paises b on a.codigo_pa=b.codigo_pa
where a.estado=1 and 
upper(trim(cast(a.codigo_po as char))+
trim(a.descripcion_po) +
trim(b.descripcion_pa)
) like '%'+upper(trim(@Texto))+'%';    
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_po_ci]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
create proc [dbo].[USP_Listado_po_ci]      
@Texto varchar(100)=''      
as      
select a.descripcion_po,
       b.descripcion_pa,
       a.codigo_po
	   
  from PROVINCIAS a
inner join PAISES b on a.codigo_pa=b.codigo_pa
where a.estado=1 and   
upper(trim(a.descripcion_po)+
      trim(b.descripcion_pa)
) like '%'+upper(trim(@Texto))+'%'; 
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_pr]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Listado_pr]    
@Texto varchar(100)=''    
as    
select a.codigo_pr,  
a.descripcion,  
b.descripcion_ma,  
c.descripcion_um,  
d.descripcion_ca,  
a.stock_min,  
a.stock_max,  
a.codigo_ma,  
a.codigo_um,  
a.codigo_ca,
a.pu_venta
from PRODUCTOS a  
inner join MARCAS b on a.codigo_ma=b.codigo_ma  
inner join UNIDADES_MEDIDAS c on a.codigo_um=c.codigo_um  
inner join CATEGORIAS d on a.codigo_ca=d.codigo_ca  
where a.estado=1 and   
upper(trim(cast(a.codigo_pr as char))+  
trim(a.descripcion)+  
trim(b.descripcion_ma)+  
trim(c.descripcion_um)+  
trim(d.descripcion_ca)) like '%'+upper(trim(@Texto))+'%'  
order by a.codigo_pr;   
  
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_pr_ep]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Listado_pr_ep]  
@cTexto varchar(100)=''  
  
as   
select a.descripcion,
       b.descripcion_ma,
	   c.descripcion_um,
	   d.descripcion_ca,
	   a.codigo_pr
from PRODUCTOS a
inner join MARCAS b on a.codigo_ma=b.codigo_ma
inner join UNIDADES_MEDIDAS c on a.codigo_um=c.codigo_um
inner join CATEGORIAS d on  a.codigo_ca=d.codigo_ca

where a.estado=1 and
upper(trim(a.descripcion)+
trim(b.descripcion_ma)+
trim(c.descripcion_um)+
trim(d.descripcion_ca)) like '%'+upper(trim(@cTexto))+'%'
order by codigo_pr
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_pr_sp]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Listado_pr_sp]      
@cTexto varchar(100)=''      
      
as       
select a.descripcion,    
       b.descripcion_ma,    
       c.descripcion_um,    
       d.descripcion_ca,   
       e.stock_actual,  
	   a.pu_venta,
       a.codigo_pr    
  
from PRODUCTOS a    
inner join MARCAS b on a.codigo_ma=b.codigo_ma    
inner join UNIDADES_MEDIDAS c on a.codigo_um=c.codigo_um    
inner join CATEGORIAS d on  a.codigo_ca=d.codigo_ca    
inner join STOCK_PRODUCTOS e on a.codigo_pr=e.codigo_pr and e.codigo_al=4--Almacen Principal  
    
where a.estado=1 and  e.stock_actual>0 and  
upper(trim(a.descripcion)+    
trim(b.descripcion_ma)+    
trim(c.descripcion_um)+    
trim(d.descripcion_ca)) like '%'+upper(trim(@cTexto))+'%'    
order by codigo_pr 
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_pv]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Listado_pv]        
@Texto varchar(150)=''        
as      
    
select  a.codigo_pv,     
        b.descripcion_tdpc,    
  a.nrodocumento_pv,    
  a.razon_social_pv,    
  a.nombres,    
  a.apellidos,    
  c.descripcion_ru,    
  a.email_pv,    
  a.telefono,    
  a.celular,    
  a.codigo_sx,    
  d.descripcion_sx,    
  a.direccion_pv,    
  a.codigo_ci,    
  e.descripcion_ci,    
  f.descripcion_po,    
  g.descripcion_pa,    
  a.observacion_pv,    
  a.codigo_tdpc,  
  a.codigo_ru  
from PROVEEDORES a    
inner join TIPOS_DOCUMENTOS_PV_CL b on a.codigo_tdpc=b.codigo_tdpc    
inner join RUBROS c on a.codigo_ru=c.codigo_ru    
inner join SEXOS d on a.codigo_sx=d.codigo_sx    
inner join CIUDADES e on a.codigo_ci=e.codigo_ci    
inner join PROVINCIAS f on e.codigo_po=f.codigo_po    
inner join PAISES g on  f.codigo_pa=g.codigo_pa    
    
where a.estado=1 and
upper(trim(cast(a.codigo_pv as char)))+    
       trim(b.descripcion_tdpc)+    
    trim(a.nrodocumento_pv)+    
    trim(a.razon_social_pv)+    
    trim(a.nombres)+    
    trim(a.apellidos)+    
    trim(c.descripcion_ru)+    
    trim(a.email_pv)+    
    trim(a.telefono)+    
    trim(a.celular) like '%'+UPPER(trim(@Texto))+'%';
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_pv_ep]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Listado_pv_ep]
@cTexto varchar(150)=''

as 
select  a.razon_social_pv,
        b.descripcion_tdpc,
		a.nrodocumento_pv,
		a.codigo_pv
from PROVEEDORES a
inner join TIPOS_DOCUMENTOS_PV_CL b on a.codigo_tdpc=b.codigo_tdpc
where a.estado=1 and
upper(trim(a.razon_social_pv)+
trim(b.descripcion_tdpc)+
trim(a.nrodocumento_pv))  like '%'+upper(trim(@cTexto))+'%'
order by a.codigo_pv
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_ru]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Listado_ru]  
@Texto varchar(60)=''  
as  
select codigo_ru,descripcion_ru from RUBROS where estado=1 and upper(trim(cast(codigo_ru as char))+trim(descripcion_ru)) like '%'+upper(trim(@Texto))+'%';  
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_ru_pv]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Listado_ru_pv]      
@Texto varchar(60)=''      
as      
select descripcion_ru,codigo_ru from RUBROS where estado=1 and upper(trim(descripcion_ru)) like '%'+upper(trim(@Texto))+'%'; 
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_sp]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Listado_sp]                
@Texto varchar(150)=''                
as              
select  a.codigo_sp,      
        b.descripcion_tde,      
        a.nrodocumento_sp,      
        a.fecha_sp,  
	    a.nrodocumento_cl,
        a.razonsocial_cl,           
        a.total_importe,      
        a.codigo_tde,    
        a.codigo_cl,        
        a.subtotal,    
        a.iva,    
        a.observacion_sp
from ENC_SALIDA_PRODUCTOS a      
inner join TIPOS_DOCUMENTOS_EMITIR b on a.codigo_tde=b.codigo_tde      
           
where a.estado=1 and       
      
upper(trim(cast(a.codigo_sp as char))+      
trim(b.descripcion_tde)+      
trim(a.nrodocumento_sp)+  
trim(a.razonsocial_cl)) like '%'+upper(trim(@Texto))+'%'      
order by a.codigo_sp 
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_sx_pv]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Listado_sx_pv]    
   
as    
select descripcion_sx,codigo_sx 
from SEXOS where estado=1 
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_td_pv]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Listado_td_pv]    
   
as    
select descripcion_tdpc,codigo_tdpc 
from TIPOS_DOCUMENTOS_PV_CL where estado=1 
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_tde]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Listado_tde]      
     
as      
select descripcion_tde,
codigo_tde  
from TIPOS_DOCUMENTOS_EMITIR where estado=1  
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_um]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
create proc [dbo].[USP_Listado_um]  
@Texto varchar(20)=''  
as  
select codigo_um,
abreviatura_um,
descripcion_um 
from UNIDADES_MEDIDAS 
where estado=1 and 
upper(trim(cast(codigo_um as char)) +
trim(abreviatura_um) +
trim(descripcion_um)) like '%'+upper(trim(@Texto))+'%';  
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_um_pr]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Listado_um_pr]    
@Texto varchar(20)=''    
as    
select descripcion_um,codigo_um from UNIDADES_MEDIDAS where estado=1 and upper(trim(descripcion_um)) like '%'+upper(trim(@Texto))+'%'; 
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_us]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Listado_us]
@cTexto varchar(100)
as
select codigo_us,
       login_us,
	   nombre_us,
	   cargo_us,
	   admin
	   from USUARIOS
where estado=1  and
   upper(trim(cast(codigo_us as char))+
   trim(login_us)+
   trim(nombre_us)+
   trim(cargo_us)) like '%'+upper(trim(@cTexto))+'%'

order by codigo_us
GO
/****** Object:  StoredProcedure [dbo].[USP_Login_us]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Login_us] 
@cLogin_us varchar(20)='',
@cPassword_us varchar(20)=''
as
select *from USUARIOS
where estado=1 and
     upper(trim(login_us))=upper(trim(@cLogin_us)) and
	 trim(password_us)=trim(@cPassword_us)
GO
/****** Object:  StoredProcedure [dbo].[USP_Reporte_Ingreso_ComprasxProductos]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_Reporte_Ingreso_ComprasxProductos]
@Fecha_ini date,
@Fecha_fin date
as

select a.codigo_pr,
       b.descripcion,
	   c.descripcion_ma,
	   d.descripcion_um,
	   a.cantidad,
	   a.pu_compra,
	   a.total,
	   f.descripcion_al,
	   g.descripcion_tde,
	   e.nrodocumento_ep,
	   e.fecha_ep,

	   @Fecha_ini as fecha_ini,
	   @Fecha_fin as fecha_fin
from DET_ENTRADA_PRODUCTOS a
inner join PRODUCTOS b on a.codigo_pr=b.codigo_pr
inner join MARCAS c on b.codigo_ma=c.codigo_ma
inner join UNIDADES_MEDIDAS d on b.codigo_um=d.codigo_um
inner join ENC_ENTRADA_PRODUCTOS e on a.codigo_ep=e.codigo_ep
inner join ALMACENES f on e.codgo_al=f.codigo_al
inner join TIPOS_DOCUMENTOS_EMITIR g on e.codigo_tde=g.codigo_tde

where e.estado=1 and e.fecha_ep between @Fecha_ini and @Fecha_fin
order by b.descripcion,e.fecha_ep	
GO
/****** Object:  StoredProcedure [dbo].[USP_Reporte_Salida_VentasxProductos]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_Reporte_Salida_VentasxProductos]  
@Fecha_ini date,  
@Fecha_fin date  
as  
  
select a.codigo_pr,  
       b.descripcion,  
    c.descripcion_ma,  
    d.descripcion_um,  
    a.cantidad,  
    a.pu_venta,  
    a.total,   
    g.descripcion_tde,  
    e.nrodocumento_sp,  
    e.fecha_sp,  
  
    @Fecha_ini as fecha_ini,  
    @Fecha_fin as fecha_fin  
from DET_SALIDA_PRODUCTOS a  
inner join PRODUCTOS b on a.codigo_pr=b.codigo_pr  
inner join MARCAS c on b.codigo_ma=c.codigo_ma  
inner join UNIDADES_MEDIDAS d on b.codigo_um=d.codigo_um  
inner join ENC_SALIDA_PRODUCTOS e on a.codigo_sp=e.codigo_sp  
inner join TIPOS_DOCUMENTOS_EMITIR g on e.codigo_tde=g.codigo_tde  
  
where e.estado=1 and e.fecha_sp between @Fecha_ini and @Fecha_fin  
order by b.descripcion,e.fecha_sp   
GO
/****** Object:  StoredProcedure [dbo].[USP_Ver_Stock_actual_ProductoxAlmacenes]    Script Date: 22/11/2022 22:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Ver_Stock_actual_ProductoxAlmacenes]
@nCodigo_pro int=0
as
select  b.descripcion_al,
        a.stock_actual,
		a.pu_compra

from STOCK_PRODUCTOS a 
inner join ALMACENES  b on a.codigo_al=b.codigo_al
where a.codigo_pr=@nCodigo_pro
order by
b.codigo_al
GO
USE [master]
GO
ALTER DATABASE [BD_Sistema_Logitica] SET  READ_WRITE 
GO
