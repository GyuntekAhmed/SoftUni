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
	WHERE ep.EmployeeID IS NULL
	ORDER BY e.EmployeeID

SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName
	FROM Employees AS e
  JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name IN ('Finance' , 'Sales') AND e.HireDate > '1999/1/1'
	ORDER BY e.HireDate

SELECT TOP(5) e.EmployeeID, FirstName, p.Name AS ProjectName
	FROM Employees AS e
  JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
  JOIN Projects AS p ON p.ProjectID = ep.ProjectID
	WHERE p.StartDate > '2002/08/13' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID

SELECT TOP(5) e.EmployeeID, FirstName, p.Name AS ProjectName, p.StartDate
	FROM Employees AS e
  JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
  JOIN Projects AS p ON p.ProjectID = ep.ProjectID
	WHERE e.EmployeeID = 24