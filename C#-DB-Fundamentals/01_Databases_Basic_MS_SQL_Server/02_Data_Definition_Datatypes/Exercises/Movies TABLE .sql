-- MOVIES DATABASE
CREATE DATABASE Movies

USE Movies

--CREATE TABLE Directors 
CREATE TABLE Directors (
	Id INT IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(50)
	CONSTRAINT PK_Id PRIMARY KEY(Id)
)

-- CREATE TABLE Genres
CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(50)
)

INSERT INTO Genres
VALUES('ROCK','somethin')

SELECT * FROM Genres

--AND SO ON AND SO FORTH