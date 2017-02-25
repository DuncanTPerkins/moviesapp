CREATE PROCEDURE [dbo].[usp_GetActorActorTagRelationships]
	@ActorTagId int,
	@ActorId int
AS
	SELECT ActorId, ActorTagId, ActorActorTagRelationshipId
	FROM dbo.ActorActorTagRelationships
	WHERE ActorTagId = @ActorTagId
	AND ActorId = @ActorId
RETURN 0

