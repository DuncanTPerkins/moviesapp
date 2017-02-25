CREATE PROCEDURE [dbo].[usp_InsMovie]
	@MovieId char(9),
	@Title varchar(150),
	@Year datetime2,
	@Rated varchar(5),
	@Released datetime,
	@Genre varchar(50),
	@Director varchar(50),
	@Writer varchar(50),
	@Plot varchar(500),
	@Language varchar(50),
	@Country varchar(10),
	@Awards varchar(250),
	@Poster varchar(500),
	@Metascore int,
	@Favorited int,
	@Watched int,
	@ImdbRating varchar(4),
	@ImdbVotes varchar(20),
	@Type varchar(10),
	@Response varchar(10)
AS
	INSERT INTO Movies (MovieID, Title, Year, Rated, Released, Genre, Director, Writer, Plot, Language, Country, Awards, Poster, Metascore, ImdbRating, ImdbVotes, Watched, Favorited, Type, Response)
	VALUES (@MovieID, @Title, @Year, @Rated, @Released, @Genre, @Director, @Writer, @Plot, @Language, @Country, @Awards, @Poster, @Metascore, @ImdbRating, @ImdbVotes, @Watched, @Favorited, @Type, @Response)
RETURN 0
