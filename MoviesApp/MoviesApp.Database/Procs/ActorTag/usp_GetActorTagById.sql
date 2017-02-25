CREATE PROCEDURE [dbo].[usp_GetActorTagById]
	@id int
AS
	SELECT * 
	FROM ActorTags
	WHERE ActorTags.ActorTagID = @id
RETURN 0
