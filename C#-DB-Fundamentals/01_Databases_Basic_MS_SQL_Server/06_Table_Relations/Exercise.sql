--01. ONE TO ONE
--UNIQUE FORGOTTEN

CREATE TABLE Passports(
	PassportID INT PRIMARY KEY,
	PassportNumber VARCHAR(50)
)

CREATE TABLE Persons(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50),
	Salary DECIMAL(7,2),
	PassportID INT UNIQUE,

	CONSTRAINT FK_Persons_Passports
	FOREIGN KEY (PassportID)
	REFERENCES Passports(PassportID)
)

INSERT INTO Passports(PassportID,PassportNumber) 
VALUES 
(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2')

SELECT * FROM Passports
SELECT * FROM Persons

INSERT INTO Persons(FirstName,Salary,PassportID)
VALUES
('Roberto',43300.00,102),
('Tom',56100,103),
('Yana',60200,101)

SELECT * FROM Persons
JOIN Passports ON 
	Passports.PassportID = Persons.PassportID

--02. ONE TO MANY

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50),
	EstablishedOn DATE
)

CREATE TABLE Models(
	ModelID INT PRIMARY KEY,
	Name VARCHAR(50),
	ManufacturerID INT,

	CONSTRAINT FK_Models_Manufacturers
	FOREIGN KEY (ManufacturerID)
	REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers(Name,EstablishedOn)
VALUES
('Audi','07/03/1909'),
('Tesla','01/01/2003'),
('Lada','01/05/1966')

INSERT INTO Models (ModelID,Name,ManufacturerID)
VALUES
(101,'Q7',1),
(102,'A6',1),
(103,'Model S',2),
(104,'Nova',3)

SELECT * FROM Manufacturers
SELECT * FROM Models

SELECT * FROM Models
JOIN Manufacturers ON 
Models.ManufacturerID = Manufacturers.ManufacturerID

--MANY TO MANY 

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50)
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY,
	Name VARCHAR(50)
)

CREATE TABLE StudentsExams(
	StudentID INT,
	ExamID INT,

	CONSTRAINT PK_StudentsExams 
	PRIMARY KEY(StudentID, ExamID),
	
	CONSTRAINT FK_StudentsExams_Students 
	FOREIGN KEY (StudentID) 
	REFERENCES Students(StudentID),

	CONSTRAINT FK_StudentsExams_Exams
	FOREIGN KEY (ExamID)
	REFERENCES Exams(ExamID)
)

INSERT INTO Students (Name) 
VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams (ExamID,Name)
VALUES
(101,'SpringMVC'),
(102,'Neo4j'),
(103,'Oracle 11g')

INSERT INTO StudentsExams (StudentID,ExamID)
VALUES
(1,101),
(1,102),
(1,103),
(2,101),
(3,101),
(2,103)

SELECT * FROM Students
SELECT * FROM Exams
SELECT * FROM StudentsExams

--4. SELF REFERENCING 
CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY,
	Name VARCHAR(50)
	ManagerID INT,

	CONSTRAINT FK_ManagerID_TeacherID
	FOREIGN KEY (ManagerID)
	REFERENCES Teachers(TeacherID)
)

--9. Peaks in Rila
SELECT * FROM Peaks

SELECT * FROM Mountains

SELECT MountainRange,PeakName,Elevation FROM Mountains
JOIN Peaks ON 
Mountains.Id = Peaks.MountainId
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC