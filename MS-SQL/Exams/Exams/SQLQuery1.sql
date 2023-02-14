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
	[Rate] FLOAT CHECK([Rate] >= 0.00 AND [Rate] <= 10.00),
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
)