USE SoftUni

SELECT * FROM Employees
WHERE Salary > 20000
ORDER BY Salary


SELECT * FROM Employees
ORDER BY Salary DESC

SELECT EmployeeID, FirstName, LastName, Salary FROM Employees
WHERE SALARY > 20000
ORDER BY FirstName


SELECT EmployeeID AS Id, FirstName, LastName, Salary FROM Employees
WHERE SALARY > 20000
ORDER BY FirstName


SELECT EmployeeID AS [EM ID], FirstName, LastName, Salary FROM Employees
WHERE SALARY > 20000
ORDER BY FirstName

---
SELECT * FROM Departments
JOIN Employees ON Departments.ManagerID = Employees.EmployeeID


SELECT Departments.DepartmentID, Departments.Name AS [Department Name], Employees.FirstName +' '+ Employees.LastName AS [Manager Name] FROM Departments
JOIN Employees ON Departments.ManagerID = Employees.EmployeeID

SELECT d.DepartmentID,
	   d.Name AS [Department Name],
	   e.FirstName +' '+ e.LastName AS [Manager Name]
	   FROM Departments AS d
JOIN Employees AS e ON d.ManagerID = e.EmployeeID

--PROMBLEM1

SELECT FirstName+' ' + LastName AS [Full Name],
       JobTitle AS [Job Title],
	   Salary
  FROM Employees


  -- DISTINCT
SELECT DISTINCT  DepartmentID
  FROM Employees

 --WHERE
 SELECT * FROM Employees
 WHERE DepartmentID = 6

 
 SELECT * FROM Employees
 WHERE DepartmentID = (SELECT DepartmentID FROM Departments WHERE Name='Marketing')

 SELECT * FROM Employees
 WHERE NOT (ManagerID = 3 OR ManagerID = 4)

--SAME 
 SELECT * FROM Employees
 WHERE ManagerID NOT IN (3, 4)

 -- NULL/NOT NULL
 SELECT * FROM Employees
 WHERE MiddleName IS NOT NULL


 --VIEW
 GO
 CREATE VIEW v_EmployeesNamesAndDepartments AS 
 SELECT d.DepartmentID,
	   d.Name AS [Department Name],
	   e.FirstName +' '+ e.LastName AS [Manager Name]
	   FROM Departments AS d
JOIN Employees AS e ON d.ManagerID = e.EmployeeID

GO

SELECT * FROM v_EmployeesNamesAndDepartments

-- PROBLEM 2

USE Geography

SELECT TOP 5 * FROM Peaks
ORDER BY Elevation DESC

--PERCENT
SELECT TOP 5 PERCENT * FROM Peaks
ORDER BY Elevation DESC

--VIEW
GO
CREATE VIEW v_HighestPeak AS
SELECT TOP 5 * FROM Peaks
ORDER BY Elevation DESC

SELECT * FROM v_HighestPeak

USE SoftUni
SELECT * FROM Employees

SELECT *
INTO EmployeesNamesAndDepartments
FROM v_EmployeesNamesAndDepartments


--SEQUENCES
CREATE SEQUENCE seq_Customers_CustomerID
	AS INT
	START WITH 5
	INCREMENT BY 10

SELECT NEXT VALUE FOR seq_Customers_CustomerID

-- DELETE
SELECT * FROM EmployeesNamesAndDepartments

-- DELETE PIECE OF DATA
DELETE FROM EmployeesNamesAndDepartments
WHERE DepartmentID=5

--DELETE WHOLE DATA
DELETE FROM EmployeesNamesAndDepartments

--BETTER VARIANT

--UPDATE
SELECT * FROM Employees

UPDATE Employees
SET MiddleName = 'Ivanov'
WHERE EmployeeID = 3

-- PROBLEM PROJECTS
SELECT * FROM Projects

UPDATE Projects
SET EndDate = GETDATE()
WHERE EndDate IS NULL

TRUNCATE TABLE EmployeesNamesAndDepartments