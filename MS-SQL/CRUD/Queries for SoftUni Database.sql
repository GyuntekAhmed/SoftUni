SELECT FirstName + '.' + LastName + '@' + 'softuni.bg'
   AS FullEmailAddress
   FROM Employees

 SELECT CONCAT(FirstName, ' ', MiddleName,' ', LastName)
      AS [Full Name]
    FROM Employees
   WHERE Salary IN (25000, 14000, 12500, 23600)

   SELECT FirstName, LastName
     FROM Employees
    WHERE ManagerID IS NULL

SELECT *
     FROM Employees
	 ORDER BY Salary DESC, FirstName, LastName DESC, MiddleName

 CREATE VIEW [V_EmployeesSalaries]
    AS
SELECT FirstName, LastName, Salary
   FROM Employees

 CREATE VIEW [V_EmployeeNameJobTitle]
    AS
SELECT CONCAT(FirstName,' ', MiddleName, ' ', LastName) AS [Full Name], JobTitle
   FROM Employees

SELECT TOP(10) *
   FROM Projects
   ORDER BY StartDate, [Name]

SELECT TOP(7) FirstName, LastName, HireDate
   FROM Employees
   ORDER BY HireDate DESC

SELECT *
   FROM Departments
   WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')

UPDATE Employees
   SET Salary += Salary * 0.12
   WHERE DepartmentID IN (1, 2, 4, 11)

SELECT Salary
   FROM Employees