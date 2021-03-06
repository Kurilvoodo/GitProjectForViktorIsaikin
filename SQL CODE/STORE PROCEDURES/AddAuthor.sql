USE [RokolabsLibraryTestDBO]
GO
/****** Object:  StoredProcedure [dbo].[AddPatent]    Script Date: 10/29/2020 5:12:26 PM ******/
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
@Annotation nvarchar(2000)
AS
BEGIN
INSERT INTO Patents (Country, RegistrationNumber, DateOfApplication, NumberOfPages, PublicationDate, Annotation)
VALUES(@Country, @RegistrationNumber, @DateOfApplication, @NumberOfPages, @PublicationDate, @Annotation)
INSERT INTO AuthorshipLinks (AuthorId, PatentId)
VALUES(@AuthorId, SCOPE_IDENTITY())
END