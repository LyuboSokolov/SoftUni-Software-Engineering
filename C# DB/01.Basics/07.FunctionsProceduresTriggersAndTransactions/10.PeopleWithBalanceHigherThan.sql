CREATE PROC usp_GetHoldersWithBalanceHigherThan(@moneyInput MONEY)
AS
	SELECT [FirstName],[LastName] FROM(SELECT ah.[FirstName],[LastName],SUM(a.[Balance]) AS [TotalAmount]
	FROM [AccountHolders] AS ah
	 JOIN [Accounts] AS a ON ah.[Id] = a.[AccountHolderId]
	GROUP BY ah.[FirstName],[LastName]
	HAVING SUM(a.[Balance]) > @moneyInput)  AS [test]
	ORDER BY [FirstName],[LastName]