CREATE PROC dbo.usp_GetEmployeesSalaryAboveNumber(@salaryValue DECIMAL(18,4))
AS
SELECT [FirstName] AS [First Name],
[LastName] AS [Last Name]
FROM [Employees]
WHERE [Salary] >= @salaryValue