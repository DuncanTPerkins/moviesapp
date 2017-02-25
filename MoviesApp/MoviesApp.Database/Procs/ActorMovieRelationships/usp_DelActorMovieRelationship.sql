CREATE PROCEDURE [dbo].[usp_DelActorMovieRelationship]
	@ActorMovieRelationshipId  int
AS
	DELETE FROM ActorMovieRelationships
	WHERE ActorMovieRelationshipId = @ActorMovieRelationshipId
RETURN 0
