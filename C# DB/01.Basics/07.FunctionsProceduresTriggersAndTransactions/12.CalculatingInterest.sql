CREATE PROC usp_CalculateFutureValueForAccount(@accoundID INT,@yearlyInterestRate FLOAT)
AS
BEGIN
		SELECT TOP(1)ah.[Id],
		ah.[FirstName],
		ah.[LastName],
		a.[Balance] AS [Current Balance],
		dbo.ufn_CalculateFutureValue (a.[Balance],@yearlyInterestRate,5) AS [Balance in 5 years]
	FROM [AccountHolders] AS ah
	JOIN [Accounts] AS a ON ah.[Id]=a.[AccountHolderId]
	WHERE ah.Id = 1
END