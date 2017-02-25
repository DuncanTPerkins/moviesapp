CREATE PROCEDURE [dbo].[usp_GetMovieTagById]
	@id int
AS
	SELECT * 
	FROM MovieTags
	WHERE MovieTagId = @id
RETURN 0
