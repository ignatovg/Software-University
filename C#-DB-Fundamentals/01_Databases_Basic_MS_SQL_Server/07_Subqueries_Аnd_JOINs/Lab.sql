--Joins
--01.
SELECT TOP (50) e.FirstName,
		    e.LastName,
	  	    t.Name,
			a.AddressText
	   FROM Employees AS e
	   JOIN Addresses AS a 
		 ON a.AddressID = e.AddressID
	   JOIN Towns AS t
		 ON t.TownID=a.TownID
   ORDER BY e.FirstName, e.LastName

--02.
 SELECT e.EmployeeID,
		e.FirstName,
		e.LastName,
		d.Name AS DepartmentName
   FROM Employees AS e
  INNER JOIN Departments AS d
	 ON d.DepartmentID = e.DepartmentID
  WHERE d.Name = 'Sales'
  ORDER BY e.EmployeeID

 --03.
SELECT e.FirstName,
	   e.LastName,
	   e.HireDate,
	   d.Name AS DepartmentName
  FROM Employees AS e
 INNER JOIN Departments AS d
	ON d.DepartmentID = e.DepartmentID
 WHERE d.Name IN('Sales','Finance')
   AND e.HireDate > '01/01/1999'
 ORDER BY e.HireDate

 --04.
 SELECT TOP 50 e.EmployeeID,
		e.FirstName + ' ' + e.LastName AS [EmployeeName],
		e2.FirstName + ' ' + e2.LastName AS [ManagerName],
		d.Name AS DepartmentName
   FROM Employees AS e
  INNER JOIN Employees AS e2
     ON e.ManagerID = e2.EmployeeID
  INNER JOIN Departments AS d
	 ON d.DepartmentID= e.DepartmentID
  ORDER BY e.EmployeeID

 SELECT * FROM Employees

 --Subqueries

 SELECT * FROM Employees
 WHERE DepartmentID = 
 (
  SELECT d.DepartmentID FROM Departments AS d
  WHERE d.Name = 'Finance'
 )
 --OR

 SELECT * FROM Employees
 WHERE DepartmentID IN 
 (
  SELECT d.DepartmentID FROM Departments AS d
  WHERE d.Name = 'Finance'
  OR d.Name = 'Sales'
 )

 SELECT d.DepartmentID FROM Departments AS d
 WHERE d.Name = 'Finance'

 --05.
 SELECT MIN(AvarageSalary) FROM 
 (
 SELECT DepartmentID,
	 AVG(Salary) AS AvarageSalary
	 FROM Employees
 GROUP BY DepartmentID
 ) AS AverageSalariesByDepartment

--CTE


--Indexes
CREATE NONCLUSTERED INDEX
IX_People_FirstName
ON People(Firstname)
