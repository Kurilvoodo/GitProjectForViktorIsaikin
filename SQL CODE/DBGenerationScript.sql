USE [master]
GO
/****** Object:  Database [RokolabsLibraryTestDBO]    Script Date: 11/30/2020 12:04:41 PM ******/
CREATE DATABASE [RokolabsLibraryTestDBO]
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RokolabsLibraryTestDBO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET ARITHABORT OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET  MULTI_USER 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET QUERY_STORE = OFF
GO
USE [RokolabsLibraryTestDBO]
GO
/****** Object:  UserDefinedTableType [dbo].[AuthorsBookLinksArray]    Script Date: 11/30/2020 12:04:41 PM ******/
CREATE TYPE [dbo].[AuthorsBookLinksArray] AS TABLE(
	[AuthorId] [int] NULL,
	[BookId] [int] NULL
)
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_AUTHORS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthorshipBooks]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorshipBooks](
	[AuthorId] [int] NOT NULL,
	[BookId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthorshipPatents]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorshipPatents](
	[AuthorId] [int] NOT NULL,
	[PatentId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BasePrintEditions]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasePrintEditions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PublicationYear] [int] NOT NULL,
	[Title] [nvarchar](300) NOT NULL,
	[Annotation] [nvarchar](2000) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_BasePrintEditions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BasePrintEditionId] [int] NOT NULL,
	[ISBN] [nvarchar](20) NULL,
	[PlaceOfPublication] [nvarchar](200) NOT NULL,
	[PublishingHouse] [nvarchar](300) NOT NULL,
	[NumberOfPages] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewspaperIssues]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewspaperIssues](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NewspaperId] [int] NOT NULL,
	[ReleaseNumber] [int] NULL,
	[NumberOfPages] [int] NOT NULL,
	[ReleaseDate] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_NewspaperIssues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Newspapers]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Newspapers](
	[BasePrintEditionId] [int] NOT NULL,
	[ISSN] [nvarchar](20) NOT NULL,
	[PlaceOfPublication] [nvarchar](200) NOT NULL,
	[PublishingHouse] [nvarchar](300) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patents]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patents](
	[BasePrintEditionId] [int] NOT NULL,
	[Country] [nvarchar](200) NOT NULL,
	[RegistrationNumber] [int] NOT NULL,
	[DateOfApplication] [datetime] NOT NULL,
	[NumberOfPages] [int] NOT NULL,
	[PublicationDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolesOfUsers]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesOfUsers](
	[UserId] [int] NOT NULL,
	[WebsiteRoleId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [varbinary](256) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WebsiteRoles]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebsiteRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_WebsiteRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [IsDeleted]) VALUES (2, N'Anjey', N'Test', 0)
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [IsDeleted]) VALUES (3, N'Testing', N'Frolsky', 0)
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [IsDeleted]) VALUES (4, N'Agggadf', N'Okakak', 0)
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [IsDeleted]) VALUES (5, N'Another', N'Frolsky', 0)
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [IsDeleted]) VALUES (6, N'Andrey', N'Maslov', 0)
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [IsDeleted]) VALUES (7, N'Testing', N'Hasbernov', 0)
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [IsDeleted]) VALUES (8, N'Хуйня', N'Придумана', 0)
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
INSERT [dbo].[AuthorshipBooks] ([AuthorId], [BookId]) VALUES (6, 1)
GO
INSERT [dbo].[AuthorshipPatents] ([AuthorId], [PatentId]) VALUES (5, 3)
GO
SET IDENTITY_INSERT [dbo].[BasePrintEditions] ON 

INSERT [dbo].[BasePrintEditions] ([Id], [PublicationYear], [Title], [Annotation], [Type], [IsDeleted]) VALUES (1, 1993, N'Join the brokolly', N'Something about vegetable religion', N'Book', 0)
INSERT [dbo].[BasePrintEditions] ([Id], [PublicationYear], [Title], [Annotation], [Type], [IsDeleted]) VALUES (2, 2002, N'Adass', N'Something about vegetable religion', N'Newspaper', 0)
INSERT [dbo].[BasePrintEditions] ([Id], [PublicationYear], [Title], [Annotation], [Type], [IsDeleted]) VALUES (3, 2020, N'Andrey nayobzhik', N'It''s a book about how to delete books', N'Patent', 0)
SET IDENTITY_INSERT [dbo].[BasePrintEditions] OFF
GO
INSERT [dbo].[Books] ([BasePrintEditionId], [ISBN], [PlaceOfPublication], [PublishingHouse], [NumberOfPages]) VALUES (1, N'ISBN 7-1233-1544-X', N'Saratov', N'Indian Source', 15)
GO
SET IDENTITY_INSERT [dbo].[NewspaperIssues] ON 

INSERT [dbo].[NewspaperIssues] ([Id], [NewspaperId], [ReleaseNumber], [NumberOfPages], [ReleaseDate], [IsDeleted]) VALUES (1, 2, 1, 25, CAST(N'2020-11-03T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[NewspaperIssues] ([Id], [NewspaperId], [ReleaseNumber], [NumberOfPages], [ReleaseDate], [IsDeleted]) VALUES (18, 2, 3, 12, CAST(N'2020-11-20T00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[NewspaperIssues] OFF
GO
INSERT [dbo].[Newspapers] ([BasePrintEditionId], [ISSN], [PlaceOfPublication], [PublishingHouse]) VALUES (2, N'ISSN 7431-8954', N'Zhernov', N'Indian Source')
GO
INSERT [dbo].[Patents] ([BasePrintEditionId], [Country], [RegistrationNumber], [DateOfApplication], [NumberOfPages], [PublicationDate]) VALUES (3, N'Russia', 198, CAST(N'2020-11-15T00:00:00.000' AS DateTime), 999, CAST(N'2020-11-16T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[RolesOfUsers] ([UserId], [WebsiteRoleId]) VALUES (1, 2)
INSERT [dbo].[RolesOfUsers] ([UserId], [WebsiteRoleId]) VALUES (2, 2)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [IsDeleted]) VALUES (1, N'TestUser', 0x65E84BE33532FB784C48129675F9EFF3A682B27168C0EA744B2CF58EE02337C5, 0)
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsDeleted]) VALUES (2, N'dmin', 0x8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[WebsiteRoles] ON 

INSERT [dbo].[WebsiteRoles] ([Id], [RoleName], [IsDeleted]) VALUES (1, N'CommonUser', 0)
INSERT [dbo].[WebsiteRoles] ([Id], [RoleName], [IsDeleted]) VALUES (2, N'Admin', 0)
SET IDENTITY_INSERT [dbo].[WebsiteRoles] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Books__447D36EA5187CE27]    Script Date: 11/30/2020 12:04:41 PM ******/
ALTER TABLE [dbo].[Books] ADD  CONSTRAINT [UQ__Books__447D36EA5187CE27] UNIQUE NONCLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Newspape__447D3E96B73F6C37]    Script Date: 11/30/2020 12:04:41 PM ******/
ALTER TABLE [dbo].[Newspapers] ADD  CONSTRAINT [UQ__Newspape__447D3E96B73F6C37] UNIQUE NONCLUSTERED 
(
	[ISSN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AuthorshipBooks]  WITH CHECK ADD  CONSTRAINT [AuthorshipLinks_fk0] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
GO
ALTER TABLE [dbo].[AuthorshipBooks] CHECK CONSTRAINT [AuthorshipLinks_fk0]
GO
ALTER TABLE [dbo].[AuthorshipPatents]  WITH CHECK ADD  CONSTRAINT [FK_AuthorshipPatents_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
GO
ALTER TABLE [dbo].[AuthorshipPatents] CHECK CONSTRAINT [FK_AuthorshipPatents_Authors]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_BasePrintEditions] FOREIGN KEY([BasePrintEditionId])
REFERENCES [dbo].[BasePrintEditions] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_BasePrintEditions]
GO
ALTER TABLE [dbo].[NewspaperIssues]  WITH CHECK ADD  CONSTRAINT [FK_NewspaperIssues_BasePrintEditions] FOREIGN KEY([NewspaperId])
REFERENCES [dbo].[BasePrintEditions] ([Id])
GO
ALTER TABLE [dbo].[NewspaperIssues] CHECK CONSTRAINT [FK_NewspaperIssues_BasePrintEditions]
GO
ALTER TABLE [dbo].[Newspapers]  WITH CHECK ADD  CONSTRAINT [FK_Newspapers_BasePrintEditions] FOREIGN KEY([BasePrintEditionId])
REFERENCES [dbo].[BasePrintEditions] ([Id])
GO
ALTER TABLE [dbo].[Newspapers] CHECK CONSTRAINT [FK_Newspapers_BasePrintEditions]
GO
ALTER TABLE [dbo].[Patents]  WITH CHECK ADD  CONSTRAINT [FK_Patents_BasePrintEditions] FOREIGN KEY([BasePrintEditionId])
REFERENCES [dbo].[BasePrintEditions] ([Id])
GO
ALTER TABLE [dbo].[Patents] CHECK CONSTRAINT [FK_Patents_BasePrintEditions]
GO
ALTER TABLE [dbo].[RolesOfUsers]  WITH CHECK ADD  CONSTRAINT [FK_RolesOfUsers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[RolesOfUsers] CHECK CONSTRAINT [FK_RolesOfUsers_Users]
GO
ALTER TABLE [dbo].[RolesOfUsers]  WITH CHECK ADD  CONSTRAINT [FK_RolesOfUsers_WebsiteRoles] FOREIGN KEY([WebsiteRoleId])
REFERENCES [dbo].[WebsiteRoles] ([Id])
GO
ALTER TABLE [dbo].[RolesOfUsers] CHECK CONSTRAINT [FK_RolesOfUsers_WebsiteRoles]
GO
/****** Object:  StoredProcedure [dbo].[AddAuthor]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAuthor]
@FirstName nvarchar(50),
@LastName nvarchar(200)
AS
BEGIN
INSERT INTO Authors (FirstName, LastName, IsDeleted)
VALUES (@FirstName,@LastName, 0)
SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AddAuthorToBook]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAuthorToBook]
@AuthorId INT,
@BookId INT
AS
BEGIN
INSERT INTO AuthorshipBooks (AuthorId, BookId)
VALUES (@AuthorId, @BookId)

END
GO
/****** Object:  StoredProcedure [dbo].[AddAuthorToPatent]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAuthorToPatent]
@AuthorId INT,
@PatentId INT
AS
BEGIN
INSERT INTO AuthorshipPatents (AuthorId, PatentId)
VALUES (@AuthorId, @PatentId)
END
GO
/****** Object:  StoredProcedure [dbo].[AddBook]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddBook]
@AuthorId INT,
@ISBN nvarchar(20),
@PublicationYear INT,
@Title nvarchar(300),
@Annotation nvarchar(2000),
@PlaceOfPublication nvarchar(200),
@PublishingHouse nvarchar(300),
@NumberOfPages INT,
@AuthorsIds AS AuthorsBookLinksArray READONLY
AS
BEGIN
INSERT INTO BasePrintEditions (PublicationYear, Title, Annotation , Type , IsDeleted)
VALUES(@PublicationYear, @Title, @Annotation, 'Book', 0)
DECLARE @BasePrintEditionId INT
SET @BasePrintEditionId = SCOPE_IDENTITY()
INSERT INTO Books (BasePrintEditionId, ISBN, PlaceOfPublication, PublishingHouse, NumberOfPages)
VALUES (@BasePrintEditionId, @ISBN, @PlaceOfPublication, @PublishingHouse, @NumberOfPages)
INSERT INTO AuthorshipBooks  (AuthorId, BookId)
VALUES (@AuthorId, @BasePrintEditionId)
SELECT @BasePrintEditionId
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewspaper]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddNewspaper]
@ISSN nvarchar(20),
@PublicationYear INT,
@Title nvarchar(300),
@Annotation nvarchar(2000),
@PlaceOfPublication nvarchar(200),
@PublishingHouse nvarchar(300)
AS
BEGIN
INSERT INTO BasePrintEditions (PublicationYear, Title, Annotation , Type, IsDeleted)
VALUES(@PublicationYear, @Title, @Annotation, 'Newspaper', 0)
DECLARE @BasePrintEditionId INT
SET @BasePrintEditionId = SCOPE_IDENTITY()
INSERT INTO Newspapers (BasePrintEditionId,ISSN, PlaceOfPublication, PublishingHouse)
VALUES (@BasePrintEditionId, @ISSN , @PlaceOfPublication, @PublishingHouse)
SELECT @BasePrintEditionId
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewspaperIssue]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddNewspaperIssue]
@NewspaperId INT,
@ReleaseDate DATETIME,
@ReleaseNumber INT,
@NumberOfPages INT
AS
BEGIN
INSERT INTO NewspaperIssues (NewspaperId, ReleaseNumber, NumberOfPages, ReleaseDate, IsDeleted)
VALUES(@NewspaperId,@ReleaseNumber, @NumberOfPages, @ReleaseDate, 0)
DECLARE @NewspaperReturuningId INT
SET @NewspaperReturuningId = SCOPE_IDENTITY()
SELECT @NewspaperReturuningId
END
GO
/****** Object:  StoredProcedure [dbo].[AddPatent]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddPatent]
@AuthorId INT,
@PublicationYear INT,
@Country nvarchar(200),
@RegistrationNumber INT,
@DateOfApplication datetime,
@NumberOfPages INT,
@PublicationDate datetime,
@Annotation nvarchar(2000),
@Title nvarchar(50)
AS
BEGIN
INSERT INTO BasePrintEditions (PublicationYear, Title, Annotation , Type, IsDeleted)
VALUES(@PublicationYear, @Title, @Annotation, 'Patent', 0)
DECLARE @BasePrintEditionId INT
SET @BasePrintEditionId = SCOPE_IDENTITY()
INSERT INTO Patents (BasePrintEditionId,Country, RegistrationNumber, DateOfApplication, NumberOfPages, PublicationDate)
VALUES(@BasePrintEditionId,@Country, @RegistrationNumber, @DateOfApplication, @NumberOfPages, @PublicationDate)
INSERT INTO AuthorshipPatents(AuthorId, PatentId)
VALUES(@AuthorId, @BasePrintEditionId)
SELECT @BasePrintEditionId
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
@Username nvarchar(50),
@Password varbinary(256)
AS
BEGIN
INSERT INTO Users(Username, Password, IsDeleted)
VALUES(@Username,@Password, 0)
DECLARE @NewUserId INT
SET @NewUserId = SCOPE_IDENTITY()
DECLARE @NewUserRoleId INT
SELECT @NewUserRoleId = wr.Id FROM WebsiteRoles wr WHERE RoleName = 'CommonUser' AND IsDeleted = 0
INSERT INTO RolesOfUsers (UserId, WebsiteRoleId)
VALUES(@NewUserId, @NewUserRoleId)
SELECT @NewUserId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAuthorById]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAuthorById]
@AuthorId INT
AS
BEGIN
UPDATE Authors
SET IsDeleted = 1
WHERE Id = @AuthorId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteBookById]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBookById]
@Id INT
AS
BEGIN

UPDATE BasePrintEditions
SET IsDeleted = 1 WHERE Id = @Id AND Type = 'Book'

END
GO
/****** Object:  StoredProcedure [dbo].[DeleteNewspaperById]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteNewspaperById]
@Id INT
AS
BEGIN
UPDATE BasePrintEditions 
SET IsDeleted = 1 WHERE Id = @Id AND Type = 'Newspaper'
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteNewspaperIssue]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteNewspaperIssue]
@Id INT
AS
BEGIN
UPDATE NewspaperIssue
SET IsDeleted = 1 WHERE Id=@Id 

END
GO
/****** Object:  StoredProcedure [dbo].[DeletePatentByID]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeletePatentByID]
@Id INT
AS
BEGIN
UPDATE BasePrintEditions
SET IsDeleted = 1 WHERE Id = @Id AND Type = 'Patent'
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
@Id INT
AS
BEGIN
UPDATE Users
SET IsDeleted = 1 WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserRole]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUserRole]
@UserId INT,
@WebsiteRoleId INT
AS
BEGIN
DELETE FROM RolesOfUsers WHERE UserId = @UserId AND WebsiteRoleId = @WebsiteRoleId
END
GO
/****** Object:  StoredProcedure [dbo].[EditAuthor]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditAuthor]
@Id INT,
@FirstName nvarchar(50),
@LastName Nvarchar(50)
AS
BEGIN
UPDATE Authors 
SET FirstName = @FirstName, LastName = @LastName
WHERE Id = @Id AND IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[EditBook]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditBook]
@Id INT,
@PublicationYear INT,
@Title nvarchar(300),
@Annotation nvarchar(2000),
@ISBN nvarchar(20),
@PlaceOfPublication nvarchar(200),
@PublishingHouse nvarchar(300),
@NumberOfPages INT,
@AuthorId INT
AS
BEGIN
UPDATE BasePrintEditions
SET PublicationYear = @PublicationYear, Title = @Title, Annotation = @Annotation
WHERE Id = @Id AND Type= 'Book' AND IsDeleted = 0
UPDATE Books
SET ISBN = @ISBN, PlaceOfPublication = @PlaceOfPublication, PublishingHouse = @PublishingHouse, NumberOfPages = @NumberOfPages
WHERE BasePrintEditionId = @Id
UPDATE AuthorshipBooks
SET AuthorId = @AuthorId WHERE BookId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[EditNewspaper]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditNewspaper]
@Id INT,
@PublicationYear INT,
@Title nvarchar(300),
@Annotation nvarchar(2000),
@PlaceOfPublication nvarchar(200),
@PublishingHouse nvarchar(300)
AS
BEGIN
UPDATE BasePrintEditions 
SET PublicationYear = @PublicationYear, Title = @Title , Annotation = @Annotation
WHERE Id = @Id AND Type = 'Newspaper' AND IsDeleted = 0
UPDATE Newspapers
SET PlaceOfPublication = @PlaceOfPublication, PublishingHouse = @PublishingHouse
WHERE BasePrintEditionId  = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[EditNewspaperIssue]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditNewspaperIssue]
@NewspaperIssueId INT,
@ReleaseDate DATETIME,
@ReleaseNumber INT,
@NumberOfPages INT
AS
BEGIN
UPDATE NewspaperIssues
SET ReleaseNumber = @ReleaseNumber, NumberOfPages = @NumberOfPages, ReleaseDate = @ReleaseDate
WHERE Id = @NewspaperIssueId AND IsDeleted =0
END
GO
/****** Object:  StoredProcedure [dbo].[EditPatent]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditPatent]
@Id INT,
@Country NVARCHAR(200),
@RegistrationNumber INT,
@PublicationYear INT,
@DateOfApplication DATETIME,
@NumberOfPages INT,
@PublicationDate DATETIME,
@Annotation nvarchar(2000),
@Title nvarchar(300),
@AuthorId INT
AS
BEGIN
UPDATE BasePrintEditions
SET 
	PublicationYear = @PublicationYear, 
	Title = @Title, 
	Annotation = @Annotation
WHERE Id = @Id AND Type='Patent' AND IsDeleted = 0
UPDATE Patents
SET 
	Country = @Country, 
	RegistrationNumber = @RegistrationNumber, 
	DateOfApplication = @DateOfApplication,
	NumberOfPages= @NumberOfPages, 
	PublicationDate = @PublicationDate
WHERE BasePrintEditionId = @Id
UPDATE AuthorshipPatents
SET AuthorId = @AuthorId WHERE PatentId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[FindAllBooksByPublishingHouse]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindAllBooksByPublishingHouse]
@partPublishingHouseName nvarchar(50)
AS
SELECT @partPublishingHouseName = RTRIM(@partPublishingHouseName) + '%'
BEGIN
SELECT * FROM Books WHERE PublishingHouse LIKE @partPublishingHouseName
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAuthors]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAuthors]
AS
BEGIN
SELECT Id,FirstName, LastName
FROM Authors WHERE IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllBooks]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllBooks]
AS
BEGIN
SELECT 
	bpe.Id,
	bpe.PublicationYear,
	bpe.Title,
	bpe.Annotation,
	b.ISBN,
	b.PlaceOfPublication,
	b.PublishingHouse,
	b.NumberOfPages
	FROM dbo.BasePrintEditions bpe
	INNER JOIN dbo.Books b ON bpe.Id = b.BasePrintEditionId
	WHERE IsDeleted = 0 AND bpe.Type = 'Book'
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllCatalogForDownloading]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCatalogForDownloading]
AS
BEGIN
SELECT 
	bpe.Id,
	bpe.Annotation,
	bpe.Title,
	bpe.PublicationYear,
	bpe.[Type],
	b.PlaceOfPublication AS BookPlaceOfPublication,
	b.PublishingHouse AS BookPublishingHouse,
	b.ISBN AS BookISBN,
	b.NumberOfPages AS BookNumberOfPages,
	p.Country  AS PatentCountry,
	p.DateOfApplication AS PatentDateOfApplication,
	p.NumberOfPages AS PatentNumberOfPages,
	p.PublicationDate AS PatentPublicationDate,
	p.RegistrationNumber AS PatentRegistrationNumber,
	n.ISSN AS NewspaperISSN,
	n.PlaceOfPublication AS NewspaperPlaceOfPublication,
	n.PublishingHouse AS NewspaperPublishingHouse,
	ni.ReleaseNumber AS NewspaperIssueReleaseNumber,
	ni.NumberOfPages AS NewspaperIssueNumberOfPages,
	ni.ReleaseDate AS NewspaperIssueReleaseDate,
	ni.NewspaperId AS NewspaperIssueNewspaperId

FROM dbo.BasePrintEditions bpe 
LEFT JOIN dbo.Books b ON bpe.Id = b.BasePrintEditionId
LEFT JOIN dbo.Patents p ON bpe.Id = p.BasePrintEditionId
lEFT JOIN dbo.Newspapers n ON bpe.Id = n.BasePrintEditionId
LEFT JOIN dbo.NewspaperIssues ni ON ni.NewspaperId = n.BasePrintEditionId
WHERE bpe.IsDeleted = 0

END
GO
/****** Object:  StoredProcedure [dbo].[GetAllNewspaperIssuesByNewspaperId]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllNewspaperIssuesByNewspaperId]
@NewspaperId INT
AS
BEGIN
SELECT 
	ni.Id,
	ni.NewspaperId,
	ni.ReleaseNumber,
	ni.NumberOfPages,
	ni.ReleaseDate
FROM dbo.NewspaperIssues ni
WHERE NewspaperId = @NewspaperId AND ni.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllNewspapers]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllNewspapers]
AS
BEGIN
SELECT 
	bpe.Id,
	bpe.PublicationYear,
	bpe.Title,
	bpe.Annotation,
	n.ISSN,
	n.PlaceOfPublication,
	n.PublishingHouse
FROM dbo.BasePrintEditions bpe
INNER JOIN dbo.Newspapers n ON bpe.Id = n.BasePrintEditionId
WHERE bpe.IsDeleted = 0 AND Type = 'Newspaper'
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllPatents]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllPatents]
AS
BEGIN
SELECT
	bpe.Id,
	bpe.PublicationYear,
	bpe.Title,
	bpe.Annotation,
	p.Country,
	p.DateOfApplication,
	p.PublicationDate,
	p.NumberOfPages,
	p.RegistrationNumber
FROM dbo.BasePrintEditions bpe 
INNER JOIN dbo.Patents p ON bpe.Id = p.BasePrintEditionId
WHERE bpe.IsDeleted = 0 AND Type = 'Patent'
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllPrintEditions]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllPrintEditions]
AS
BEGIN
SELECT 
	bpe.Id,
	bpe.Annotation,
	bpe.Title,
	bpe.PublicationYear,
	bpe.[Type],
	b.PlaceOfPublication AS BookPlaceOfPublication,
	b.PublishingHouse AS BookPublishingHouse,
	b.ISBN AS BookISBN,
	b.NumberOfPages AS BookNumberOfPages,
	p.Country  AS PatentCountry,
	p.DateOfApplication AS PatentDateOfApplication,
	p.NumberOfPages AS PatentNumberOfPages,
	p.PublicationDate AS PatentPublicationDate,
	p.RegistrationNumber AS PatentRegistrationNumber,
	n.ISSN AS NewspaperISSN,
	n.PlaceOfPublication AS NewspaperPlaceOfPublication,
	n.PublishingHouse AS NewspaperPublishingHouse

FROM dbo.BasePrintEditions bpe 
LEFT JOIN dbo.Books b ON bpe.Id = b.BasePrintEditionId
LEFT JOIN dbo.Patents p ON bpe.Id = p.BasePrintEditionId
lEFT JOIN dbo.Newspapers n ON bpe.Id = n.BasePrintEditionId
WHERE bpe.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllPrintEditionsSortedByPublicationYear]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllPrintEditionsSortedByPublicationYear]
AS
BEGIN
SELECT 
	bpe.Id,
	bpe.Annotation,
	bpe.Title,
	bpe.PublicationYear,
	bpe.[Type],
	b.PlaceOfPublication AS BookPlaceOfPublication,
	b.PublishingHouse AS BookPublishingHouse,
	b.ISBN AS BookISBN,
	b.NumberOfPages AS BookNumberOfPages,
	p.Country  AS PatentCountry,
	p.DateOfApplication AS PatentDateOfApplication,
	p.NumberOfPages AS PatentNumberOfPages,
	p.PublicationDate AS PatentPublicationDate,
	p.RegistrationNumber AS PatentRegistrationNumber,
	n.ISSN AS NewspaperISSN,
	n.PlaceOfPublication AS NewspaperPlaceOfPublication,
	n.PublishingHouse AS NewspaperPublishingHouse
FROM dbo.BasePrintEditions bpe 
LEFT JOIN dbo.Books b ON bpe.Id = b.BasePrintEditionId
LEFT JOIN dbo.Patents p ON bpe.Id = p.BasePrintEditionId
lEFT JOIN dbo.Newspapers n ON bpe.Id = n.BasePrintEditionId
WHERE bpe.IsDeleted = 0
ORDER BY bpe.PublicationYear 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllPrintEditionsSortedByPublicatoinYearDescending]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllPrintEditionsSortedByPublicatoinYearDescending]
AS
BEGIN
SELECT 
	bpe.Id,
	bpe.Annotation,
	bpe.Title,
	bpe.PublicationYear,
	bpe.[Type],
	b.PlaceOfPublication AS BookPlaceOfPublication,
	b.PublishingHouse AS BookPublishingHouse,
	b.ISBN AS BookISBN,
	b.NumberOfPages AS BookNumberOfPages,
	p.Country  AS PatentCountry,
	p.DateOfApplication AS PatentDateOfApplication,
	p.NumberOfPages AS PatentNumberOfPages,
	p.PublicationDate AS PatentPublicationDate,
	p.RegistrationNumber AS PatentRegistrationNumber,
	n.ISSN AS NewspaperISSN,
	n.PlaceOfPublication AS NewspaperPlaceOfPublication,
	n.PublishingHouse AS NewspaperPublishingHouse
FROM dbo.BasePrintEditions bpe 
LEFT JOIN dbo.Books b ON bpe.Id = b.BasePrintEditionId
LEFT JOIN dbo.Patents p ON bpe.Id = p.BasePrintEditionId
lEFT JOIN dbo.Newspapers n ON bpe.Id = n.BasePrintEditionId
WHERE bpe.IsDeleted = 0
ORDER BY bpe.PublicationYear DESC
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllRoles]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllRoles]
AS
BEGIN
SELECT 
wr.Id,
wr.RoleName
FROM WebsiteRoles wr
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
SELECT 
	u.Id,
	u.Username
FROM dbo.Users u
LEFT JOIN dbo.RolesOfUsers rou ON u.Id = rou.UserId 
WHERE u.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetAuthorByBookId]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAuthorByBookId]
@BookId INT
AS
BEGIN
SELECT 
	a.Id,
	a.FirstName,
	a.LastName
FROM dbo.Authors a
INNER JOIN dbo.AuthorshipBooks ab ON a.Id = ab.AuthorId
INNER JOIN dbo.Books b ON b.BasePrintEditionId = ab.BookId
WHERE ab.BookId = @BookId AND a.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetAuthorById]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAuthorById]
@AuthorId INT
AS
BEGIN
SELECT 
	a.Id,
	a.FirstName,
	a.LastName
FROM dbo.Authors  a 
WHERE a.Id =@AuthorId AND a.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetAuthorByPatentId]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAuthorByPatentId]
@PatentId INT
AS
BEGIN
SELECT
	a.Id,
	a.FirstName,
	a.LastName
FROM dbo.Authors a
INNER JOIN dbo.AuthorshipPatents ap ON a.Id = ap.AuthorId
INNER JOIN dbo.Patents p ON p.BasePrintEditionId = ap.PatentId
WHERE ap.PatentId = @PatentId AND a.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetAuthorBySearchText]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAuthorBySearchText]
@SearchString nvarchar(50)
AS
SELECT @SearchString = RTRIM(@SearchString) + '%' 
BEGIN
SELECT 
a.Id,
a.FirstName,
a.LastName
FROM Authors a WHERE FirstName LIKE @SearchString OR LastName LIKE @SearchString AND IsDeleted=0
END
GO
/****** Object:  StoredProcedure [dbo].[GetBookById]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBookById]
@Id INT
AS
BEGIN
SELECT 
	bpe.Id,
	bpe.PublicationYear,
	bpe.Title,
	bpe.Annotation,
	b.ISBN,
	b.PlaceOfPublication,
	b.PublishingHouse,
	b.NumberOfPages
FROM dbo.BasePrintEditions bpe
INNER JOIN dbo.Books b ON bpe.Id = b.BasePrintEditionId
WHERE bpe.Id = @Id AND bpe.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetBooksByAuthorId]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBooksByAuthorId]
@AuthorId INT
AS
BEGIN
SELECT 
	bpe.Id,
	bpe.Annotation,
	bpe.Title,
	bpe.PublicationYear,
	b.ISBN,
	b.NumberOfPages,
	b.PlaceOfPublication,
	b.PublishingHouse
FROM dbo.BasePrintEditions bpe
INNER JOIN dbo.Books b ON bpe.Id = b.BasePrintEditionId
INNER JOIN dbo.AuthorshipBooks ab ON ab.BookId =  b.BasePrintEditionId
WHERE ab.AuthorId = @AuthorId AND bpe.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetNewspaperById]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetNewspaperById]
@Id INT
AS
BEGIN
SELECT 
	bpe.Id,
	bpe.PublicationYear,
	bpe.Title,
	bpe.Annotation,
	n.ISSN,
	n.PlaceOfPublication,
	n.PublishingHouse
FROM dbo.BasePrintEditions bpe 
INNER JOIN dbo.Newspapers n ON bpe.Id = n.BasePrintEditionId
WHERE bpe.Id = @Id AND bpe.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetNewspaperIssueById]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetNewspaperIssueById]
@Id INT
AS
BEGIN
SELECT 
	ni.Id,
	ni.NewspaperId,
	ni.ReleaseNumber,
	ni.NumberOfPages,
	ni.ReleaseDate
FROM NewspaperIssues ni WHERE ni.Id = @Id AND ni.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetPages]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPages]
@skip INT = 0,
@limit INT = 10000
AS
BEGIN
SELECT 
	bpe.Id,
	bpe.Annotation,
	bpe.Title,
	bpe.PublicationYear,
	bpe.[Type],
	b.PlaceOfPublication AS BookPlaceOfPublication,
	b.PublishingHouse AS BookPublishingHouse,
	b.ISBN AS BookISBN,
	b.NumberOfPages AS BookNumberOfPages,
	p.Country  AS PatentCountry,
	p.DateOfApplication AS PatentDateOfApplication,
	p.NumberOfPages AS PatentNumberOfPages,
	p.PublicationDate AS PatentPublicationDate,
	p.RegistrationNumber AS PatentRegistrationNumber,
	n.ISSN AS NewspaperISSN,
	n.PlaceOfPublication AS NewspaperPlaceOfPublication,
	n.PublishingHouse AS NewspaperPublishingHouse

FROM dbo.BasePrintEditions bpe 
LEFT JOIN dbo.Books b ON bpe.Id = b.BasePrintEditionId
LEFT JOIN dbo.Patents p ON bpe.Id = p.BasePrintEditionId
lEFT JOIN dbo.Newspapers n ON bpe.Id = n.BasePrintEditionId
WHERE bpe.IsDeleted = 0
ORDER BY Id
OFFSET @skip ROWS
FETCH NEXT @limit ROWS Only;

SELECT count(*) as [TotalCount] FROM BasePrintEditions;
END
GO
/****** Object:  StoredProcedure [dbo].[GetPagesByFilterParameters]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPagesByFilterParameters]
@skip INT = 0,
@limit INT = 10000,
@partTitle nvarchar(150) ,
@partAuthorName nvarchar(25) ,
@sortString nvarchar(30)
AS
BEGIN
SELECT 
	bpe.Id,
	bpe.Annotation,
	bpe.Title,
	bpe.PublicationYear,
	bpe.[Type],
	b.PlaceOfPublication AS BookPlaceOfPublication,
	b.PublishingHouse AS BookPublishingHouse,
	b.ISBN AS BookISBN,
	b.NumberOfPages AS BookNumberOfPages,
	p.Country  AS PatentCountry,
	p.DateOfApplication AS PatentDateOfApplication,
	p.NumberOfPages AS PatentNumberOfPages,
	p.PublicationDate AS PatentPublicationDate,
	p.RegistrationNumber AS PatentRegistrationNumber,
	n.ISSN AS NewspaperISSN,
	n.PlaceOfPublication AS NewspaperPlaceOfPublication,
	n.PublishingHouse AS NewspaperPublishingHouse,
	afb.FirstName,
	afb.LastName
	
FROM (SELECT * FROM dbo.BasePrintEditions WHERE @partAuthorName = '' OR  Id IN (SELECT COALESCE(ap.PatentId, ab.BookId) as aaaId FROM (SELECT * FROM dbo.Authors  WHERE FirstName+' '+LastName LIKE '%'+@partAuthorName+'%') as aaa
														LEFT JOIN dbo.AuthorshipPatents ap ON ap.AuthorId =  aaa.Id
														LEFT JOIN dbo.AuthorshipBooks ab ON ab.AuthorId =  aaa.Id)) bpe 




LEFT JOIN dbo.Books b ON bpe.Id = b.BasePrintEditionId
LEFT JOIN dbo.Patents p ON bpe.Id = p.BasePrintEditionId
LEFT JOIN dbo.Newspapers n ON bpe.Id = n.BasePrintEditionId
LEFT JOIN dbo.AuthorshipBooks ab ON ab.BookId =  b.BasePrintEditionId
LEFT JOIN dbo.AuthorshipPatents ap ON ap.PatentId =  p.BasePrintEditionId
LEFT JOIN (SELECT * FROM dbo.Authors  WHERE FirstName+' '+LastName LIKE '%'+@partAuthorName+'%') afb ON afb.Id = ab.AuthorId OR afb.Id = ap.AuthorId

WHERE bpe.IsDeleted = 0 
AND (@partTitle IS NULL OR bpe.Title LIKE '%'+@partTitle+'%' )
ORDER BY 
CASE WHEN @sortString='asc' THEN bpe.PublicationYear END ASC,
CASE WHEN @sortString='desc' THEN bpe.PublicationYear END DESC
OFFSET @skip ROWS
FETCH NEXT @limit ROWS ONLY;

SELECT count(*) as [TotalCount] FROM BasePrintEditions;
END
GO
/****** Object:  StoredProcedure [dbo].[GetPatentById]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPatentById]
@Id INT
AS
BEGIN
SELECT 
	bpe.Id,
	bpe.PublicationYear,
	bpe.Title,
	bpe.Annotation,
	p.Country,
	p.DateOfApplication,
	p.PublicationDate,
	p.NumberOfPages,
	p.RegistrationNumber
FROM dbo.BasePrintEditions bpe 
INNER JOIN dbo.Patents p ON bpe.Id = p.BasePrintEditionId
WHERE bpe.Id = @Id AND bpe.IsDeleted =0
END
GO
/****** Object:  StoredProcedure [dbo].[GetPatentsAndBooksByAuthorId]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPatentsAndBooksByAuthorId]
@AuthorId INT
AS
BEGIN
SELECT 
	bpe.Id,
	bpe.Annotation,
	bpe.Title,
	bpe.PublicationYear,
	bpe.[Type],
	b.PlaceOfPublication,
	b.PublishingHouse,
	b.ISBN,
	b.NumberOfPages AS BookNumberOfPages,
	p.Country,
	p.DateOfApplication,
	p.PublicationDate,
	p.RegistrationNumber,
	p.NumberOfPages AS PatentNumberOfPages
FROM dbo.BasePrintEditions bpe 
LEFT JOIN dbo.Books b ON bpe.Id = b.BasePrintEditionId
LEFT JOIN dbo.Patents p ON bpe.Id = p.BasePrintEditionId
LEFT JOIN dbo.AuthorshipBooks ab ON b.BasePrintEditionId = ab.BookId
LEFT JOIN dbo.AuthorshipPatents ap ON p.BasePrintEditionId = ap.PatentId
WHERE (ab.AuthorId = @AuthorId OR ap.AuthorId = @AuthorId) AND bpe.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetPatentsByAuthorId]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPatentsByAuthorId]
@AuthorId INT
AS
BEGIN
SELECT 
	bpe.Id,
	bpe.Annotation,
	bpe.Title,
	bpe.PublicationYear,
	p.Country,
	p.DateOfApplication,
	p.NumberOfPages,
	p.PublicationDate,
	p.RegistrationNumber
FROM dbo.BasePrintEditions bpe
INNER JOIN dbo.Patents p  ON bpe.Id = p.BasePrintEditionId
INNER JOIN dbo.AuthorshipPatents ap ON ap.PatentId =  p.BasePrintEditionId
WHERE ap.AuthorId = @AuthorId AND bpe.IsDeleted = 0 
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserById]
@Id INT
AS
BEGIN
SELECT u.Id, u.Username FROM Users u WHERE u.Id = @Id AND IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserIdByUsername]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserIdByUsername]
@Username nvarchar(50)
AS
BEGIN
SELECT u.Id FROM Users u WHERE Username = @Username AND IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserRole]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserRole]
@Id INT
AS
BEGIN
SELECT wr.RoleName FROM WebsiteRoles wr
INNER JOIN RolesOfUsers rou ON rou.WebsiteRoleId = wr.Id
WHERE rou.UserId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GiveRoleToUser]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GiveRoleToUser]
@UserId INT,
@WebsiteRoleId INt
AS
BEGIN
UPDATE RolesOfUsers
SET WebsiteRoleId = @WebsiteRoleId
WHERE UserId = @UserId

END
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 11/30/2020 12:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Login]
@Username  nvarchar(50),
@Password nvarchar(256)
AS
BEGIN
	SELECT COUNT(*) FROM Users WHERE Username=@Username AND Password=@Password AND IsDeleted =0
END
GO
USE [master]
GO
ALTER DATABASE [RokolabsLibraryTestDBO] SET  READ_WRITE 
GO
