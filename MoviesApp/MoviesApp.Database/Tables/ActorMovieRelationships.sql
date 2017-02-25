CREATE TABLE [dbo].[ActorMovieRelationships]
(
	[ActorMovieRelationshipId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MovieId] CHAR(9) NOT NULL, 
    [ActorId] INT NOT NULL 
	CONSTRAINT FK_ActorMovieRelationships_MovieID_Movies_MovieID FOREIGN KEY ([MovieId])
		REFERENCES dbo.Movies ([MovieId]),
	CONSTRAINT FK_ActorMovieRelationships_ActorID_Actors_ActorID FOREIGN KEY ([ActorId])
		REFERENCES dbo.Actors ([ActorId])
)
