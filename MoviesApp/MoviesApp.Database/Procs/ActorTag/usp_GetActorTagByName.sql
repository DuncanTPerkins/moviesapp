CREATE PROCEDURE [dbo].[usp_GetActorTagByName]
	@TagDescription varchar(20)
AS
	SELECT ActorTagId, TagDescription
	FROM dbo.ActorTags
	WHERE @TagDescription = TagDescription
RETURN 0
