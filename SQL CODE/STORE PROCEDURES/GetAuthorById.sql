CREATE PROCEDURE GetAuthorById
@Id INT
AS
BEGIN
SELECT * FROM Authors WHERE Id =@Id
END