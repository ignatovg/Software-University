USE TableRelationsDemo


-- ONE TO MANY
CREATE TABLE Mountains(
	Id INT IDENTITY,
	Name VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Mountains PRIMARY KEY(Id)
)

CREATE TABLE Peaks(
	Id INT IDENTITY,
	Name VARCHAR(50) NOT NULL,
	MountainId INT NOT NULL,
	
	CONSTRAINT PK_Peaks PRIMARY KEY(Id),

	CONSTRAINT FK_Peaks_Mountains 
	FOREIGN KEY (MountainId) 
	REFERENCES Mountains(Id)
)

INSERT INTO Mountains (Name) VALUES
('Rila'),
('Pirin')

SELECT * FROM Mountains
SELECT * FROM Peaks

INSERT INTO Peaks(Name,MountainId) VALUES
('Musala',1),
('Malyvitsa',1),
('Vihren',2),
('Kutelo',2)

SELECT * FROM Peaks

SELECT FROM Mountains

--MANY TO MANY

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Projects(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE EmployeesProjects(
	EmployeeId INT,
	ProjectId INT,

	CONSTRAINT PK_EmployeesProjects
	PRIMARY KEY (EmployeeId,ProjectId),

	CONSTRAINT FK_EmployeesProjects_Employees 
	FOREIGN KEY (EmployeeId)
	REFERENCES Employees(Id),
	
	CONSTRAINT FK_EmployeesProjects_Projects 
	FOREIGN KEY (ProjectId)
	REFERENCES Projects(Id)
)

SELECT * FROM INFORMATION_SCHEMA.TABLES

INSERT INTO Employees(Name) VALUES
('Bay Ivan'),
('Gosho'),
('Ivan Ivanov')

INSERT INTO Projects(Name) VALUES
('MySQL Project'),
('Super Java Project'),
('Microsoft Hell')

SELECT * FROM Employees
SELECT * FROM Projects
SELECT * FROM EmployeesProjects
INSERT INTO EmployeesProjects(EmployeeId,ProjectId) VALUES
(1,2),
(1,3),
(3,3),
(2,1)


SELECT * FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeId = e.Id
JOIN Projects AS p ON p.Id = ep.ProjectId

--ONE TO ONE

CREATE TABLE Drivers(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	DriverId INT FOREIGN KEY REFERENCES Drivers(Id) UNIQUE
)

INSERT INTO  Drivers(Name) VALUES
('Ivan Ivanov'),
('Toshko')

INSERT INTO Cars(Name, DriverId) VALUES
('Mercedes',1),
('Trabant',2)

SELECT * FROM Drivers
SELECT * FROM Cars

-- ONE TO MANY
CREATE TABLE Mountainss(
	MountainID INT PRIMARY KEY, 
	MountainName VARCHAR(50) 
)

CREATE TABLE Peakss(
	PeakId INT PRIMARY KEY,
	MointainID INT,
	CONSTRAINT FK_Peaks_Mountains
	FOREIGN KEY (MointainID)
	REFERENCES Mountainss(MountainID)
)

--MANY TO MANY
CREATE TABLE Employeess(
	EmployeeID INT PRIMARY KEY, 
	EmployeeName VARCHAR(50)
)

CREATE TABLE Projectss(
	ProjectID INT PRIMARY KEY,
	ProjectName VARCHAR(50)
)

CREATE TABLE EmployeeProjectss(
	EmployeeID INT,
	ProjectID INT,

	CONSTRAINT PK_EmployeesProjects
	PRIMARY KEY(EmployeeID, ProjectID),
	
	CONSTRAINT FK_EmployeesProjects_Employee
	FOREIGN KEY(EmployeeID)
	REFERENCES Employeess(EmployeeID),

	CONSTRAINT FK_EmployeesProjects_Projects
	FOREIGN KEY(ProjectID)
	REFERENCES Projectss(ProjectID)
)


-- ONE TO ONE
CREATE TABLE Driverss(
	DriverId INT PRIMARY KEY,
	DriverName VARCHAR(50)
)

CREATE TABLE Carss(
	CarId INT PRIMARY KEY,
	DriverId INT UNIQUE,
	
	CONSTRAINT FK_Cars_Drivers 
	FOREIGN KEY(DriverId)
	REFERENCES Driverss(DriverId)
)
