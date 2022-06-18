SELECT TOP (2) [DepositGroup] FROM  (SELECT DepositGroup,AVG(MagicWandSize) AS [AvgWand]
FROM [WizzardDeposits]
GROUP BY [DepositGroup]) AS ase
ORDER BY [AvgWand]