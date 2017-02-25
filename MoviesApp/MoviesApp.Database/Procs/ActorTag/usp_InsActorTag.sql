CREATE PROCEDURE [dbo].[usp_InsActorTag]
	@TagDescription varchar(20)
AS
	INSERT INTO ActorTags(TagDescription)
	OUTPUT INSERTED.ActorTagId
	VALUES (@TagDescription)
RETURN 0