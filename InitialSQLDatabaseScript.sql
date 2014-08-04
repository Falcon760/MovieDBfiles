USE [master]
GO
/****** Object:  Database [MovieLoversDB]    Script Date: 8/4/2014 11:17:09 AM ******/
CREATE DATABASE [MovieLoversDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MovieLoversDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MovieLoversDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MovieLoversDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MovieLoversDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MovieLoversDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MovieLoversDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MovieLoversDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MovieLoversDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MovieLoversDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MovieLoversDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MovieLoversDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MovieLoversDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MovieLoversDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MovieLoversDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MovieLoversDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MovieLoversDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MovieLoversDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MovieLoversDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MovieLoversDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MovieLoversDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MovieLoversDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MovieLoversDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MovieLoversDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MovieLoversDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MovieLoversDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MovieLoversDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MovieLoversDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MovieLoversDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MovieLoversDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MovieLoversDB] SET  MULTI_USER 
GO
ALTER DATABASE [MovieLoversDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MovieLoversDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MovieLoversDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MovieLoversDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MovieLoversDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MovieLoversDB]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 8/4/2014 11:17:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Actor](
	[ActorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
 CONSTRAINT [PK_Actor] PRIMARY KEY CLUSTERED 
(
	[ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 8/4/2014 11:17:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[CommentContents] [varchar](500) NULL,
	[MessageBoardId] [int] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Director]    Script Date: 8/4/2014 11:17:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Director](
	[DirectorId] [int] IDENTITY(1,1) NOT NULL,
	[DirectorName] [varchar](150) NULL,
 CONSTRAINT [PK_Director] PRIMARY KEY CLUSTERED 
(
	[DirectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 8/4/2014 11:17:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[GenreType] [varchar](50) NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MessageBoard]    Script Date: 8/4/2014 11:17:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MessageBoard](
	[MessageBoardId] [int] NOT NULL,
	[MessageBoardName] [varchar](50) NULL,
 CONSTRAINT [PK_MessageBoard] PRIMARY KEY CLUSTERED 
(
	[MessageBoardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 8/4/2014 11:17:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Movie](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](150) NULL,
	[DirectorId] [int] NULL,
	[GenreId] [int] NULL,
	[Rating] [decimal](18, 2) NULL,
	[ReleaseDate] [date] NULL,
	[Summary] [varchar](500) NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MovieActor]    Script Date: 8/4/2014 11:17:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieActor](
	[MovieId] [int] NOT NULL,
	[ActorId] [int] NOT NULL,
 CONSTRAINT [PK_MovieActor] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Review]    Script Date: 8/4/2014 11:17:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Review](
	[ReviewId] [int] IDENTITY(1,1) NOT NULL,
	[ReviewTitle] [varchar](150) NULL,
	[Rating] [decimal](18, 0) NULL,
	[MessageBoardId] [int] NULL,
	[ReviewContents] [varchar](500) NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_MessageBoard] FOREIGN KEY([MessageBoardId])
REFERENCES [dbo].[MessageBoard] ([MessageBoardId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_MessageBoard]
GO
ALTER TABLE [dbo].[MessageBoard]  WITH CHECK ADD  CONSTRAINT [FK_MessageBoard_Movie] FOREIGN KEY([MessageBoardId])
REFERENCES [dbo].[Movie] ([MovieId])
GO
ALTER TABLE [dbo].[MessageBoard] CHECK CONSTRAINT [FK_MessageBoard_Movie]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Director] FOREIGN KEY([DirectorId])
REFERENCES [dbo].[Director] ([DirectorId])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Director]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([GenreId])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Genre]
GO
ALTER TABLE [dbo].[MovieActor]  WITH CHECK ADD  CONSTRAINT [FK_MovieActor_Actor] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actor] ([ActorId])
GO
ALTER TABLE [dbo].[MovieActor] CHECK CONSTRAINT [FK_MovieActor_Actor]
GO
ALTER TABLE [dbo].[MovieActor]  WITH CHECK ADD  CONSTRAINT [FK_MovieActor_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([MovieId])
GO
ALTER TABLE [dbo].[MovieActor] CHECK CONSTRAINT [FK_MovieActor_Movie]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_MessageBoard] FOREIGN KEY([MessageBoardId])
REFERENCES [dbo].[MessageBoard] ([MessageBoardId])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_MessageBoard]
GO
USE [master]
GO
ALTER DATABASE [MovieLoversDB] SET  READ_WRITE 
GO
