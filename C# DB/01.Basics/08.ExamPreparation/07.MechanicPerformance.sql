SELECT
CONCAT(m.[FirstName],' ',m.[LastName]) AS [Mechanic],
AVG(DATEDIFF(DAY,j.IssueDate,j.[FinishDate])) AS [Average Days]
FROM [Mechanics] AS m
LEFT JOIN [Jobs] AS j ON m.[MechanicId] = j.[MechanicId]
WHERE j.[Status] = 'Finished'
GROUP BY m.[FirstName],m.[LastName],m.[MechanicId]
ORDER BY m.[MechanicId]