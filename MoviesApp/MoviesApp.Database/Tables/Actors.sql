﻿CREATE TABLE [dbo].[Actors]
(
	[ActorId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Favorited] INT NULL DEFAULT 0 
)
