CREATE DATABASE [CigarShop]

USE [CigarShop]

CREATE TABLE [Sizes]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Length] INT NOT NULL CHECK ([Length] >= 10 AND [Length] <= 25),
	[RingRange] DECIMAL(18,2) NOT NULL CHECK ([RingRange] >= 1.5 AND [RingRange] <= 7.5)
)

CREATE TABLE [Tastes]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[TasteType] VARCHAR(20) NOT NULL,
	[TasteStrength] VARCHAR(15) NOT NULL,
	[ImageURL] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Brands]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[BrandName] VARCHAR(30) UNIQUE NOT NULL,
	[BrandDescription] VARCHAR(MAX)
)

CREATE TABLE [Cigars]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CigarName] VARCHAR(80) NOT NULL,
	[BrandId] INT NOT NULL FOREIGN KEY REFERENCES [Brands](Id),
	[TastId] INT NOT NULL FOREIGN KEY REFERENCES [Tastes](Id),
	[SizeId] INT NOT NULL FOREIGN KEY REFERENCES [Sizes](Id),
	[PriceForSingleCigar] MONEY NOT NULL,
	[ImageURL] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Addresses]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Town] VARCHAR(30) NOT NULL,
	[Country] NVARCHAR(30) NOT NULL,
	[Streat] NVARCHAR(100) NOT NULL,
	[ZIP] VARCHAR(20) NOT NULL
)

CREATE TABLE [Clients]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Email] NVARCHAR(50) NOT NULL,
	[AddressId] INT NOT NULL FOREIGN KEY REFERENCES [Addresses](Id)
)

CREATE TABLE [ClientsCigars]
(
	[ClientId] INT NOT NULL FOREIGN KEY REFERENCES [Clients](Id),
	[CigarId] INT NOT NULL FOREIGN KEY REFERENCES [Cigars](Id),
	PRIMARY KEY([ClientId], [CigarId])
)

INSERT INTO [Cigars] VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO [Addresses] VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

UPDATE [Cigars]
   SET [PriceForSingleCigar] *= 1.2
 WHERE [TastId] = 1

UPDATE [Brands]
   SET [BrandDescription] = 'New description'
 WHERE [BrandDescription] IS NULL

DELETE
  FROM [Clients]
 WHERE [AddressId] IN
	 (
SELECT [Id]
	   FROM [Addresses]
 WHERE SUBSTRING([Country], 1, 1) = 'C'
	 )

DELETE
  FROM [Addresses]
 WHERE SUBSTRING([Country], 1, 1) = 'C'

  SELECT [CigarName],
  	     [PriceForSingleCigar],
  	     [ImageURL]
    FROM [Cigars]
ORDER BY [PriceForSingleCigar],
		 [CigarName] DESC

   SELECT [c].[Id],
		  [c].[CigarName],
		  [c].[PriceForSingleCigar],
		  [t].[TasteType],
		  [t].[TasteStrength]
     FROM [Cigars]
	   AS [c]
LEFT JOIN [Tastes]
	   AS [t]
	   ON [c].[TastId] = [t].[Id]
	WHERE [TasteType] IN ('Earthy', 'Woody')
 ORDER BY [PriceForSingleCigar] DESC

   SELECT [c].[Id],
   CONCAT([c].[FirstName], ' ', [c].[LastName])
	   AS [ClientName],
	      [c].[Email]
     FROM [Clients]
	   AS [c]
LEFT JOIN [ClientsCigars]
	   AS [cc]
	   ON [c].[Id] = [cc].[ClientId]
	WHERE [cc].[CigarId] IS NULL
 ORDER BY [ClientName]

SELECT TOP(5)
		  [c].[CigarName],
 		  [c].[PriceForSingleCigar],
 		  [c].[ImageURL]
     FROM [Cigars]
	   AS [c]
     JOIN [Sizes]
	   AS [s]
	   ON [c].[SizeId] = [s].[Id]
    WHERE [s].[Length] >= 12 
	 AND ([c].[CigarName] LIKE '%ci%' OR [c].[PriceForSingleCigar] > 50)
	  AND [s].[RingRange] > 2.55
 ORDER BY [c].[CigarName],
		  [c].[PriceForSingleCigar] DESC

    SELECT CONCAT
	      ([cl].[FirstName], ' ', [cl].[LastName]) AS [FullName],
		   [a].[Country],
		   [a].[ZIP],
CONCAT('$',(SELECT MAX([PriceForSingleCigar])
	  FROM [Cigars] AS [c]
	  JOIN [ClientsCigars] AS [cc]
	    ON [c].[Id] = [cc].[CigarId] AND
		   [cc].[ClientId] = [cl].[Id])) AS [CigarPrice]
	  FROM [Clients]
	    AS [cl]
	  JOIN [Addresses]
	    AS [a]
		ON [cl].[AddressId] = [a].[Id]
     WHERE ISNUMERIC([a].[ZIP]) = 1
  ORDER BY [FullName]

  SELECT [c].[LastName],
	 AVG([s].[Length]) AS [CigarLength],
 CEILING(AVG([s].[RingRange])) AS [CigarRingRange]
	FROM [Clients]
	  AS [c]
	JOIN [ClientsCigars]
	  AS [cc]
	  ON [c].[Id] = [cc].[ClientId]
	JOIN [Cigars]
	  AS [cg]
	  ON [cc].[CigarId] = [cg].[Id]
	JOIN [Sizes]
	  AS [s]
	  ON [cg].[SizeId] = [s].[Id]
GROUP BY [c].[LastName]
ORDER BY AVG([s].[Length]) DESC

GO

CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @countOfCigar INT =
	(
		SELECT COUNT(*)
			   FROM [ClientsCigars]
			     AS [cc]
			   JOIN [Clients]
			     AS [c]
				 ON [cc].[ClientId] = [c].[Id]
			  WHERE [c].[FirstName] = @name
	)

	RETURN @countOfCigar
END

GO

CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	SELECT [c].[CigarName],
	CONCAT ('$', [c].[PriceForSingleCigar]) AS [Price],
		   [t].[TasteType],
		   [b].[BrandName],
	CONCAT ([s].[Length], ' ', 'cm') AS [CigarLength],
	CONCAT ([s].[RingRange], ' ', 'cm') AS [CigarRingRange]
	  FROM [Cigars]
	    AS [c]
 LEFT JOIN [Tastes]
		AS [t]
		ON [c].[TastId] = [t].[Id]
 LEFT JOIN [Sizes]
		AS [s]
		ON [c].[SizeId] = [s].[Id]
 LEFT JOIN [Brands]
		AS [b]
		ON [c].[BrandId] = [b].[Id]
	 WHERE [t].[TasteType] = @taste
  ORDER BY [CigarLength],
		   [CigarRingRange] DESC
END