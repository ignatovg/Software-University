CREATE TABLE AccountTypes(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Accounts(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AccountTypeId INT FOREIGN KEY REFERENCES AccountTypes(Id),
	Balance DECIMAL(15,2) NOT NULL DEFAULT(0),
	ClientId INT FOREIGN KEY REFERENCES Clients(Id)
)

INSERT INTO Clients(FirstName, LastName) VALUES
('Gosho','Ivanov'),
('Pesho','Petrov'),
('Ivan','Iliev'),
('Merry','Ivanova')

INSERT INTO AccountTypes(Name) VALUES
('Checking'),
('Savings')

INSERT INTO Accounts(ClientId,AccountTypeId,Balance) VALUES
(1, 1, 175),
(2,1,275.42),
(3,1,132),
(4,1,40),
(4,2,365)

GO 

CREATE VIEW v_ClientBalances AS
SELECT (FirstName + ' ' + LastName) AS [Name],
	(AccountTypes.Name) AS [Account Type], Balance 
	FROM Clients
	JOIN Accounts ON Clients.Id = Accounts.ClientId
	JOIN AccountTypes ON AccountTypes.Id = Accounts.AccountTypeId

GO
SELECT * FROM v_ClientBalances

GO

CREATE FUNCTION f_CalculateTotalBalance(@ClientId INT)
RETURNS DECIMAL(15,2)
BEGIN
	DECLARE @result AS DECIMAL(15,2) = (
	SELECT SUM(Balance)
	FROM Accounts WHERE ClientId =@ClientId
	)
	RETURN @result
END

GO

SELECT dbo.f_CalculateTotalBalance(4) AS Balcance

GO

CREATE PROC p_AddAcount @ClientId INT, @AccountTypeId INT AS
INSERT INTO Accounts (ClientId, AccountTypeId)
VALUES (@ClientId, @AccountTypeId)

p_AddAcount 2, 2

SELECT * from Accounts

GO
CREATE PROC p_Deposit @AccountId INT, @Amount DECIMAL(15,2) AS
UPDATE Accounts
SET Balance += @Amount
WHERE Id = @AccountId

p_Deposit 8, 100

select * from Accounts

GO 
CREATE PROC p_Withdraw @AccountId INT, @Amount DECIMAL(15,2) AS
BEGIN
	DECLARE @OldBalance DECIMAL(15,2)
	SELECT @OldBalance = Balance FROM Accounts WHERE Id = @AccountId
	IF(@OldBalance - @Amount >=0)
	BEGIN
		UPDATE Accounts
		SET Balance -=@Amount
		WHERE ID = @AccountId
	END
	ELSE
	BEGIN
	RAISERROR('Insufficient funds', 10,1)
	END
END

p_Withdraw 7,100

GO
CREATE TABLE Transactions(
Id INT PRIMARY KEY IDENTITY NOT NULL, 
AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
OldBalance DECIMAL(15,2) NOT NULL,
NewBalance DECIMAL(15,2) NOT NULL,
Amount AS NewBalance - OldBalance,
[DateTime] DATETIME2
)
GO
CREATE TRIGGER tr_Transaction ON Accounts
AFTER UPDATE
AS
	INSERT INTO Transactions(AccountId, OldBalance,NewBalance,[DateTime])
	SELECT inserted.Id, deleted.Balance, inserted.Balance, GETDATE() FROM inserted
	JOIN deleted ON inserted.Id = deleted.Id

GO
p_Deposit 2,25
GO
p_Deposit 2,40
GO
p_Deposit 4,180

GO
SELECT * FROM Transactions