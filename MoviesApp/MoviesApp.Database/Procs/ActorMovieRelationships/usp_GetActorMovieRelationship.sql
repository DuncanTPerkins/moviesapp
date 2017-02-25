CREATE PROCEDURE [dbo].[usp_GetActorMovieRelationship]
	@MovieId char(9),
	@ActorId int
AS
	SELECT *
	FROM ActorMovieRelationships
	WHERE MovieId = @MovieId
	AND 
	ActorId = @ActorId
RETURN 0
