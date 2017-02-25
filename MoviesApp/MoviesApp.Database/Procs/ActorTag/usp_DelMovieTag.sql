CREATE PROCEDURE [dbo].[usp_DelMovieTag]
	@id int
AS
	DELETE FROM MovieTags
	WHERE MovieTagID = @id
RETURN 0
