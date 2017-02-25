CREATE PROCEDURE [dbo].[usp_GetActorMovieRelationshipByActor]
	@ActorId int
AS
	SELECT *
	FROM ActorMovieRelationships
	WHERE ActorId = @ActorId 
RETURN 0
