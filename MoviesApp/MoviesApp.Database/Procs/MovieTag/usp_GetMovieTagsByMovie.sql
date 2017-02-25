CREATE PROCEDURE [dbo].[usp_GetMovieTagsByMovie]
	@MovieId char(9)
AS
	SELECT mt.MovieTagId, mt.TagDescription
	FROM dbo.MovieMovieTagRelationships mmtr
	LEFT OUTER JOIN dbo.MovieTags mt
	ON mmtr.MovieTagId = mt.MovieTagId
	WHERE MovieId = @MovieId
RETURN 0

