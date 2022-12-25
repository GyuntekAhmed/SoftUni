CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(
   Id INT IDENTITY,
   DirectorName VARCHAR(30) NOT NULL,
   Notes VARCHAR(MAX)
)

INSERT INTO Directors (DirectorName, Notes) VALUES
('Georgi', 'Hello'),
('John', 'Hello'),
('Stefan', 'Hello'),
('Andrian', 'Hello'),
('Leo', 'Hello')

CREATE TABLE Genres
(
   Id INT IDENTITY,
   GenreName VARCHAR(30) NOT NULL,
   Notes VARCHAR(MAX)
)

INSERT INTO Genres (GenreName, Notes) VALUES
('Comedy', 'Ha ha ha'),
('Action', 'Yaaa'),
('Scarry', 'Ooooo'),
('Drama', 'Noooo'),
('Wild', 'Uraaaa')


CREATE TABLE Categories
(
   Id INT IDENTITY,
   CategoryName VARCHAR(30) NOT NULL,
   Notes VARCHAR(MAX)
)

INSERT INTO Categories(CategoryName) VALUES
('Comedy'),
('Action'),
('Scarry'),
('Drama'),
('Wild')

CREATE TABLE Movies
(
   Id INT IDENTITY,
   Title VARCHAR(50) NOT NULL,
   DirectorId INT NOT NULL,
   CopyrightYear INT,
   [Length] INT,
   GenreId INT,
   CategoryId INT,
   Rating DECIMAL(10,2),
   Notes VARCHAR(MAX)
)

ALTER TABLE Directors
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)

ALTER TABLE Genres
ADD CONSTRAINT PK_Genres
PRIMARY KEY (Id)

ALTER TABLE Categories
ADD CONSTRAINT PK_Categories
PRIMARY KEY (Id)

ALTER TABLE Movies
ADD CONSTRAINT PK_Movies
PRIMARY KEY (Id)

INSERT INTO Movies (Title,DirectorId,CopyrightYear,[Length],GenreId,CategoryId,Rating,Notes) VALUES
('BEST', 1, 2022, 1.35, 1, 1, 5.9, 'Uraaa'),
('fbdf', 2, 2022, 1.35, 2, 2, 3.2, 'Ura'),
('vfffx', 3, 2022, 1.35, 3, 3, 1.3, 'Uaa'),
('fvsfrr', 4, 2022, 1.35, 4, 4, 2.9, 'hgfh'),
('ffssdf', 5, 2022, 1.35, 5, 5, 3.9, 'raaa')