CREATE ROLE ProjectManager

CREATE LOGIN PM_Gosho
WITH PASSWORD = N'parola!12'

CREATE USER U_Gosho FOR LOGIN PM_Gosho

 ALTER ROLE ProjectManager ADD MEMBER U_Gosho