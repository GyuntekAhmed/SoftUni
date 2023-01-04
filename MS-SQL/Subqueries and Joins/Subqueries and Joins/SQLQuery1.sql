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