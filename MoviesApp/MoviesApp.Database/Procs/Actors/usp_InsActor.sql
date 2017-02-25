CREATE PROCEDURE [dbo].[usp_InsActor]
	@Name varchar(50),
	@Favorited int
AS
	INSERT INTO Actors (Name, Favorited)
	OUTPUT INSERTED.ActorId
	VALUES (@Name, @Favorited)
RETURN 0