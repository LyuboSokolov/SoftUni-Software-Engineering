SELECT
[EmployeeID],
[FirstName],
CASE
WHEN YEAR(EmpAndProjects.[StartDate]) >= '2005' THEN NULL
ELSE EmpAndProjects.[ProjectName]
END AS [ProjectName]
FROM (
SELECT
e.[EmployeeID],
e.[FirstName],
p.[Name] AS [ProjectName],
p.[StartDate]
FROM [Employees] AS e
JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
WHERE e.[EmployeeID] = 24) AS EmpAndProjects