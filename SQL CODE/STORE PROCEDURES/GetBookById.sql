CREATE PROCEDURE GetBookById
@Id INT
AS
BEGIN
SELECT ISBN, PublicationYear, Title, Annotation, PlaceOfPublication , PublishingHouse, NumberOfPages FROM Books WHERE Id = @Id
END