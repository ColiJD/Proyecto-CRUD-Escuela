USE [master]
GO
/****** Object:  Database [Escuela]    Script Date: 08/12/2022 10:19:33 a. m. ******/
CREATE DATABASE [Escuela]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'colegio1.0', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\colegio1.0.mdf' , SIZE = 10240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'colegio1.0_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\colegio1.0_1.ldf' , SIZE = 10176KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Escuela] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Escuela].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Escuela] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Escuela] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Escuela] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Escuela] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Escuela] SET ARITHABORT OFF 
GO
ALTER DATABASE [Escuela] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Escuela] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Escuela] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Escuela] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Escuela] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Escuela] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Escuela] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Escuela] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Escuela] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Escuela] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Escuela] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Escuela] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Escuela] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Escuela] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Escuela] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Escuela] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Escuela] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Escuela] SET RECOVERY FULL 
GO
ALTER DATABASE [Escuela] SET  MULTI_USER 
GO
ALTER DATABASE [Escuela] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Escuela] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Escuela] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Escuela] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Escuela] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Escuela] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Escuela', N'ON'
GO
ALTER DATABASE [Escuela] SET QUERY_STORE = OFF
GO
USE [Escuela]
GO
/****** Object:  Table [dbo].[Asignar]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignar](
	[seccion] [varchar](10) NOT NULL,
	[id_docente] [int] NOT NULL,
	[anio] [varchar](4) NOT NULL,
	[fecha_registro] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[seccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[docente]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[docente](
	[id_docente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[sexo] [varchar](1) NOT NULL,
	[direccion] [varchar](40) NOT NULL,
	[email] [varchar](40) NULL,
	[telefono] [varchar](8) NOT NULL,
 CONSTRAINT [PK_docente] PRIMARY KEY CLUSTERED 
(
	[id_docente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encargado]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encargado](
	[id_Encargado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[fehca_nacimiento] [date] NOT NULL,
	[sexo] [char](1) NOT NULL,
	[direccion] [nvarchar](50) NOT NULL,
	[parentesco] [nvarchar](50) NOT NULL,
	[telefono] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Encargado] PRIMARY KEY CLUSTERED 
(
	[id_Encargado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estudiante]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estudiante](
	[id_estudiante] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[sexo] [char](1) NOT NULL,
	[direccion] [nvarchar](80) NOT NULL,
	[fecha_inscripcion] [date] NOT NULL,
	[fecha_graduacion] [date] NULL,
	[id_Encargado] [int] NOT NULL,
 CONSTRAINT [PK_estudiante] PRIMARY KEY CLUSTERED 
(
	[id_estudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matricula]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matricula](
	[id_matricula] [int] IDENTITY(1,1) NOT NULL,
	[id_estudiante] [int] NOT NULL,
	[grado] [varchar](15) NOT NULL,
	[seccion] [varchar](10) NOT NULL,
 CONSTRAINT [PK_aula] PRIMARY KEY CLUSTERED 
(
	[id_matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[sexo] [varchar](1) NOT NULL,
	[telefono] [varchar](8) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[email] [varchar](50) NULL,
	[usuario] [varchar](20) NOT NULL,
	[contraseña] [varchar](20) NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[docente] ON 

INSERT [dbo].[docente] ([id_docente], [nombre], [apellido], [fecha_nacimiento], [sexo], [direccion], [email], [telefono]) VALUES (1, N'Carlos', N'Martinez', CAST(N'2001-11-28' AS Date), N'M', N'Valle De Angeles', N'Carlos9@gmail.com', N'78451298')
SET IDENTITY_INSERT [dbo].[docente] OFF
GO
SET IDENTITY_INSERT [dbo].[Encargado] ON 

INSERT [dbo].[Encargado] ([id_Encargado], [nombre], [apellido], [fehca_nacimiento], [sexo], [direccion], [parentesco], [telefono]) VALUES (1, N'Mauricio', N'Colindres', CAST(N'1956-08-09' AS Date), N'M', N'El Parais', N'Padre', N'87542123')
INSERT [dbo].[Encargado] ([id_Encargado], [nombre], [apellido], [fehca_nacimiento], [sexo], [direccion], [parentesco], [telefono]) VALUES (2, N'Gabriel', N'Florez', CAST(N'1984-05-22' AS Date), N'M', N'Danli', N'Padre', N' 2154875')
INSERT [dbo].[Encargado] ([id_Encargado], [nombre], [apellido], [fehca_nacimiento], [sexo], [direccion], [parentesco], [telefono]) VALUES (3, N'Iris', N'Marlen', CAST(N'1975-02-10' AS Date), N'F', N'Comayagua', N'Madre', N'21235654')
SET IDENTITY_INSERT [dbo].[Encargado] OFF
GO
SET IDENTITY_INSERT [dbo].[estudiante] ON 

INSERT [dbo].[estudiante] ([id_estudiante], [nombre], [apellido], [fecha_nacimiento], [sexo], [direccion], [fecha_inscripcion], [fecha_graduacion], [id_Encargado]) VALUES (1, N'Keren', N'Colindres', CAST(N'2003-10-08' AS Date), N'F', N'San', CAST(N'2022-11-30' AS Date), CAST(N'2022-11-30' AS Date), 1)
INSERT [dbo].[estudiante] ([id_estudiante], [nombre], [apellido], [fecha_nacimiento], [sexo], [direccion], [fecha_inscripcion], [fecha_graduacion], [id_Encargado]) VALUES (2, N'Sunny', N'Barahona', CAST(N'2003-12-02' AS Date), N'F', N'Tegisigalpa', CAST(N'2022-12-02' AS Date), CAST(N'2022-12-02' AS Date), 1)
INSERT [dbo].[estudiante] ([id_estudiante], [nombre], [apellido], [fecha_nacimiento], [sexo], [direccion], [fecha_inscripcion], [fecha_graduacion], [id_Encargado]) VALUES (3, N'Camilo', N'Sanchez', CAST(N'2004-09-15' AS Date), N'M', N'Copan', CAST(N'2022-12-02' AS Date), CAST(N'2022-12-02' AS Date), 2)
SET IDENTITY_INSERT [dbo].[estudiante] OFF
GO
SET IDENTITY_INSERT [dbo].[Matricula] ON 

INSERT [dbo].[Matricula] ([id_matricula], [id_estudiante], [grado], [seccion]) VALUES (2, 1, N'1', N'1-A')
SET IDENTITY_INSERT [dbo].[Matricula] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([id_usuario], [nombres], [apellido], [fecha_nacimiento], [sexo], [telefono], [direccion], [email], [usuario], [contraseña]) VALUES (1, N'Jose', N'Colindres', CAST(N'2001-01-28' AS Date), N'M', N'88716380', N'San Jose De Oriente ', N'colindresj9@gmail.com', N'ColiJD', N'123')
INSERT [dbo].[usuario] ([id_usuario], [nombres], [apellido], [fecha_nacimiento], [sexo], [telefono], [direccion], [email], [usuario], [contraseña]) VALUES (3, N'Daniel', N'Alvarez', CAST(N'2001-11-28' AS Date), N'M', N'78451265', N'La Ceibita', N'colindresj9@gmail.com', N'DanielJ', N'123')
INSERT [dbo].[usuario] ([id_usuario], [nombres], [apellido], [fecha_nacimiento], [sexo], [telefono], [direccion], [email], [usuario], [contraseña]) VALUES (4, N'Keren', N'Alvarez', CAST(N'2003-05-01' AS Date), N'F', N'12326545', N'El Paraiso', N'keren6@gmail.com', N'Keren2', N'321')
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
ALTER TABLE [dbo].[estudiante]  WITH CHECK ADD FOREIGN KEY([id_Encargado])
REFERENCES [dbo].[Encargado] ([id_Encargado])
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD FOREIGN KEY([id_estudiante])
REFERENCES [dbo].[estudiante] ([id_estudiante])
GO
/****** Object:  StoredProcedure [dbo].[deletuser]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deletuser]
@id_usuario int
as
delete from usuario
where id_usuario=@id_usuario
GO
/****** Object:  StoredProcedure [dbo].[editar_docente]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editar_docente]
@id_docente int,
@nombre varchar(50),
@apellido  varchar(50),
@fecha_nacimiento date,
@sexo varchar(1),
@direccion  varchar(40),
@email  varchar(40),
@telefono  varchar(8)
as
update docente set 
[nombre] = @nombre,
[apellido] = @apellido,
[fecha_nacimiento] = @fecha_nacimiento,
[sexo]= @sexo,
[direccion] = @direccion,
[email] = @email,
[telefono]= @telefono
where [id_docente]=@id_docente
GO
/****** Object:  StoredProcedure [dbo].[editar_Encargado]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create proc [dbo].[editar_Encargado]
@id_Encargado int,
@nombre nvarchar(50),
@apellido  nvarchar(50),
@fehca_nacimiento date,
@sexo varchar(1),
@direccion  nvarchar(50),
@parentesco  nvarchar(50),
@telefono  nvarchar(8)
as
update [dbo].[Encargado] set 
[nombre] = @nombre,
[apellido] = @apellido,
[fehca_nacimiento] = @fehca_nacimiento,
[sexo] = @sexo,
[direccion] = @direccion,
[parentesco] = @parentesco,
[telefono] = @telefono
where [id_Encargado]=@id_Encargado
GO
/****** Object:  StoredProcedure [dbo].[editar_estudiante]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editar_estudiante]
	@id_estudiante int,
	@nombre nvarchar(50),
	@apellido nvarchar(50),
	@fecha_nacimiento date,
	@sexo char(1),
	@direccion nvarchar(80),
	@fecha_inscripcion date,
	@fecha_graduacion date,
	@id_Encargado int

as
update estudiante set [nombre] = @nombre,
[apellido] = @apellido,
[fecha_nacimiento] = @fecha_nacimiento,
[sexo] = @sexo,
[direccion] = @direccion,
[fecha_inscripcion] = @fecha_inscripcion,
[fecha_graduacion] = @fecha_graduacion,
[id_Encargado] = @id_Encargado 
where id_estudiante=@id_estudiante
GO
/****** Object:  StoredProcedure [dbo].[editar_Matricula]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[editar_Matricula]
@id_matricula int,
@id_Estudiante int,
@grado varchar(15),
@seccion varchar(10)
as
update [dbo].[Matricula] set 
[id_estudiante] = @id_Estudiante,
[grado]= @grado,
[seccion] = @seccion


where [id_matricula]=@id_matricula
GO
/****** Object:  StoredProcedure [dbo].[editar_usuario]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editar_usuario]
@id_usuario int,
@nombres varchar (50),
@apellido varchar (50),
@fecha_nacimiento date,
@sexo varchar (1),
@telefono varchar (8),
@direccion varchar (50),
@email varchar (50),
@usuario varchar (20),
@contraseña varchar (20)
as
update usuario set [nombres] = @nombres,
[apellido] = @apellido,
[fecha_nacimiento] = @fecha_nacimiento,
[sexo] = @sexo,
[telefono] =@telefono,
[direccion] = @direccion,
[email]= @email,
[usuario]= @usuario,
[contraseña] = @contraseña
where id_usuario=@id_usuario
GO
/****** Object:  StoredProcedure [dbo].[eliminar_docente]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminar_docente]
@id_docente int
as
delete from docente
where id_docente=@id_docente
GO
/****** Object:  StoredProcedure [dbo].[Eliminar_encargado]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Eliminar_encargado]
@id_Encargado int
as
delete from [dbo].[Encargado]
where[id_Encargado]=@id_Encargado
GO
/****** Object:  StoredProcedure [dbo].[eliminar_estudiante]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminar_estudiante]
@id_estudiante int
as
delete from estudiante
where id_estudiante=@id_estudiante
GO
/****** Object:  StoredProcedure [dbo].[Eliminar_Matricula]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Eliminar_Matricula]
@id_Matricula int
as
delete from [dbo].[Matricula]
where[id_matricula]=@id_Matricula


GO
/****** Object:  StoredProcedure [dbo].[guardar_docente]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[guardar_docente]	
@nombre varchar(50),
@apellido  varchar(50),
@fecha_nacimiento date,
@sexo varchar(1),
@direccion  varchar(40),
@email  varchar(40),
@telefono  varchar(8)

as

insert into docente(
[nombre],
[apellido],
[fecha_nacimiento],
[sexo],
[direccion],
[email],
[telefono]
)
values (@nombre,
@apellido,
@fecha_nacimiento,
@sexo ,
@direccion ,
@email,
@telefono)



GO
/****** Object:  StoredProcedure [dbo].[guardar_Encargado]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[guardar_Encargado]
@nombre nvarchar (50),
@apellido nvarchar (50),
@fehca_nacimiento date,
@sexo nvarchar (1),
@direccion nvarchar (50),
@parentesco nvarchar(50),
@telefono nvarchar (8)

as 
insert into Encargado
(
[nombre],
[apellido],
[fehca_nacimiento],
[sexo],
[direccion],
[parentesco],
[telefono]
)
values (
@nombre,
@apellido,
@fehca_nacimiento,
@sexo,
@direccion,
@parentesco,
@telefono)



GO
/****** Object:  StoredProcedure [dbo].[guardar_estudiante]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[guardar_estudiante]
		
	@nombre nvarchar(50),
	@apellido nvarchar(50),
	@fecha_nacimiento date,
	@sexo char(1),
	@direccion nvarchar(80),
	@fecha_inscripcion date,
	@fecha_graduacion date,
	@id_Encargado int
as 
insert into estudiante
(
[nombre],
[apellido],
[fecha_nacimiento],
[sexo],
[direccion],
[fecha_inscripcion],
[fecha_graduacion],
[id_Encargado]
)
values (@nombre,
		@apellido,
		@fecha_nacimiento,
		@sexo,
		@direccion,
		@fecha_inscripcion,
		@fecha_graduacion,
		@id_Encargado)
GO
/****** Object:  StoredProcedure [dbo].[guardar_Matricula]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[guardar_Matricula]
@id_estudiante int,
@grado varchar(15),
@seccion varchar(10)

as 
insert into Matricula
(
[id_estudiante],
[grado],
[seccion]

)
values (
@id_estudiante,
@grado,
@seccion
)


GO
/****** Object:  StoredProcedure [dbo].[guardar_usuario]    Script Date: 08/12/2022 10:19:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[guardar_usuario]
@nombres varchar (50),
@apellido varchar (50),
@fecha_nacimiento date,
@sexo varchar (1),
@telefono varchar (8),
@direccion varchar (50),
@email varchar (50),
@usuario varchar (20),
@contraseña varchar (20)
as 
insert into usuario
(
[nombres],
[apellido],
[fecha_nacimiento],
[sexo],
[telefono],
[direccion],
[email],
[usuario],
[contraseña]
)
values (
@nombres,
@apellido,
@fecha_nacimiento,
@sexo,
@telefono,
@direccion,
@email,
@usuario,
@contraseña)
GO
USE [master]
GO
ALTER DATABASE [Escuela] SET  READ_WRITE 
GO
