CREATE PROCEDURE [dbo].[usp_InsMovieMovieTagRelationships]
	@MovieTagId int,
	@MovieId char(9)
AS
	INSERT INTO dbo.MovieMovieTagRelationships (MovieId, MovieTagId)
	VALUES (@MovieId, @MovieTagId)
RETURN 0

