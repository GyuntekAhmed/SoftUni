CREATE DATABASE WMS
GO
USE [WMS]
GO

CREATE TABLE [Clients]
(
	[ClientId] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Phone] CHAR(12) CHECK(LEN([Phone]) = 12) NOT NULL
)

CREATE TABLE [Mechanics]
(
	[MechanicId] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE [Models]
(
	[ModelId] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)
CREATE TABLE [Jobs]
(
	[JobId] INT PRIMARY KEY IDENTITY,
	[ModelId] INT NOT NULL FOREIGN KEY REFERENCES [Models](ModelId),
	[Status] VARCHAR(11) DEFAULT 'Pending' CHECK([Status] IN ('Pending', 'In Progress', 'Finished')),
	[ClientId] INT FOREIGN KEY REFERENCES [Clients]([ClientId]) NOT NULL,
	[MechanicId] INT FOREIGN KEY REFERENCES [Mechanics]([MechanicId]),
	[IssueDate] DATE NOT NULL,
	[FinishDate] DATE
)

CREATE TABLE [Orders]
(
	[OrderId] INT PRIMARY KEY IDENTITY,
	[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]) NOT NULL,
	[IssueDate] DATE,
	[Delivered] BIT DEFAULT 0
)

CREATE TABLE [Vendors]
(
	[VendorId] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)
CREATE TABLE [Parts]
(
	[PartId] INT PRIMARY KEY IDENTITY,
	[SerialNumber] VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	[Price] DECIMAL(15,2) CHECK([Price] > 0 AND [Price] <= 9999.99) NOT NULL,
	[VendorId] INT FOREIGN KEY REFERENCES [Vendors](VendorId) NOT NULL,
	[StockQty] INT DEFAULT 0 CHECK([StockQty] >= 0) NOT NULL
)

CREATE TABLE [OrderParts]
(
	[OrderId] INT FOREIGN KEY REFERENCES [Orders](OrderId) NOT NULL,
	[PartId] INT FOREIGN KEY REFERENCES [Parts](PartId) NOT NULL,
	PRIMARY KEY([OrderId], [PartId]),
	[Quantity] INT DEFAULT 1 CHECK([Quantity] > 0) NOT NULL
)

CREATE TABLE [PartsNeeded]
(
	[JobId] INT FOREIGN KEY REFERENCES [Jobs](JobId) NOT NULL,
	[PartId] INT FOREIGN KEY REFERENCES [Parts](PartId) NOT NULL,
	PRIMARY KEY([JobId], [PartId]),
	[Quantity] INT DEFAULT 1 CHECK([Quantity] > 0) NOT NULL
)

INSERT INTO [Clients] VALUES
('Teri', 'Ennaco','570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO [Parts]
([SerialNumber],
 [Description],
 [Price],
 [VendorId]) VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive ', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

SELECT *
  FROM [Jobs]
 WHERE [MechanicId] = 3

 UPDATE [Jobs]
	SET [MechanicId] = 3, [Status] = 'In Progress'
  WHERE [Status] = 'Pending'

SELECT *
  FROM [OrderParts]
 WHERE [OrderId] = 19

DELETE
  FROM [OrderParts]
 WHERE [OrderId] = 19

DELETE
  FROM [Orders]
 WHERE [OrderId] = 19

   SELECT CONCAT([m].FirstName, ' ', [m].LastName) AS [Mechanic],
		  [j].[Status],
		  [j].[IssueDate]
     FROM [Mechanics]
	   AS [m]
LEFT JOIN [Jobs]
	   AS [j]
	   ON [m].[MechanicId] = [j].[MechanicId]
 ORDER BY [m].[MechanicId],
		  [j].[IssueDate],
		  [j].[JobId]

	SELECT CONCAT([c].[FirstName], ' ', [c].[LastName]) AS [Client],
		   DATEDIFF(DAY, [j].IssueDate, '04/24/2017') AS [Days going],
		   [j].[Status]
	  FROM [Clients]
		AS [c]
	  JOIN [Jobs]
		AS [j]
		ON [c].[ClientId] = [j].[ClientId]
	 WHERE [j].[Status] != 'Finished'
  ORDER BY [Days going] DESC,
		   [c].[ClientId]

	SELECT CONCAT([m].[FirstName], ' ', [m].[LastName]) AS [Mechanic],
		   AVG(DATEDIFF(DAY, [j].IssueDate, [j].[FinishDate])) AS [Average Days]
	  FROM [Mechanics]
	    AS [m]
	  JOIN [Jobs]
	    AS [j]
		ON [m].[MechanicId] = [j].[MechanicId]
  GROUP BY [m].[FirstName], [m].[LastName], [m].[MechanicId]
  ORDER BY [m].[MechanicId]