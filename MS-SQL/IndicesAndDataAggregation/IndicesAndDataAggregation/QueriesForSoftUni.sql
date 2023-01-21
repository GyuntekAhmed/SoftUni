	SELECT [DepartmentId], SUM([Salary]) AS [TotalSalary]
	  FROM Employees
  GROUP BY [DepartmentID]

  SELECT [DepartmentID],
		 MIN(Salary) AS MinimumSalary
	FROM [Employees]
   WHERE [DepartmentID] LIKE '[2, 5, 7]'
     AND [HireDate] > '01/01/2000'
GROUP BY [DepartmentID]

SELECT TOP 10 [FirstName],
              [LastName],
              [DepartmentID]
		 FROM [Employees] AS e
		WHERE [Salary] >
	(
		SELECT AVG(Salary)
		 FROM [Employees] AS em
		WHERE e.[DepartmentID] = em.[DepartmentID]
	)