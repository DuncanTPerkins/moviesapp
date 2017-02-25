CREATE PROCEDURE [dbo].[usp_GetActorMovieRelationshipByMovie]
	@MovieId char(9)
AS
	SELECT *
	FROM ActorMovieRelationships
	WHERE MovieId = @MovieId
RETURN 0
