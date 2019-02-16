
--P1
SELECT COUNT(wd.Id) AS Count FROM dbo.WizzardDeposits wd

--P2
SELECT  MAX(MagicWandSize) AS LongestMagicWand FROM WIzzardDeposits

--P3
SELECT wd.DepositGroup, MAX(wd.MagicWandSize) AS LongestMagicWand FROM dbo.WizzardDeposits wd
GROUP BY wd.DepositGroup

--P4 unsolved
SELECT wd.DepositGroup FROM dbo.WizzardDeposits wd
GROUP BY wd.DepositGroup

--P5
SELECT wd.DepositGroup, SUM(wd.DepositAmount) AS TotalSum FROM dbo.WizzardDeposits wd
GROUP BY wd.DepositGroup

--P6
SELECT wd.DepositGroup, SUM(wd.DepositAmount) FROM dbo.WizzardDeposits wd
WHERE  wd.MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup

--P7
SELECT wd.DepositGroup,SUM(wd.DepositAmount) AS TotalSum FROM dbo.WizzardDeposits wd
WHERE wd.MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup
HAVING SUM(wd.DepositAmount)<150000
ORDER BY SUM(wd.DepositAmount) DESC

--P8
SELECT DepositGroup,MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, 
DepositGroup

SELECT wd.* FROM dbo.WizzardDeposits wd

--PO9 UNFINISHED
SELECT 
CASE 
WHEN Age BETWEEN 0 AND 10 THEN ('[0-10]')
WHEN Age BETWEEN 11 AND 20 THEN ('[11-20]')
WHEN Age BETWEEN 21 AND 30 THEN ('[21-30]')
WHEN Age BETWEEN 31 AND 40 THEN ('[31-40]')
WHEN Age BETWEEN 41 AND 50 THEN ('[41-50]')
WHEN Age BETWEEN 51 AND 60 THEN ('[51-60]')
ELSE ('[61+]')
END AS SizeGroup
FROM WizzardDeposits

--P10
SELECT DISTINCT LEFT(FirstName,1) AS FirstLetter FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
ORDER BY FirstLetter

--P11
SELECT DepositGroup,
		IsDepositExpired,
		AVG(DepositInterest) AS AverageInterest
	FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup,IsDepositExpired
ORDER BY DepositGroup DESC,
IsDepositExpired ASC

--P13
USE SoftUni
SELECT DepartmentID, SUM(Salary) AS [TotalSalary] FROM Employees
GROUP BY DepartmentID

--P14
SELECT DepartmentID,MIN(Salary) AS [MinimumSalary] FROM Employees
WHERE HireDate > '01/01/2000'
AND DepartmentID IN (2,5,7)
GROUP BY DepartmentID

--P16
SELECT DepartmentID, MAX(Salary) AS [MaxSalary] FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--P17
SELECT COUNT(ManagerID) FROM Employees
WHERE ManagerID IS NULL
GROUP BY ManagerID

SELECT COUNT(Salary) AS [Count] FROM Employees
WHERE ManagerID IS NULL

--P18
USE SoftUni
SELECT DepartmentID, Salary FROM 
(
	SELECT e.DepartmentID,
			MAX(e.Salary) AS Salary,
			DENSE_RANK() OVER(PARTITION BY e.DepartmentID ORDER BY e.Salary DESC) AS Rank
	 FROM dbo.Employees e
	 GROUP BY e.DepartmentID,e.Salary
) AS ThirdPart
WHERE Rank = 3

--P19
  SELECT e.FirstName, e.LastName, e.DepartmentID FROM dbo.Employees e
  WHERE e.Salary > 
  ( SELECT AVG(e2.Salary) FROM dbo.Employees e2 
  WHERE e2.DepartmentID = e.DepartmentID
  GROUP BY e2.DepartmentID)
  