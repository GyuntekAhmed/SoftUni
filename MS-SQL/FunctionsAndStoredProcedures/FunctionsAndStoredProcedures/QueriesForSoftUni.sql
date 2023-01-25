CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName, LastName
		FROM Employees
		WHERE Salary >= 35000
END
GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber @minSalary DECIMAL(18,4)
AS
BEGIN
	SELECT [FirstName],
		   [LastName]
	  FROM [Employees]
	  WHERE[Salary] >= @minSalary
END

GO

CREATE PROC usp_GetTownsStartingWith @townName VARCHAR(50)
AS
BEGIN
DECLARE @stringCount INT = LEN(@townName)
	SELECT [Name]
		FROM Towns
		WHERE LEFT([Name], @stringCount) = @townName
END

GO
CREATE PROC usp_GetEmployeesFromTown @townName VARCHAR(50)
AS
BEGIN
	SELECT FirstName, LastName
	  FROM Employees AS e
 LEFT JOIN Addresses AS a
	  ON a.AddressID = e.AddressID
 LEFT JOIN Towns AS t
	  ON t.TownID = a.TownID
	 WHERE t.Name = @townName
END
GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10)

	IF @salary < 30000
	SET @salaryLevel = 'Low'
	ELSE IF @salary BETWEEN 30000 AND 50000
	SET @salaryLevel = 'Average'
	ELSE IF @salary > 50000
	SET @salaryLevel = 'High'
	RETURN @salaryLevel
END
GO

SELECT [Salary], dbo.ufn_GetSalaryLevel(Salary)
	AS [Salary Level]
  FROM [Employees]

GO
CREATE PROC usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(10)
AS
BEGIN
	SELECT [FirstName],
		   [LastName]
	  FROM [Employees]
	 WHERE [dbo].[ufn_GetSalaryLevel](Salary) = @salaryLevel
END
GO

EXEC [dbo].[usp_EmployeesBySalaryLevel] 'Low'
GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @currentIndex int = 1;

WHILE(@currentIndex <= LEN(@word))
	BEGIN

	DECLARE @currentLetter varchar(1) = SUBSTRING(@word, @currentIndex, 1);

	IF(CHARINDEX(@currentLetter, @setOfLetters)) = 0
	BEGIN
	RETURN 0;
	END

	SET @currentIndex += 1;
	END

RETURN 1;
	
END

GO

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS

DECLARE @empIDsToBeDeleted TABLE
(
Id int
)

INSERT INTO @empIDsToBeDeleted
SELECT e.EmployeeID
  FROM Employees AS e
 WHERE e.DepartmentID = @departmentId

ALTER TABLE Departments
ALTER COLUMN ManagerID int NULL

DELETE FROM EmployeesProjects
	  WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

UPDATE Employees
   SET ManagerID = NULL
 WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

UPDATE Departments
   SET ManagerID = NULL
 WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

DELETE FROM Employees
	  WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

DELETE FROM Departments
	  WHERE DepartmentID = @departmentId 

  SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
	JOIN Departments AS d
	  ON d.DepartmentID = e.DepartmentID
   WHERE e.DepartmentID = @departmentId

GO

CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(15,4),
@YearlyInterestRate FLOAT,
@NumberOfYears INT )
RETURNS DECIMAL(15,4)
BEGIN
    DECLARE @FutureValue DECIMAL(15,4);

    SET @FutureValue = @Sum * POWER((1 + @YearlyInterestRate), @NumberOfYears)
    
    RETURN @FutureValue
END

GO

CREATE PROC usp_CalculateFutureValueForAccount (@AccountId INT, @InterestRate FLOAT) AS
SELECT a.Id AS [Account Id],
	   ah.FirstName AS [First Name],
	   ah.LastName AS [Last Name],
	   a.Balance,
	   dbo.ufn_CalculateFutureValue(Balance, @InterestRate, 5) AS [Balance in 5 years]
  FROM AccountHolders AS ah
  JOIN Accounts AS a ON ah.Id = a.Id
 WHERE a.Id = @AccountId

 GO

 CREATE FUNCTION ufn_CashInUsersGames(@Game VARCHAR(50))
RETURNS TABLE
AS
RETURN
SELECT SUM([k].[Cash]) AS [SumCash]
  FROM (
SELECT [ug].[Cash] AS [Cash],
       ROW_NUMBER() OVER (PARTITION BY [g].[Name] ORDER BY [ug].[Cash] DESC) AS [Row]
  FROM [dbo].[Games] AS g
  JOIN [dbo].[UsersGames] AS [ug] ON [g].[Id] = [ug].[GameId]
 WHERE [g].[Name] = @Game) AS k
 WHERE [k].[Row] % 2 = 1