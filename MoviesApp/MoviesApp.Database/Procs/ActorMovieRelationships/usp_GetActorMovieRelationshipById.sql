CREATE PROCEDURE [dbo].[usp_GetActorMovieRelationshipById]
	@ActorMovieRelationshipId int
AS
	SELECT * 
	FROM ActorMovieRelationships
	WHERE ActorMovieRelationshipId = @ActorMovieRelationshipId
RETURN 0
