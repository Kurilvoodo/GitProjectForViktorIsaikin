USE [RokolabsLibraryTestDBO]
GO
/****** Object:  StoredProcedure [dbo].[GetBooksByAuthorId]    Script Date: 10/29/2020 5:26:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetBooksByAuthorId]
@AuthorId INT
AS
BEGIN
SELECT * 
FROM Books JOIN AuthorshipLinks ON Books.Id = AuthorshipLinks.BookId
WHERE AuthorshipLinks.AuthorId = @AuthorId
END