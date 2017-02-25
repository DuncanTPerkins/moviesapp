CREATE PROCEDURE [dbo].[usp_DelActorTag]
	@id int
AS
	DELETE FROM MovieTags
	WHERE MovieTagId = @id
RETURN 0
