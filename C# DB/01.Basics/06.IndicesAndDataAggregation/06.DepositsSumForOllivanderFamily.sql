SELECT [DepositGroup],SUM([DepositAmount]) AS [TotalAmount]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]