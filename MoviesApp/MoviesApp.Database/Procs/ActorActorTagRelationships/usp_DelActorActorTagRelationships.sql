CREATE PROCEDURE [dbo].[usp_DelActorActorTagRelationships]
	@ActorId int,
	@ActorTagId int
AS
	DELETE FROM ActorActorTagRelationships
	WHERE ActorId = @ActorId
	AND ActorTagId = @ActorTagId
RETURN 0
