USE [RokolabsLibraryTestDBO]
GO
/****** Object:  StoredProcedure [dbo].[EditPatent]    Script Date: 10/30/2020 1:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[EditPatent]
@Id INT,
@Country nvarchar(200),
@RegistrationNumber INT,
@DateOfApplication datetime,
@NumberOfPages INT,
@PublicationDate datetime,
@Annotation nvarchar(2000),
@Title nvarchar(300)
AS
BEGIN
UPDATE Patents
SET Country = @Country, RegistrationNumber = @RegistrationNumber, DateOfApplication = @DateOfApplication, NumberOfPages = @NumberOfPages, PublicationDate = @PublicationDate, Annotation = @Annotation, Title = @Title
WHERE Id = @Id
END