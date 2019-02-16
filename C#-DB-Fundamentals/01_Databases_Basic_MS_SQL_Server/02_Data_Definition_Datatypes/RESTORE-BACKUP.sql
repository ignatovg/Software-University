BACKUP DATABASE Employees
TO DISK = 'D:\Software-University\C#-DB-Fundamentals\01_Databases_Basic_MS_SQL_Server\02_Data_Definition_Datatypes\newbackup.bak'

RESTORE DATABASE Employees 
FROM DISK = 'D:\Software-University\C#-DB-Fundamentals\01_Databases_Basic_MS_SQL_Server\02_Data_Definition_Datatypes\newbackup.bak'