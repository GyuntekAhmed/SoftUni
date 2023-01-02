SELECT FirstName, LastName
	FROM Employees
 WHERE CHARINDEX('ei', LastName) <> 0

SELECT FirstName
	FROM Employees
 WHERE DepartmentID IN (3, 10) AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

SELECT FirstName, LastName
	FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%'

 SELECT [Name]
	FROM Towns
	WHERE LEN([Name]) IN (5, 6)
	ORDER BY Towns.Name

SELECT *
	FROM Towns
	WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
	ORDER BY [Name]

CREATE VIEW [V_EmployeesHiredAfter2000]
	AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE DATEPART(YEAR, HireDate) > 2000

SELECT FirstName, LastName
	FROM Employees
	WHERE LEN(LastName) = 5

SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID)
	AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC

SELECT *
FROM (
	SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID)
	AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	)
	AS RankingSubquery
 WHERE [Rank] = 2
 ORDER BY Salary DESC