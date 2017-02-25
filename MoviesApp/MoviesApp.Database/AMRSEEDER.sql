CREATE PROCEDURE [dbo].[AMRSEEDER]


AS
SET IDENTITY_INSERT [dbo].[Actors] ON
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (1, N'Alan Rickman', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (2, N'Mark Hamill', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (3, N'Stanley Tucci', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (4, N'Wes Bentley', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (5, N'Jennifer Lawrence', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (6, N'Willow Shields', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (7, N'Anne Hathaway', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (8, N'Patrick Wilson', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (9, N'Andre Braugher', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (10, N'Dianne Wiest', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (11, N'Bradley Cooper', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (12, N'Jake Gyllenhaal', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (13, N'Robert De Niro', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (14, N'Rene Russo', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (15, N'Anders Holm', 0)
INSERT INTO [dbo].[Actors] ([ActorId], [Name], [Favorited]) VALUES (16, N'Bob Bobberson', 0)
SET IDENTITY_INSERT [dbo].[Actors] OFF


INSERT INTO [dbo].[Movies] ([MovieId], [Title], [Year], [Rated], [Released], [Genre], [Director], [Writer], [Plot], [Language], [Country], [Awards], [Poster], [Metascore], [ImdbRating], [ImdbVotes], [Type], [Response], [Favorited], [Watched]) VALUES (N'tt0076759', N'Star Wars: Episode IV - A New Hope', NULL, N'PG', NULL, N'Action, Adventure, Fantasy', N'George Lucas', N'George Lucas', N'Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a wookiee and two droids to save the galaxy from the Empire''s world-destroying battle-station, while also attempting to rescue Princess Leia from the evil Darth Vader.', N'English', N'USA', N'Won 6 Oscars. Another 48 wins & 28 nominations.', N'https:\/\/images-na.ssl-images-amazon.com\/images\/M\/MV5BYzQ2OTk4N2QtOGQwNy00MmI3LWEwNmEtOTk0OTY3NDk2MGJkL2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_SX300.jpg', 92, N'8.7', N'0', N'movie', N'True', 0, 0)
INSERT INTO [dbo].[Movies] ([MovieId], [Title], [Year], [Rated], [Released], [Genre], [Director], [Writer], [Plot], [Language], [Country], [Awards], [Poster], [Metascore], [ImdbRating], [ImdbVotes], [Type], [Response], [Favorited], [Watched]) VALUES (N'tt0449487', N'Passengers', N'2008-01-01 00:00:00', N'PG-13', N'2008-10-24 00:00:00', N'Drama, Mystery, Romance', N'Rodrigo García', N'Ronnie Christensen', N'A grief counselor working with a group of plane-crash survivors finds herself at the root of a mystery when her clients begin to disappear.', N'English', N'USA, Canad', N'N/A', N'https://images-na.ssl-images-amazon.com/images/M/MV5BMTQ3ODE5MjIzMV5BMl5BanBnXkFtZTcwNTc4Nzc5MQ@@._V1_SX300.jpg', 40, N'5.9', N'28,220', N'movie', N'True', 0, 1)
INSERT INTO [dbo].[Movies] ([MovieId], [Title], [Year], [Rated], [Released], [Genre], [Director], [Writer], [Plot], [Language], [Country], [Awards], [Poster], [Metascore], [ImdbRating], [ImdbVotes], [Type], [Response], [Favorited], [Watched]) VALUES (N'tt0758752', N'Love & Other Drugs', N'2010-01-01 00:00:00', N'R', N'2010-11-24 00:00:00', N'Comedy, Drama, Romance', N'Edward Zwick', N'Charles Randolph (screenplay), Edward Zwick (scree', N'A young woman suffering from Parkinson''s befriends a drug rep working for Pfizer in 1990s Pittsburgh.', N'English', N'USA', N'Nominated for 2 Golden Globes. Another 1 win & 4 nominations.', N'https://images-na.ssl-images-amazon.com/images/M/MV5BMTgxOTczODEyMF5BMl5BanBnXkFtZTcwMDc0NDY4Mw@@._V1_SX300.jpg', 55, N'6.7', N'147,601', N'movie', N'True', 1, 0)
INSERT INTO [dbo].[Movies] ([MovieId], [Title], [Year], [Rated], [Released], [Genre], [Director], [Writer], [Plot], [Language], [Country], [Awards], [Poster], [Metascore], [ImdbRating], [ImdbVotes], [Type], [Response], [Favorited], [Watched]) VALUES (N'tt1201607', N'Harry Potter and the Deathly Hallows: Part 2', NULL, N'PG-13', NULL, N'Adventure, Drama, Fantasy', N'David Yates', N'Steve Kloves (screenplay), J.K. Rowling (novel)', N'Harry, Ron and Hermione search for Voldemort''s remaining Horcruxes in their effort to destroy the Dark Lord as the final battle rages on at Hogwarts.', N'English', N'USA, UK', N'Nominated for 3 Oscars. Another 46 wins & 87 nominations.', N'https:\/\/images-na.ssl-images-amazon.com\/images\/M\/MV5BMTY2MTk3MDQ1N15BMl5BanBnXkFtZTcwMzI4NzA2NQ@@._V1_SX300.jpg', 87, N'8.1', N'0', N'movie', N'True', 0, 1)
INSERT INTO [dbo].[Movies] ([MovieId], [Title], [Year], [Rated], [Released], [Genre], [Director], [Writer], [Plot], [Language], [Country], [Awards], [Poster], [Metascore], [ImdbRating], [ImdbVotes], [Type], [Response], [Favorited], [Watched]) VALUES (N'tt1247690', N'Serena', N'2014-01-01 00:00:00', N'R', N'2015-02-26 00:00:00', N'Drama, Romance', N'Susanne Bier', N'Christopher Kyle (screenplay), Ron Rash (based on ', N'In Depression-era North Carolina, the future of George Pemberton''s timber empire becomes complicated when he marries Serena.', N'English', N'Czech Repu', N'1 win.', N'https://images-na.ssl-images-amazon.com/images/M/MV5BMTExMDY2OTYxMTNeQTJeQWpwZ15BbWU4MDc2NDE5MTQx._V1_SX300.jpg', 36, N'5.4', N'18,803', N'movie', N'True', 1, 0)
INSERT INTO [dbo].[Movies] ([MovieId], [Title], [Year], [Rated], [Released], [Genre], [Director], [Writer], [Plot], [Language], [Country], [Awards], [Poster], [Metascore], [ImdbRating], [ImdbVotes], [Type], [Response], [Favorited], [Watched]) VALUES (N'tt1392170', N'The Hunger Games', N'2012-01-01 00:00:00', N'PG-13', N'2012-03-23 00:00:00', N'Action, Adventure, Sci-Fi', N'Gary Ross', N'Gary Ross (screenplay), Suzanne Collins (screenpla', N'Katniss Everdeen voluntarily takes her younger sister''s place in the Hunger Games, a televised competition in which two teenagers from each of the twelve Districts of Panem are chosen at random to fight to the death.', N'English', N'USA', N'Nominated for 1 Golden Globe. Another 33 wins & 42 nominations.', N'https://images-na.ssl-images-amazon.com/images/M/MV5BMjA4NDg3NzYxMF5BMl5BanBnXkFtZTcwNTgyNzkyNw@@._V1_SX300.jpg', 68, N'7.2', N'720,888', N'movie', N'True', 0, 1)
INSERT INTO [dbo].[Movies] ([MovieId], [Title], [Year], [Rated], [Released], [Genre], [Director], [Writer], [Plot], [Language], [Country], [Awards], [Poster], [Metascore], [ImdbRating], [ImdbVotes], [Type], [Response], [Favorited], [Watched]) VALUES (N'tt2361509', N'The Intern', N'2015-01-01 00:00:00', N'PG-13', N'2015-09-25 00:00:00', N'Comedy, Drama', N'Nancy Meyers', N'Nancy Meyers', N'70-year-old widower Ben Whittaker has discovered that retirement isn''t all it''s cracked up to be. Seizing an opportunity to get back in the game, he becomes a senior intern at an online fashion site, founded and run by Jules Ostin.', N'English', N'USA', N'1 win & 6 nominations.', N'https://images-na.ssl-images-amazon.com/images/M/MV5BMTUyNjE5NjI5OF5BMl5BanBnXkFtZTgwNzYzMzU3NjE@._V1_SX300.jpg', 51, N'7.1', N'149,758', N'movie', N'True', 1, 0)


SET IDENTITY_INSERT [dbo].[ActorMovieRelationships] ON
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipId], [MovieId], [ActorId]) VALUES (3, N'tt1392170', 3)
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipId], [MovieId], [ActorId]) VALUES (4, N'tt1392170', 4)
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipId], [MovieId], [ActorId]) VALUES (5, N'tt1392170', 5)
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipId], [MovieId], [ActorId]) VALUES (6, N'tt1392170', 6)
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipId], [MovieId], [ActorId]) VALUES (7, N'tt0449487', 7)
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipId], [MovieId], [ActorId]) VALUES (8, N'tt0449487', 8)
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipId], [MovieId], [ActorId]) VALUES (9, N'tt0449487', 9)
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipId], [MovieId], [ActorId]) VALUES (10, N'tt0449487', 10)
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipId], [MovieId], [ActorId]) VALUES (11, N'tt1247690', 11)
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipId], [MovieId], [ActorId]) VALUES (12, N'tt0758752', 12)
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipId], [MovieId], [ActorId]) VALUES (13, N'tt2361509', 13)
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipId], [MovieId], [ActorId]) VALUES (14, N'tt2361509', 7)
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipId], [MovieId], [ActorId]) VALUES (15, N'tt2361509', 14)
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipId], [MovieId], [ActorId]) VALUES (16, N'tt2361509', 15)
SET IDENTITY_INSERT [dbo].[ActorMovieRelationships] OFF

SET IDENTITY_INSERT [dbo].[MovieTags] ON
INSERT INTO [dbo].[MovieTags] ([MovieTagId], [TagDescription]) VALUES (1, N'Funny')
INSERT INTO [dbo].[MovieTags] ([MovieTagId], [TagDescription]) VALUES (2, N'Sad')
INSERT INTO [dbo].[MovieTags] ([MovieTagId], [TagDescription]) VALUES (3, N'Happy')
SET IDENTITY_INSERT [dbo].[MovieTags] OFF

SET IDENTITY_INSERT [dbo].[MovieMovieTagRelationships] ON
INSERT INTO [dbo].[MovieMovieTagRelationships] ([MovieMovieTagRelationshipId], [MovieId], [MovieTagId]) VALUES (1, N'tt0758752', 3)
SET IDENTITY_INSERT [dbo].[MovieMovieTagRelationships] OFF

SET IDENTITY_INSERT [dbo].[ActorTags] ON
INSERT INTO [dbo].[ActorTags] ([ActorTagId], [TagDescription]) VALUES (1, N'Boring')
INSERT INTO [dbo].[ActorTags] ([ActorTagId], [TagDescription]) VALUES (2, N'Funny')
INSERT INTO [dbo].[ActorTags] ([ActorTagId], [TagDescription]) VALUES (3, N'Old')
INSERT INTO [dbo].[ActorTags] ([ActorTagId], [TagDescription]) VALUES (4, N'Too Old')
SET IDENTITY_INSERT [dbo].[ActorTags] OFF

SET IDENTITY_INSERT [dbo].[ActorActorTagRelationships] ON
INSERT INTO [dbo].[ActorActorTagRelationships] ([ActorActorTagRelationshipId], [ActorId], [ActorTagId]) VALUES (6, 3, 4)
SET IDENTITY_INSERT [dbo].[ActorActorTagRelationships] OFF

RETURN 0