SELECT 
CONCAT(c.[FirstName],' ',c.[LastName]) AS [Client],
DATEDIFF(DAY,j.[IssueDate],'2017/04/24') AS [Days Going],
j.[Status]
FROM [Clients] AS c
LEFT JOIN [Jobs] AS j ON c.[ClientId] = j.[ClientId]
WHERE j.[Status] NOT IN ('Finished')
ORDER BY [Days Going] DESC,c.[ClientId]