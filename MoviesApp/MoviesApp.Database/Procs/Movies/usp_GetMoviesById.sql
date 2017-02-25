CREATE PROCEDURE [dbo].[usp_GetMoviesById]
	@id char(9)
AS
	SELECT * 
	FROM dbo.Movies m
	LEFT OUTER JOIN dbo.ActorMovieRelationships amr
	ON amr.MovieID = m.MovieID
	LEFT OUTER JOIN dbo.Actors a
	ON a.ActorID = amr.ActorID
	LEFT OUTER JOIN MovieMovieTagRelationships mmtr
	ON m.MovieId = mmtr.MovieId
	LEFT OUTER JOIN dbo.MovieTags mt
	ON mt.MovieTagId = mmtr.MovieTagId
	WHERE m.MovieID = @id
RETURN 0