USE [RokolabsLibraryTestDBO]
GO
/****** Object:  StoredProcedure [dbo].[AddNewspaper]    Script Date: 10/29/2020 5:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AddNewspaper]
@AuthorId INT,
@ISSN nvarchar(10),
@PublicationYear INT,
@Title nvarchar(300),
@Annotation nvarchar(2000),
@PlaceOfPublication nvarchar(200),
@PublishingHouse nvarchar(300),
@NumberOfPages INT
AS
BEGIN
INSERT INTO Newspapers (ISSN, PublicationYear, Title, Annotation, PlaceOfPublication, PublishingHouse, NumberOfPages)
VALUES (@ISSN , @PublicationYear, @Title , @Annotation , @PlaceOfPublication, @PublishingHouse, @NumberOfPages)
INSERT INTO AuthorshipLinks (AuthorId, NewspaperId)
VALUES (@AuthorId, SCOPE_IDENTITY())
END