CREATE PROCEDURE [dbo].[usp_GetMovieMovieTagRelationships]
	@MovieTagId int,
	@MovieId char(9)
AS
	SELECT MovieId, MovieTagId, MovieMovieTagRelationshipId
	FROM dbo.MovieMovieTagRelationships
	WHERE MovieTagId = @MovieTagId
	AND MovieId = @MovieId
RETURN 0

