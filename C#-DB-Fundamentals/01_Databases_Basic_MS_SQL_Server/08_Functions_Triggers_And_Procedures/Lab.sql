CREATE OR ALTER FUNCTION udf_ProjectDurationWeeks(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
	BEGIN
		IF(@EndDate IS NULL)
		BEGIN
			SET @EndDate = GETDATE();
		END
		
		DECLARE @ProjectWeeks INT;

		SET @ProjectWeeks = DATEDIFF(WEEK,@StartDate,@EndDate);

		RETURN @ProjectWeeks
	END
GO

SELECT Name,
		StartDate,
		EndDate,
		dbo.udf_ProjectDurationWeeks(StartDate,EndDate) AS ProjectDurationWeeks
FROM Projects

--alter functions
GO
DROP FUNCTION dbo.udf_ProjectDurationWeeks

-- or ALTER FUNCTION udf_NAME ()

-- or CREATE OR ALTER FUNCTION udf_NAME () 

--Ex. SALARY LEVEL 
GO
CREATE OR ALTER FUNCTION udf_GetSalaryLevel(@Salary	MONEY)
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @SalaryLevel VARCHAR(7);
	
	SET @SalaryLevel = 
		CASE
		 WHEN @Salary < 300000 THEN 'Low'
		 WHEN @Salary BETWEEN 30000 AND 50000 THEN 'Average'
		 ELSE 'High'
			
		END
	--IF(@Salary < 30000)
	--BEGIN
	--	SET @SalaryLevel = 'Low';
	--END
	--ELSE IF (@Salary BETWEEN 30000 AND 50000)
	--BEGIN
	--	SET @SalaryLevel = 'Average';
	--END
	--ELSE
	--BEGIN
	--	SET @SalaryLevel = 'High';
	--END
	
	RETURN @SalaryLevel
END

GO

SELECT EmployeeID,
		FirstName,
		LastName,
		Salary,
		dbo.udf_GetSalaryLevel(Salary) AS SalaryLevel
   FROM Employees
	ORDER BY SalaryLevel

-- count employees
SELECT dbo.udf_GetSalaryLevel(Salary) AS SalaryLevel,
		COUNT(*)
   FROM Employees
   GROUP BY dbo.udf_GetSalaryLevel(Salary)

--Ex.2
GO
CREATE FUNCTION udf_GetAgeGroup(@Age INT)
RETURNS VARCHAR(10)
AS
BEGIN
	--Age: 36
	-- Lower Bound: 31
	-- Upper Bound: 40
	-- End Result: [31-40]
	--DECLARE @SampleAge INT = 36;

	DECLARE @LowerBound INT = ((@Age - 1) / 10) * 10 + 1;
	DECLARE @UpperBound INT = (@LowerBound - 1) + 10;
	DECLARE @Result	VARCHAR(10) = '[' + CAST(@LowerBound AS VARCHAR(3)) + '-' + CAST(@UpperBound AS VARCHAR(3))+ ']';

	-- SELECT @Result
	RETURN @Result
END
GO
SELECT Age, dbo.udf_GetAgeGroup(Age) FROM WizzrdDeposits

-- Procedures
--Ex. 1
GO
CREATE OR ALTER PROCEDURE usp_GetEmployeesBySeniority @HireYears INT = 5
AS
BEGIN
	SELECT * FROM Employees
	WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > @HireYears 
END
GO
 EXEC dbo.usp_GetEmployeesBySeniority 20

EXEC sp_depends 'dbo.usp_GetEmployeesBySeniority'

GO
CREATE OR ALTER PROCEDURE usp_AddEmployeeToProject @EmployeeId INT, @ProjectId INT
AS
BEGIN
	DECLARE @EmployeeProjectCount INT;
	SET @EmployeeProjectCount = (SELECT COUNT(*) FROM EmployeesProjects
WHERE EmployeeID = @EmployeeId)
	
	IF(@EmployeeProjectCount >= 3 )
	BEGIN
		 RAISERROR('Employee has to many projects!', 16, 1)
		 RETURN 
	END

	INSERT INTO EmployeesProjects(EmployeeID,ProjectID)
		VALUES (@EmployeeId,@ProjectId)
END
GO

EXEC usp_AddEmployeeToProject 1, 2 

