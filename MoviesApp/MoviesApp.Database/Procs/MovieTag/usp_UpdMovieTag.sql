CREATE PROCEDURE [dbo].[usp_UpdMovieTags]
	@MovieTagID int,
	@TagDescription varchar(20)
AS
	UPDATE MovieTags
	SET TagDescription = @TagDescription
	WHERE MovieTagID = @MovieTagID
RETURN 0

