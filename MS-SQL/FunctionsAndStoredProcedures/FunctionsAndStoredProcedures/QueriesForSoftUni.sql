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