CREATE PROCEDURE DeletePatentByID
@Id INT
AS
BEGIN
DELETE FROM Patents WHERE Id = @Id
END