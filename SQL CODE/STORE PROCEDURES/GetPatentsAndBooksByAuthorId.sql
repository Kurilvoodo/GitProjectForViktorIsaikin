CREATE PROCEDURE GetPatentsAndBooksByAuthorId
@AuthorId INT
AS
BEGIN
SELECT *
FROM Books JOIN AuthorshipLinks ON Books.Id = AuthorshipLinks.BookId
JOIN Patent ON Patent.Id = AuthorshipLinks.PatentId
WHERE AuthorshipLinks.AuthorId = @AuthorId
END