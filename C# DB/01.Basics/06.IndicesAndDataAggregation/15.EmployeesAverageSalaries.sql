SELECT * INTO EmployeesNew FROM Employees WHERE 1 = 1;

DELETE [EmployeesNew]
WHERE Salary <= 30000

DELETE [EmployeesNew]
WHERE [ManagerID] = 42

UPDATE [EmployeesNew]
SET [Salary] += 5000
WHERE [DepartmentID] = 1

SELECT [DepartmentID], AVG(Salary) AS [AverageSalary]
FROM [EmployeesNew]
GROUP BY [DepartmentID]