CREATE TABLE [dbo].[MovieMovieTagRelationships]
(
	[MovieMovieTagRelationshipId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MovieId] CHAR(9) NOT NULL, 
    [MovieTagId] INT NOT NULL, 
	CONSTRAINT FK_MovieMovieTagRelationships_MovieId_Movies_MovieId FOREIGN KEY (MovieId)
		REFERENCES dbo.Movies ([MovieId]),
	CONSTRAINT FK_MovieMovieTagRelationships_MovieTagId_MovieTags_MovieTagId FOREIGN KEY (MovieTagId)
		REFERENCES dbo.MovieTags ([MovieTagId]),
)
