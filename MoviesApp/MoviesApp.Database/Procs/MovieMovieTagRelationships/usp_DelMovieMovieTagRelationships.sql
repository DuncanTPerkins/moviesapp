CREATE PROCEDURE [dbo].[usp_DelMovieMovieTagRelationships]
	@MovieId char(9),
	@MovieTagId int
AS
	DELETE FROM MovieMovieTagRelationships
	WHERE MovieId = @MovieId
	AND MovieTagId = @MovieTagId
RETURN 0
