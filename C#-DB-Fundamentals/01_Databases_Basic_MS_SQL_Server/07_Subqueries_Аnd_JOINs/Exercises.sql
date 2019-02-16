--01.
SELECT TOP 5 e.EmployeeID,
		e.JobTitle,
		a.AddressID,
		a.AddressText
		 FROM Employees AS e
	JOIN Addresses AS a
	ON a.AddressID = e.AddressID
ORDER BY A.AddressID

--02.
SELECT TOP 50 e.FirstName,
		e.LastName,
		t.Name AS [Town],
		a.AddressText
	 FROM Employees AS e
	 JOIN Addresses AS a
	 ON a.AddressID = e.AddressID
	 JOIN Towns AS t
	 ON t.TownID = a.TownID
	 ORDER BY e.FirstName, e.LastName

--03.
SELECT e.EmployeeID,
		e.FirstName,
		e.LastName,
		d.Name AS [DepartmentName]
	FROM Employees AS e
	JOIN Departments AS d
	ON d.DepartmentID = e.DepartmentID
 WHERE d.Name = 'Sales'
 ORDER BY e.EmployeeID 

 --04.
 SELECT TOP 5 e.EmployeeID,
			e.FirstName,
			e.Salary,
			d.Name AS [DepartmentName] 
  FROM Employees AS e
 JOIN Departments AS d
 ON d.DepartmentID = e.DepartmentID
 WHERE e.Salary > 15000
 ORDER BY d.DepartmentID

 --05.
 SELECT TOP 3 e.EmployeeID,
			e.FirstName 
		FROM Employees AS e
 LEFT OUTER JOIN EmployeesProjects AS ep
		 ON ep.EmployeeID = e.EmployeeID
		WHERE ep.EmployeeID IS NULL
	ORDER BY e.EmployeeID

--06.
SELECT * FROM Departments

SELECT  e.FirstName, 
		e.LastName,
		e.HireDate,
		d.Name DeptName 
	FROM Employees AS e
	JOIN Departments AS d
	ON d.DepartmentID = e.DepartmentID
	WHERE e.HireDate > '01/01/1999'
	AND d.Name IN ('Sales','Finance')
ORDER BY e.HireDate

--07.
SELECT TOP 5 e.EmployeeID,
		e.FirstName,
		p.Name AS ProjectName
	FROM Employees AS e
 INNER JOIN EmployeesProjects AS ep
	ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p
	ON p.ProjectID = ep.ProjectID
	WHERE p.StartDate > '08-13-2002'
	AND p.EndDate IS NULL
	ORDER BY e.EmployeeID

--08. CASE
SELECT e.EmployeeID,
		e.FirstName,
CASE WHEN p.StartDate >= '2005'	THEN NULL
ELSE p.Name
END ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p
ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

--09.
SELECT * FROM Employees

SELECT e.EmployeeID,
		e.FirstName,
		e.ManagerID,
		m.FirstName
 FROM Employees AS e
 JOIN Employees AS m
 ON m.EmployeeID= e.ManagerID
WHERE e.ManagerID IN (3,7)
ORDER BY EmployeeID

--10.
SELECT TOP 50 e.EmployeeID,
		e.FirstName + ' ' + e.LastName AS [EmployeeName],
		m.FirstName + ' ' + m.LastName AS [ManagerName],
		d.Name AS [DepartmentName]  
	FROM Employees AS e
	JOIN Employees AS m
	ON m.EmployeeID = e.ManagerID
	JOIN Departments AS d
	ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID

--11.
SELECT * FROM Employees

SELECT MIN(a.AverageSalary) AS MinAverageSalary 
	FROM  
  (
	SELECT AVG(Salary) AS AverageSalary FROM Employees
	GROUP BY DepartmentID
  ) AS a

--12.
USE Geography
SELECT * FROM Mountains
SELECT * FROM MountainsCountries
SELECT * FROM Peaks

SELECT mc.CountryCode,
		m.MountainRange,
		p.PeakName,
		p.Elevation 
	 FROM MountainsCountries AS mc
	JOIN Mountains AS m
	ON m.Id = mc.MountainId
	JOIN Peaks AS p
	ON p.MountainId = mc.MountainId
	WHERE mc.CountryCode = 'BG'
	AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13.
SELECT mc.CountryCode,
	COUNT(m.MountainRange) AS [MountainRange]
	 FROM MountainsCountries AS mc
	JOIN Mountains AS m
    ON m.Id = mc.MountainId
GROUP BY CountryCode
 HAVING mc.CountryCode IN ('BG','RU','US')

 SELECT *
	 FROM MountainsCountries AS mc
	JOIN Mountains AS m
    ON m.Id = mc.MountainId

--14.

SELECT * FROM CountriesRivers
SELECT * FROM Rivers

SELECT TOP 5 c.CountryName,
		r.RiverName
	 FROM Countries AS c
	LEFT OUTER JOIN CountriesRivers AS cr
	ON cr.CountryCode = c.CountryCode
	LEFT OUTER JOIN Rivers AS r
	ON r.Id = cr.RiverId
	WHERE c.ContinentCode = 'AF'
	ORDER BY c.CountryName

--15.
SELECT ContinentCode,CurrencyCode, CurrencyUsage
FROM 
(SELECT ContinentCode,CurrencyCode, CurrencyUsage,
	DENSE_RANK() OVER(PARTITION BY(ContinentCode) 
	ORDER BY CurrencyUsage DESC) AS [Rank]
FROM (
SELECT ContinentCode,CurrencyCode, COUNT(CurrencyCode) AS CurrencyUsage
	FROM Countries
	GROUP BY CurrencyCode, ContinentCode
	) AS Currencies
) AS RankedCurrencies
WHERE [Rank] = 1 AND CurrencyUsage > 1
ORDER BY ContinentCode
	 
--16.
SELECT COUNT(CountryCode) AS CountryCode
FROM Countries
WHERE CountryCode NOT IN (SELECT CountryCode
 FROM MountainsCountries)

 --18.
 SELECT TOP 5 CountryName,
 CASE 
	WHEN PeakName IS NULL THEN '(no highest peak)'
	ELSE PeakName
	END AS [Highest Peak Name],
 
 CASE 
	WHEN Elevation IS NULL THEN 0
	ELSE Elevation
	END AS [Highest Peak Elevation],
 
 CASE 
	WHEN MountainRange IS  NULL THEN '(no mountain)'
	ELSE MountainRange
	END AS [Mountain]
 FROM (
 SELECT CountryName,PeakName,Elevation,MountainRange,
	DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY Elevation DESC) AS [Rank]
	FROM (
		SELECT c.CountryName, p.PeakName, p.Elevation,m.MountainRange
		FROM Countries AS c
		 LEFT JOIN MountainsCountries AS mc
		ON mc.CountryCode = c.CountryCode
		 LEFT JOIN Mountains AS m
		ON m.Id = mc.MountainId
		LEFT JOIN Peaks AS p
	ON m.Id = p.MountainId)
	 AS AllPeaks)
AS RankedPeaks
WHERE [Rank] = 1
ORDER BY CountryName, [Highest Peak Elevation]