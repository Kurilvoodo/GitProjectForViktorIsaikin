CREATE PROCEDURE EditBook
@Id INT,
@ISBN nvarchar(10),
@PublicationYear INT,
@Title nvarchar(300),
@Annotation nvarchar(2000),
@PlaceOfPublication nvarchar(200),
@PublishingHouse nvarchar(300),
@NumberOfPages INT
AS
BEGIN
UPDATE Books 
SET ISBN = @ISBN, PublicationYear= @PublicationYear, Title= @Title, Annotation = @Annotation, PlaceOfPublication = @PlaceOfPublication, PublishingHouse = @PublishingHouse, NumberOfPages = @NumberOfPages
WHERE Id = @Id;
END