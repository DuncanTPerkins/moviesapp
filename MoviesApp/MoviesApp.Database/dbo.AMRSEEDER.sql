CREATE PROCEDURE [dbo].[AMRSEEDER]
AS
SET IDENTITY_INSERT [dbo].[ActorMovieRelationships] ON
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipID], [MovieID], [ActorID]) VALUES (1, N'tt1201607', 1)
INSERT INTO [dbo].[ActorMovieRelationships] ([ActorMovieRelationshipID], [MovieID], [ActorID]) VALUES (2, N'tt0076759', 2)
SET IDENTITY_INSERT [dbo].[ActorMovieRelationships] OFF
SET IDENTITY_INSERT [dbo].[Actors] ON
INSERT INTO [dbo].[Actors] ([ActorID], [Name], [Age]) VALUES (1, N'Alan Rickman', 67)
INSERT INTO [dbo].[Actors] ([ActorID], [Name], [Age]) VALUES (2, N'Mark Hamill', 65)
SET IDENTITY_INSERT [dbo].[Actors] OFF
INSERT INTO [dbo].[Movies] ([MovieID], [Title], [Year], [Rated], [Released], [Genre], [Director], [Writer], [Plot], [Language], [Country], [Awards], [Poster], [Metascore], [ImdbRating], [ImdbVotes], [Type], [Response]) VALUES (N'tt0076759', N'Star Wars: Episode IV - A New Hope', NULL, N'PG', NULL, N'Action, Adventure, Fantasy', N'George Lucas', N'George Lucas', N'Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a wookiee and two droids to save the galaxy from the Empire''s world-destroying battle-station, while also attempting to rescue Princess Leia from the evil Darth Vader.', N'English', N'USA', N'Won 6 Oscars. Another 48 wins & 28 nominations.', N'https:\/\/images-na.ssl-images-amazon.com\/images\/M\/MV5BYzQ2OTk4N2QtOGQwNy00MmI3LWEwNmEtOTk0OTY3NDk2MGJkL2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_SX300.jpg', 92, 8.7, 0, N'movie', N'True')
INSERT INTO [dbo].[Movies] ([MovieID], [Title], [Year], [Rated], [Released], [Genre], [Director], [Writer], [Plot], [Language], [Country], [Awards], [Poster], [Metascore], [ImdbRating], [ImdbVotes], [Type], [Response]) VALUES (N'tt1201607', N'Harry Potter and the Deathly Hallows: Part 2', NULL, N'PG-13', NULL, N'Adventure, Drama, Fantasy', N'David Yates', N'Steve Kloves (screenplay), J.K. Rowling (novel)', N'Harry, Ron and Hermione search for Voldemort''s remaining Horcruxes in their effort to destroy the Dark Lord as the final battle rages on at Hogwarts.', N'English', N'USA, UK', N'Nominated for 3 Oscars. Another 46 wins & 87 nominations.', N'https:\/\/images-na.ssl-images-amazon.com\/images\/M\/MV5BMTY2MTk3MDQ1N15BMl5BanBnXkFtZTcwMzI4NzA2NQ@@._V1_SX300.jpg', 87, 8.1, 0, N'movie', N'True')
RETURN 0