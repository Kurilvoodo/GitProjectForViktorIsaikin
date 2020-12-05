CREATE PROCEDURE FindAllBooksByPublishingHouse
@partPublishingHouseName nvarchar(50)
AS
SELECT @partPublishingHouseName = RTRIM(@partPublishingHouseName) + '%'
BEGIN
SELECT * FROM Books WHERE PublishingHouse LIKE @partPublishingHouseName
END