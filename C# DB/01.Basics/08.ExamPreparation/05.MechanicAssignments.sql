SELECT Concat(m.[FirstName],' ',m.[LastName]) AS [Mechanic],
	   j.[Status],
	   j.[IssueDate]
FROM [Mechanics] AS m
LEFT JOIN [Jobs] AS j ON m.[MechanicId] = j.[MechanicId]
ORDER BY m.[MechanicId],j.[IssueDate],j.[JobId]