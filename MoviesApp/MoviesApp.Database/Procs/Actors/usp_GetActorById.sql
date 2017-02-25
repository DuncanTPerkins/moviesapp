CREATE PROCEDURE [dbo].[usp_GetActorById]
	@id int
AS
	SELECT * 
	FROM Actors a
	LEFT OUTER JOIN ActorMovieRelationships amr
	ON amr.ActorId = a.ActorId
	LEFT OUTER JOIN Movies m
	ON m.MovieId = amr.MovieId
	LEFT OUTER JOIN ActorActorTagRelationships aatr 
	ON a.ActorId = aatr.ActorId
	WHERE a.ActorId = @id
RETURN 0