CREATE DATABASE [Bakery]

USE [Bakery]

CREATE TABLE [Countries]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE
)

CREATE TABLE [Customers]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(25),
	[LastName] VARCHAR(25),
	[Gender] CHAR(1) CHECK([Gender] = 'M' OR [Gender] = 'F'),
	[Age] INT,
	[PhoneNumber] VARCHAR(10) CHECK(LEN([PhoneNumber]) = 10),
	[CountryId] INT FOREIGN KEY REFERENCES [Countries](Id)
)

CREATE TABLE [Products]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(25) UNIQUE,
	[Description] VARCHAR(250),
	[Recipe] VARCHAR(MAX),
	[Price] DECIMAL(18,2) CHECK([Price] >= 0)
)

CREATE TABLE [Feedbacks]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Description] VARCHAR(255),
	[Rate] DECIMAL(18,2) CHECK([Rate] >= 0.00 AND [Rate] <= 10.00),
	[ProductId] INT FOREIGN KEY REFERENCES [Products](Id),
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers](Id)
)

CREATE TABLE [Distributors]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(25) UNIQUE,
	[AddressText] VARCHAR(30),
	[Summary] VARCHAR(200),
	[CountryId] INT FOREIGN KEY REFERENCES [Countries](Id)
)

CREATE TABLE [Ingredients]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) UNIQUE,
	[Description] VARCHAR(200),
	[OriginCountryId] INT FOREIGN KEY REFERENCES [Countries](Id),
	[DistributorId] INT FOREIGN KEY REFERENCES [Distributors](Id)
)

CREATE TABLE [ProductsIngredients]
(
	[ProductId] INT FOREIGN KEY REFERENCES [Products](Id),
	[IngredientId] INT FOREIGN KEY REFERENCES [Ingredients](Id)
	PRIMARY KEY ([ProductId], [IngredientId])
)

GO

INSERT INTO [Distributors] 
		   ([Name],
			[CountryId], 
			[AddressText],
			[Summary])
VALUES
('Deloitte & Touche', 2,' 6 Arch St #9757', 'Customizable neutral traveling'),
('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO [Customers]
		   ([FirstName],
		    [LastName],
			[Age], 
			[Gender], 
			[PhoneNumber],
			[CountryId])
VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud', 22, 'F', '0063631526', 11),
('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
('Tom', 'Loeza', 31, 'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
('Josefa', 'Opitz', 43, 'F', '0197887645', 17)