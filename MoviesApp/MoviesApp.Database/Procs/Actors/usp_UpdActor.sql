CREATE PROCEDURE [dbo].[usp_UpdActor]
	@ActorId int,
	@Name varchar(50),
	@Favorited int
AS
	UPDATE Actors
	SET Name = @Name, Favorited = @Favorited
	WHERE ActorId = @ActorId
RETURN 0

