SELECT TOP(5) EmployeeID, JobTitle, a.AddressID, AddressText
	FROM Employees AS e
  JOIN Addresses AS a ON A.AddressID = E.AddressID
    ORDER BY a.AddressID

SELECT TOP(50) e.FirstName, e.LastName, t.Name, a.AddressText
	FROM Employees AS e
  JOIN Addresses AS a ON a.AddressID = e.AddressID
  JOIN Towns AS t ON t.TownID = a.TownID
	ORDER BY e.FirstName, e.LastName

SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name
	FROM Employees AS e
  JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name = 'Sales'
	ORDER BY e.EmployeeID

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name AS DepartmentName
	FROM Employees AS e
  JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	WHERE Salary > 15000
	ORDER BY d.DepartmentID

SELECT TOP(3) e.EmployeeID, e.FirstName
	FROM Employees AS e
  FULL JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	WHERE ep.ProjectID IS NULL
	ORDER BY e.EmployeeID

SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName
	FROM Employees AS e
  JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name IN ('Finance' , 'Sales') AND e.HireDate > '1999/1/1'
	ORDER BY e.HireDate

SELECT TOP(5) e.EmployeeID, FirstName, p.Name AS ProjectName
	FROM Employees AS e
  JOIN EmployeesProjects AS ep
	ON ep.EmployeeID = e.EmployeeID
  JOIN Projects AS p 
	ON p.ProjectID = ep.ProjectID
	WHERE p.StartDate > '2002/08/13' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID

SELECT e.EmployeeID, e.FirstName, p.name AS ProjectName
	FROM employees AS e
 JOIN EmployeesProjects AS ep
	ON e.EmployeeID = ep.EmployeeID
LEFT OUTER JOIN projects AS p
	ON ep.ProjectID = p.ProjectID
	AND p.StartDate < '2005/01/01'
	WHERE e.EmployeeID = 24

SELECT e.EmployeeID, e.FirstName, m.EmployeeID AS ManagerID, m.FirstName AS ManagerName
	FROM Employees AS e
  INNER JOIN Employees AS m
	ON e.ManagerID = m.EmployeeID
	WHERE m.EmployeeID IN (3, 7)
	ORDER BY e.EmployeeID

SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.LastName AS EmployeeName,
	   m.FirstName + ' ' + m.LastName AS ManagerName,
	   d.[Name] AS DepartmentName
	FROM Employees AS e
  INNER JOIN Employees AS m
	ON m.EmployeeID = e.ManagerID
  INNER JOIN Departments AS d
	ON d.DepartmentID = e.DepartmentID
	ORDER BY e.EmployeeID

SELECT MIN(avgs) AS MinAverageSalary
	FROM 
	(
	SELECT AVG(Salary) AS avgs
	FROM Employees
	GROUP BY DepartmentID
	) AS AverageSalary