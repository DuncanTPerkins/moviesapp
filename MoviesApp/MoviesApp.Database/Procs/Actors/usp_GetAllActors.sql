CREATE PROCEDURE [dbo].[usp_GetAllActors]
AS
	SELECT *
	FROM Actors a
	LEFT OUTER JOIN ActorMovieRelationships amr
	ON amr.ActorId = a.ActorId
	LEFT OUTER JOIN Movies m
	ON m.MovieId = amr.MovieId
	LEFT OUTER JOIN ActorActorTagRelationships aatr
	ON aatr.ActorId = a.ActorId
	LEFT OUTER JOIN ActorTags at
	ON at.ActorTagId = aatr.ActorTagId
	ORDER BY a.ActorId, aatr.ActorTagId
RETURN 0