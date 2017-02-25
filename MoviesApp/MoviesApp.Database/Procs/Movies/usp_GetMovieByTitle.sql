CREATE PROCEDURE [dbo].[usp_GetMovieByTitle]
	@title varchar(150)
AS
	SELECT *
	FROM dbo.Movies m
	LEFT OUTER JOIN dbo.ActorMovieRelationships amr
	ON amr.MovieId = m.MovieId
	LEFT OUTER JOIN dbo.Actors a
	ON a.ActorId = amr.ActorId
	LEFT OUTER JOIN MovieMovieTagRelationships mmtr
	ON m.MovieId = mmtr.MovieId
	LEFT OUTER JOIN dbo.MovieTags mt
	ON mt.MovieTagId = mmtr.MovieTagId
	WHERE m.Title = @title

RETURN 0