USE [RokolabsLibraryTestDBO]
GO
/****** Object:  StoredProcedure [dbo].[AddBook]    Script Date: 10/29/2020 5:05:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AddBook]
@AuthorId INT,
@ISBN nvarchar(10),
@PublicationYear INT,
@Title nvarchar(300),
@Annotation nvarchar(2000),
@PlaceOfPublication nvarchar(200),
@PublishingHouse nvarchar(300),
@NumberOfPages INT
AS
BEGIN
INSERT INTO Books (ISBN, PublicationYear, Title, Annotation, PlaceOfPublication , PublishingHouse, NumberOfPages)
VALUES (@ISBN, @PublicationYear, @Title, @Annotation, @PlaceOfPublication, @PublishingHouse, @NumberOfPages)
INSERT INTO AuthorshipLinks (AuthorId,BookId)
VALUES (@AuthorId,SCOPE_IDENTITY())
END