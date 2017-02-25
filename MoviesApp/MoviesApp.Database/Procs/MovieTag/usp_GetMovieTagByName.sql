CREATE PROCEDURE [dbo].[usp_GetMovieTagByName]
	@TagDescription varchar(20)
AS
	SELECT MovieTagId, TagDescription
	FROM dbo.MovieTags
	WHERE @TagDescription = TagDescription
RETURN 0
