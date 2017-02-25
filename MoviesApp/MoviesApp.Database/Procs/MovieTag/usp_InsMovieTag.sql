CREATE PROCEDURE [dbo].[usp_InsMovieTag]
	@TagDescription varchar(20)
AS
	INSERT INTO MovieTags(TagDescription)
	OUTPUT INSERTED.MovieTagId
	VALUES (@TagDescription)
RETURN 0
