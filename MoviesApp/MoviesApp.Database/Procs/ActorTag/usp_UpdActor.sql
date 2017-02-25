CREATE PROCEDURE [dbo].[usp_UpdActorTags]
	@ActorTagID int,
	@TagDescription varchar(20),
	@ActorID int
AS
	UPDATE ActorTags
	SET TagDescription = @TagDescription
	WHERE ActorTagID = @ActorTagID
RETURN 0

