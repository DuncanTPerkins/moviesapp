CREATE PROCEDURE [dbo].[usp_InsActorActorTagRelationships]
	@ActorTagId int,
	@ActorId int
AS
	INSERT INTO dbo.ActorActorTagRelationships (ActorId, ActorTagId)
	VALUES (@ActorId, @ActorTagId)
RETURN 0

