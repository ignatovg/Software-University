SELECT * FROM Cars
SELECT * FROM Drivers

SELECT * FROM Cars
JOIN Drivers ON Drivers.Id = Cars.DriverId

SELECT c.Id,c.Name, d.Name FROM Cars AS c
JOIN Drivers AS d ON d.Id = c.DriverId

--PROBLEM
SELECT * FROM Mountains
SELECT * FROM Peaks

SELECT m.MountainRange,
	p.PeakName,
	p.Elevation FROM Mountains AS m
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC


--- CASCADING OPERATIONS
