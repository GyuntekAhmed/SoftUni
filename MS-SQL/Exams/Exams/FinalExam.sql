CREATE DATABASE [Boardgames]

USE [Boardgames]

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	StreetName VARCHAR(100) NOT NULL,
	StreetNumber INT NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	ZIP INT NOT NULL
)

CREATE TABLE Publishers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) UNIQUE NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
	Website VARCHAR(40),
	Phone VARCHAR(20)
)

CREATE TABLE PlayersRanges
(
	Id INT PRIMARY KEY IDENTITY,
	PlayersMin INT NOT NULL,
	PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	YearPublished INT NOT NULL,
	Rating DECIMAL(18,2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	PublisherId INT FOREIGN KEY REFERENCES Publishers(Id) NOT NULL,
	PlayersRangeId INT FOREIGN KEY REFERENCES PlayersRanges(Id) NOT NULL
)

CREATE TABLE Creators
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Email VARCHAR(30) NOT NULL
)

CREATE TABLE CreatorsBoardgames
(
	CreatorId INT FOREIGN KEY REFERENCES Creators(Id) NOT NULL,
	BoardgameId INT FOREIGN KEY REFERENCES Boardgames(Id) NOT NULL,
	PRIMARY KEY(CreatorId, BoardgameId)
)

INSERT INTO Boardgames VALUES
('Deep Blue', 2019, 5.67, 1, 15, 7),
('Paris', 2016, 9.78, 7, 1, 5),
('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO Publishers VALUES
('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')

DELETE 
  FROM CreatorsBoardgames
 WHERE BoardgameId IN (1, 16, 31, 47)

SELECT * 
  FROM Boardgames
 WHERE PublisherId IN (1,16)

DELETE
  FROM Publishers
 WHERE AddressId = 5

DELETE 
  FROM Addresses
 WHERE Town LIKE 'L%'

  SELECT [Name],
		 [Rating]
    FROM Boardgames
ORDER BY YearPublished,
		 [Name] DESC

 SELECT b.Id,
		b.[Name],
		b.YearPublished,
		c.[Name] AS CategoryName
   FROM Boardgames
     AS b
   JOIN Categories
     AS c
	 ON b.CategoryId = c.Id
  WHERE CategoryId IN (6,8)
ORDER BY b.YearPublished DESC


  SELECT c.Id,
		 c.FirstName + ' ' + c.LastName AS CreatorName,
		 c.Email
    FROM Creators
	  AS c
FULL JOIN CreatorsBoardgames
		AS cb
		ON cb.CreatorId = c.Id
	WHERE cb.BoardgameId IS NULL

SELECT TOP(5)
	 b.[Name], b.Rating, c.[Name]
  FROM Boardgames
    AS b
  JOIN PlayersRanges
    AS pl
	ON b.PlayersRangeId = pl.Id
  JOIN Categories
    AS c
	ON b.CategoryId = c.Id
 WHERE (b.Rating > 7.00 AND b.[Name] LIKE '%a%')
    OR (b.Rating > 7.50 AND (pl.PlayersMin = 2 AND pl.PlayersMax = 5))
ORDER BY b.[Name], b.Rating DESC

SELECT c.FirstName + ' ' + c.LastName AS FullName,
	   c.Email,
	   MAX(b.Rating)
  FROM Creators
    AS c
  JOIN CreatorsBoardgames
    AS cb
	ON c.Id = cb.CreatorId
  JOIN Boardgames
    AS b
	ON b.Id = cb.BoardgameId
 WHERE c.Email LIKE '%.com'
GROUP BY c.FirstName, c.LastName, c.Email
ORDER BY FullName

SELECT c.LastName,
	   CEILING(AVG(b.Rating)),
	   p.[Name]
  FROM Creators
    AS c
  JOIN CreatorsBoardgames
    AS cb
	ON c.Id = cb.CreatorId
  JOIN Boardgames
    AS b
	ON cb.BoardgameId = b.Id
  JOIN Publishers
    AS p
	ON b.PublisherId = p.Id
 WHERE p.[Name] = 'Stonemaier Games'
GROUP BY c.LastName,
		 p.[Name]
ORDER BY AVG(b.Rating) DESC

CREATE FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @totalNumber INT =
	(
		SELECT COUNT(cb.BoardgameId)
		  FROM Creators
		    AS c
		  JOIN CreatorsBoardgames
		    AS cb
			ON c.Id = cb.CreatorId
		 WHERE c.FirstName = @name
	)
RETURN @totalNumber
END

CREATE PROCEDURE usp_SearchByCategory(@category VARCHAR(50))
AS
BEGIN
	SELECT b.[Name],
		   b.YearPublished,
		   b.Rating,
		   c.[Name],
		   p.[Name],
		   CONCAT(pl.PlayersMin, ' ', 'people') AS MinPlayers,
		   CONCAT(pl.PlayersMax, ' ', 'people') AS MaxPlayers
	  FROM Categories
	    AS c
	  JOIN Boardgames
	    AS b
		ON
		 c.Id = b.CategoryId
	  JOIN Publishers
	    AS p
		ON b.PublisherId = p.Id
	  JOIN PlayersRanges
	    AS pl
		ON b.PlayersRangeId = pl.Id
	 WHERE c.[Name] = @category
	ORDER BY p.[Name],
			 b.YearPublished DESC
END