SELECT FirstName + '.' + LastName + '@' + 'softuni.bg'
   AS FullEmailAddress
   FROM Employees

   SELECT FirstName, MiddleName, LastName
   AS [Full Name]
   FROM Employees
   WHERE Salary IN (25000, 14000, 12500, 23600)