USE SoftUni

--P.01
GO
CREATE OR ALTER PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName,LastName FROM Employees
	WHERE Salary > 35000	
END
GO

EXEC dbo.usp_GetEmployeesSalaryAbove35000

--P.02
GO
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@salary DECIMAL(18,4)) 
AS
BEGIN
	SELECT FirstName, LastName FROM Employees
	WHERE Salary >= @salary
END

GO

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100

--P.03
GO
CREATE PROC usp_GetTownsStartingWith (@letter NVARCHAR(10))
AS
BEGIN
	SELECT Name AS [Town] FROM Towns
	WHERE Name LIKE  @letter + '%'
END
GO

EXEC dbo.usp_GetTownsStartingWith b

--P.04

GO
CREATE PROC usp_GetEmployeesFromTown (@town NVARCHAR(16))
AS
BEGIN
	SELECT e.FirstName, e.LastName FROM Employees AS e
	JOIN Addresses AS a
	ON a.AddressID = e.AddressID
	JOIN Towns AS t
	ON t.TownID = a.TownID
	WHERE t.Name = @town
END
GO

EXEC dbo.usp_GetEmployeesFromTown Sofia

--P.05
GO
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel NVARCHAR(10)

		IF (@salary < 30000)
			 SET @salaryLevel = 'Low'
		ELSE IF(@salary >= 30000 AND @salary <= 50000)
			 SET @salaryLevel = 'Average'
		ELSE
			 SET @salaryLevel = 'High'
RETURN @salaryLevel
END
GO

SELECT Salary,
		dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
		 FROM Employees

--P.06 ---
GO
CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel NVARCHAR(10))
AS
BEGIN
	DECLARE @salaryLevelAsNum DECIMAL(18,4);

	SET @salaryLevelAsNum = 
	CASE
		WHEN @salaryLevel = 'Low' THEN 29500
		WHEN @salaryLevel = 'Average' THEN 50000 
		ELSE 60000
	END

	SELECT FirstName,LastName, dbo.ufn_GetSalaryLevel(@salaryLevelAsNum) FROM Employees
	
END
GO

EXEC dbo.usp_EmployeesBySalaryLevel 'High'

GO
--P.07

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(20), @word NVARCHAR(20)) 
RETURNS INT
AS 
BEGIN

	DECLARE @cnt INT = 1

	WHILE @cnt <= LEN(@setOfletters)
	BEGIN
		DECLARE @isValid INT = 0;
		DECLARE @currentLetter NVARCHAR(1);
		DECLARE @countLetters INT;
		SET @currentLetter = SUBSTRING(@setOfletters,@cnt,1)
	
		IF(@word LIKE '%'+@currentLetter + '%')
		BEGIN
			SET @countLetters = @countLetters + 1;
		END

		IF(@countLetters = LEN(@word))
		BEGIN
			SET @isValid = 1
		END

		SET @cnt = @cnt + 1;	
	END
	RETURN @isValid
END

GO
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia') 

GO
--P.07 Lecture
CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	
	DECLARE @currentLetter CHAR;
	DECLARE @counter INT = 1;

	WHILE (LEN(@word) >= @counter)
	BEGIN
		
		SET @currentLetter = SUBSTRING(@word, @counter, 1) -- FIRST ACTION
		DECLARE @match INT = CHARINDEX(@currentLetter,@setOfLetters);

		IF(@match = 0)
		BEGIN
			RETURN 0;
		END

		SET @counter =@counter + 1;
	END

	RETURN 1
END

GO

SELECT dbo.ufn_IsWordComprised('oistmiahf','Sofia')

--P.08
GO
CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId
	)

	ALTER TABLE Departments
	ALTER COLUMN ManagerId INT NULL;

	UPDATE Departments 
	SET ManagerID = NULL
	WHERE ManagerID IN (
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId
		)

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

END


EXEC sp_depends 'usp_DeleteEmployeesFromDepartment'