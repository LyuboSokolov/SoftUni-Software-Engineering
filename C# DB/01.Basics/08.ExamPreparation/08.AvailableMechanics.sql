SELECT
	 CONCAT([FirstName],' ',[LastName]) AS [Available]
FROM [Mechanics]
WHERE MechanicId NOT IN 
				(SELECT m.[MechanicId]
				FROM [Mechanics] AS m
			    JOIN [Jobs] AS j ON m.[MechanicId] = j.[MechanicId]
				WHERE j.[FinishDate] IS NULL) 
ORDER BY [MechanicId]