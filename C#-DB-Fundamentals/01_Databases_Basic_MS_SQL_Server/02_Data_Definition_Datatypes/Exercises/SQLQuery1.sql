
CREATE DATABASE Minions

USE Minions

CREATE TABLE Minions(
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	Age INT NOT NULL,
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
)

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

INSERT INTO Minions (Id, [Name], Age) 
VALUES (1, 'Ivan', 19)

GO
INSERT INTO Minions(Id,[Name],Age,TownId)
VALUES(2, 'Prakash', 20, )

GO
INSERT INTO Minions(Id,[Name],Age)
VALUES(3, 'Dragan', 25)

SELECT * FROM Minions

GO
INSERT INTO Towns(Id, [Name])
VALUES (1, 'Sofia')

GO
INSERT INTO Towns(Id,[Name])
VALUES (2,'Plovdiv')

GO
INSERT INTO Towns(Id,[Name])
VALUES (3,'Varna')

SELECT * FROM Minions