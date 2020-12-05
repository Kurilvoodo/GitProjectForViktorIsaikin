CREATE PROCEDURE GetPatentsByAuthorId
@AuthorId INT
AS
BEGIN
SELECT * FROM Patent 
JOIN AuthorshipLinks AS AuthLink ON
	Patent.Id = AuthLink.BookId
END