CREATE DATABASE [NationalTouristSitesOfBulgaria]

USE [NationalTouristSitesOfBulgaria]

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Locations]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Municipality] VARCHAR(50),
	[Province] VARCHAR(50)
)

CREATE TABLE [Sites]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[LocationId] INT FOREIGN KEY REFERENCES [Locations](Id) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
	[Establishment] VARCHAR(15)
)

CREATE TABLE [Tourists]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Age] INT CHECK([Age] >= 0 AND [Age] <= 120) NOT NULL,
	[PhoneNumber] VARCHAR(20) NOT NULL,
	[Nationality] VARCHAR(30) NOT NULL,
	[Reward] VARCHAR(20)
)

CREATE TABLE [SitesTourists]
(
	[TouristId] INT FOREIGN KEY REFERENCES [Tourists](Id) NOT NULL,
	[SiteId] INT FOREIGN KEY REFERENCES [Sites](Id) NOT NULL,
	PRIMARY KEY ([TouristId], [SiteId])
)

CREATE TABLE [BonusPrizes]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [TouristsBonusPrizes]
(
	[TouristId] INT FOREIGN KEY REFERENCES [Tourists](Id) NOT NULL,
	[BonusPrizeId] INT FOREIGN KEY REFERENCES [BonusPrizes](Id) NOT NULL,
	PRIMARY KEY ([TouristId], [BonusPrizeId])
)

INSERT INTO [Tourists]([Name], [Age], [PhoneNumber], [Nationality], [Reward])
VALUES
('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
('Peter Bosh', 48, '+447911844141', 'UK', NULL),
('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO [Sites]([Name], [LocationId], [CategoryId], [Establishment])
VALUES
('Ustra fortress', 90, 7, 'X'),
('Karlanovo Pyramids', 65, 7, NULL),
('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
('Sinite Kamani Natural Park', 17, 1, NULL),
('St. Petka of Bulgaria � Rupite', 92, 6, '1994')

UPDATE [Sites]
   SET [Establishment] =  '(not defined)'
 WHERE [Establishment] IS NULL

DELETE
  FROM [TouristsBonusPrizes]
 WHERE [BonusPrizeId] = 5

 DELETE
   FROM [BonusPrizes]
  WHERE [Name] = 'Sleeping bag'

  SELECT [Name],
	     [Age],
	     [PhoneNumber],
 	     [Nationality]
    FROM [Tourists]
ORDER BY [Nationality],
		 [Age] DESC,
		 [Name]

   SELECT [s].[Name],
		  [l].[Name],
		  [s].[Establishment],
		  [c].[Name]
     FROM [Sites]
	   AS [s]
LEFT JOIN [Locations]
	   AS [l]
	   ON [s].[LocationId] = [l].[Id]
LEFT JOIN [Categories]
	   AS [c]
	   ON [s].[CategoryId] = [c].[Id]
 ORDER BY [c].[Name] DESC,
		  [l].[Name],
		  [s].[Name]

   SELECT [l].[Province],
	      [l].[Municipality],
	      [l].[Name],
		  COUNT([s].[Id]) AS [CountOfSites]
     FROM [Locations]
       AS [l]
	 JOIN [Sites]
	   AS [s]
	   ON [l].[Id] = [s].[LocationId]
    WHERE [l].[Province] = 'Sofia'
 GROUP BY [l].[Province],
	      [l].[Municipality],
	      [l].[Name]
 ORDER BY [CountOfSites] DESC,
		  [l].[Name]

  SELECT [s].[Name] AS [Site],
  	     [l].[Name] AS [Location],
		 [l].[Municipality],
  	     [l].[Province],
  	     [s].[Establishment]
    FROM [Sites]
      AS [s]
    JOIN [Locations]
      AS [l]
  	  ON [s].[LocationId] = [l].[Id]
   WHERE LEFT([l].[Name], 1) NOT LIKE '[B, M, D,]'
     AND [s].[Establishment] LIKE '%BC'
ORDER BY [s].[Name]

   SELECT [t].[Name],
		  [t].[Age],
		  [t].[PhoneNumber],
		  [t].[Nationality],
		  ISNULL([bp].[Name], '(no bonus prize)') AS 'BonusPrize'
     FROM [Tourists]
       AS [t]
LEFT JOIN [TouristsBonusPrizes]
       AS [tbp]
	   ON [t].[Id] = [tbp].[TouristId]
LEFT JOIN [BonusPrizes]
       AS [bp]
       ON [tbp].[BonusPrizeId] = [bp].[Id]
 ORDER BY [t].[Name]

   SELECT SUBSTRING([t].[Name], CHARINDEX(' ', [t].[Name]) + 1, LEN([t].[Name])) AS [LastName],
		  [t].[Nationality],
		  [t].[Age],
		  [t].[PhoneNumber]
     FROM [Tourists]
       AS [t]
	 JOIN [SitesTourists]
	   AS [st]
	   ON [t].[Id] = [st].[TouristId]
	 JOIN [Sites]
	   AS [s]
	   ON [st].[SiteId] = [s].[Id]
	 JOIN [Categories]
	   AS [c]
	   ON [s].[CategoryId] = [c].[Id]
	WHERE [c].[Name] = 'History and archaeology'
 GROUP BY [t].[Name],
		  [t].[Nationality],
		  [t].[Age],
		  [t].[PhoneNumber]
 ORDER BY [LastName]

GO

CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @countOfTourists INT =
							 (
								SELECT COUNT([st].[TouristId])
								  FROM [Sites]
								    AS [s]
								  JOIN [SitesTourists]
								    AS [st]
									ON [s].[Id] = [st].[SiteId]
								 WHERE [Name] = @Site
							 )
	RETURN @countOfTourists
END

GO

CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
IF (SELECT COUNT([s].[Id]) 
	  FROM [Sites] 
	    AS [s]
	  JOIN [SitesTourists]
	    AS [st]
		ON [s].[Id] = [st].[SiteId]
	  JOIN [Tourists]
	    AS [t]
		ON [st].[TouristId] = [t].[Id]
	 WHERE [t].[Name] = @TouristName) >= 100
	BEGIN 
			UPDATE [Tourists]
			   SET [Reward] = 'Gold badge'
			 WHERE [Name] = @TouristName
	END
ELSE IF ( SELECT COUNT(s.Id)
			FROM [Sites] 
			  AS [s]
			JOIN [SitesTourists]
			  AS [st]
			  ON [s].[Id] = [st].[SiteId]
			JOIN [Tourists]
			  AS [t]
			  ON [st].[TouristId] = [t].[Id]
		   WHERE [t].[Name] = @TouristName) >= 50
	BEGIN 
			UPDATE [Tourists]
			   SET [Reward] = 'Silver badge'
			 WHERE [Name] = @TouristName
	END
ELSE IF ( SELECT COUNT([s].[Id])
			FROM [Sites]
			  AS [s]
			JOIN [SitesTourists]
			  AS [st]
			  ON [s].[Id] = [st].[SiteId]
			JOIN [Tourists]
			  AS [t]
			  ON [st].[TouristId] = [t].[Id]
		   WHERE [t].[Name] = @TouristName) >= 25
	BEGIN 
			UPDATE [Tourists]
			   SET [Reward] = 'Bronze badge'
			 WHERE [Name] = @TouristName
	END
		SELECT [Name],
			   [Reward]
		  FROM [Tourists]
		 WHERE [Name] = @TouristName
END