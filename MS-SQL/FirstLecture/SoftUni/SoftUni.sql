CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns
(
   Id INT PRIMARY KEY IDENTITY,
   [Name] VARCHAR(50) NOT NULL
)

INSERT INTO Towns VALUES
('Sofia'),('Plovdiv'),('Varna'),('Burgas')

CREATE TABLE Addresses
(
  Id INT PRIMARY KEY IDENTITY,
  AddressText VARCHAR(100) NOT NULL,
  TownId INT NOT NULL
)

ALTER TABLE Addresses
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

CREATE TABLE Departments
(
   Id INT PRIMARY KEY IDENTITY,
   [Name] VARCHAR(50) NOT NULL
)

INSERT INTO Departments VALUES
('Engineering'),('Sales'),('Marketing'),('Software Development'),('Quality Assurance')

CREATE TABLE Employees
(
   Id INT PRIMARY KEY IDENTITY,
   FirstName VARCHAR(50) NOT NULL,
   MiddleName VARCHAR(50) NOT NULL,
   LastName VARCHAR(50) NOT NULL,
   JobTitle VARCHAR(50) NOT NULL,
   DepartmentId INT NOT NULL,
   HireDate VARCHAR(30) NOT NULL,
   Salary DECIMAL(15,2) NOT NULL,
   AddressId INT
)

ALTER TABLE Employees
ADD FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)

ALTER TABLE Employees
ADD FOREIGN KEY (AddressId) REFERENCES Addresses(Id)

INSERT INTO Employees VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, 01/02/2013, 3500.00,NULL),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, 02/03/2004, 4000.00,NULL),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, 28/08/2016, 525.25,NULL),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, 09/12/2007, 3000.00,NULL),
('Peter', 'Pan', 'Pan', 'Intern', 3, 28/08/2016, 599.88,NULL)

SELECT [Name] FROM Towns
ORDER BY [Name] ASC
SELECT [Name] FROM Departments
ORDER BY [Name] ASC
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

UPDATE Employees
SET Salary *= 1.1
SELECT Salary FROM Employees

