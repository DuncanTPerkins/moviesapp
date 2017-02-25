CREATE TABLE [dbo].[Movies]
(
	[MovieId] CHAR(9) NOT NULL PRIMARY KEY, 
    [Title] VARCHAR(150) NOT NULL, 
    [Year] DATETIME2 NULL, 
    [Rated] VARCHAR(5) NOT NULL, 
    [Released] DATETIME NULL, 
    [Genre] VARCHAR(50) NOT NULL, 
    [Director] VARCHAR(50) NOT NULL, 
    [Writer] VARCHAR(50) NOT NULL, 
    [Plot] VARCHAR(500) NOT NULL, 
    [Language] VARCHAR(50) NOT NULL, 
    [Country] VARCHAR(10) NOT NULL, 
    [Awards] VARCHAR(250) NOT NULL, 
    [Poster] VARCHAR(500) NOT NULL, 
    [Metascore] INT NOT NULL, 
    [ImdbRating] VARCHAR(4) NOT NULL, 
    [ImdbVotes] VARCHAR(20) NOT NULL, 
    [Type] VARCHAR(10) NOT NULL, 
    [Response] VARCHAR(10) NOT NULL, 
    [Favorited] INT NULL DEFAULT 0, 
    [Watched] INT NULL DEFAULT 0
)
