CREATE DATABASE [Airport]

USE [Airport]

CREATE TABLE [Passengers]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FullName] VARCHAR (100) NOT NULL,
	[Email] VARCHAR (50) NOT NULL
)

CREATE TABLE [Pilots]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR (30) NOT NULL,
	[LastName] VARCHAR (30) NOT NULL,
	[Age] TINYINT CHECK( [Age] >= 21 AND [Age] <= 62) NOT NULL,
	[Rating] DECIMAL(15,2) CHECK([Rating] >= 0.0 AND [Rating] <= 10.0)
)

CREATE TABLE [AircraftTypes]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[TypeName] VARCHAR (30) NOT NULL
)

CREATE TABLE [Aircraft]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Manufacturer] VARCHAR (25) NOT NULL,
	[Model] VARCHAR (30) NOT NULL,
	[Year] INT NOT NULL,
	[FlightHours] INT,
	[Condition] CHAR(1) NOT NULL,
	[TypeId] INT FOREIGN KEY REFERENCES [AircraftTypes](Id) NOT NULL
)

CREATE TABLE [PilotsAircraft]
(
	[AircraftId] INT FOREIGN KEY REFERENCES [Aircraft](Id) NOT NULL,
	[PilotId] INT FOREIGN KEY REFERENCES [Pilots](Id) NOT NULL
)

CREATE TABLE [Airports]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[AirportName] VARCHAR (70) NOT NULL,
	[Country] VARCHAR (100) NOT NULL
)

CREATE TABLE [FlightDestinations]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[AirportId] INT FOREIGN KEY REFERENCES [Airports](Id) NOT NULL,
	[Start] DATETIME NOT NULL,
	[AircraftId] INT FOREIGN KEY REFERENCES [Aircraft](Id) NOT NULL,
	[PassengerId] INT FOREIGN KEY REFERENCES [Passengers](Id) NOT NULL,
	[TicketPrice] DECIMAL(15,2) DEFAULT(15) NOT NULL
)

INSERT INTO [Passengers] ([FullName], [Email])
	 SELECT CONCAT([FirstName] , ' ' , [LastName]),
			CONCAT([FirstName], [LastName], '@gmail.com')
	   FROM [Pilots]
	  WHERE [Id] >= 5 AND [Id] <= 15

UPDATE [Aircraft]
   SET [Condition] = 'A'
 WHERE [Condition] IN ('C', 'B') AND
	   ([FlightHours] IS NULL OR [FlightHours] <= 100) AND
	   [Year] >= 2013

DELETE [Passengers]
 WHERE LEN([FullName]) <= 10