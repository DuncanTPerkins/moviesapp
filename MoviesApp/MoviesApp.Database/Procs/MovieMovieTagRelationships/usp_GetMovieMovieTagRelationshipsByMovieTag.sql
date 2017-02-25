CREATE PROCEDURE [dbo].[usp_GetMovieMovieTagRelationshipsByMovieTag]
	@MovieTagId int
AS
	SELECT MovieId, MovieTagId, MovieMovieTagRelationshipId
	FROM dbo.MovieMovieTagRelationships
	WHERE MovieTagId = @MovieTagId
RETURN 0

