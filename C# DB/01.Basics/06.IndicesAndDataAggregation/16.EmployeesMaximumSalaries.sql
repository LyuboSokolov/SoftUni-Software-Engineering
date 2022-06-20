SELECT [DepartmentID],MAX(Salary)
FROM [Employees]
GROUP BY [DepartmentID]
HAVING  MAX([Salary]) < 30000 OR MAX([Salary]) > 70000