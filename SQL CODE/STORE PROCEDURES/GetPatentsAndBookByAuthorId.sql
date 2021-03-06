USE [RokolabsLibraryTestDBO]
GO
/****** Object:  StoredProcedure [dbo].[GetPatentsAndBooksByAuthorId]    Script Date: 11/2/2020 9:31:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetPatentsAndBooksByAuthorId]
@AuthorId INT
AS
BEGIN
SELECT *
FROM Books JOIN AuthorshipLinks ON Books.Id = AuthorshipLinks.BookId
JOIN Patents ON Patents.Id = AuthorshipLinks.PatentId
WHERE AuthorshipLinks.AuthorId = @AuthorId
END