CREATE PROCEDURE [dbo].[usp_InsActorMovieRelationship]
	@MovieId char(9),
	@ActorId int
AS
	INSERT INTO ActorMovieRelationships (MovieId, ActorId)
	VALUES (@MovieId, @ActorId)
RETURN 0
