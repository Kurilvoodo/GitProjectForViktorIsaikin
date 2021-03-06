USE [RokolabsLibraryTestDBO]
GO
/****** Object:  StoredProcedure [dbo].[AddPatent]    Script Date: 10/30/2020 10:26:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AddPatent]
@AuthorId INT,
@Country nvarchar(200),
@RegistrationNumber INT,
@DateOfApplication datetime,
@NumberOfPages INT,
@PublicationDate datetime,
@Annotation nvarchar(2000),
@Title nvarchar(50)
AS
BEGIN
INSERT INTO Patents (Country, RegistrationNumber, DateOfApplication, NumberOfPages, PublicationDate, Annotation, Title)
VALUES(@Country, @RegistrationNumber, @DateOfApplication, @NumberOfPages, @PublicationDate, @Annotation, @Title)
INSERT INTO AuthorshipLinks (AuthorId, PatentId)
VALUES(@AuthorId, SCOPE_IDENTITY())
END