	SELECT [DepositGroup], MAX(MagicWandSize) AS ['LongestMagicWand']
	  FROM [WizzardDeposits]
  GROUP BY [DepositGroup]

	SELECT TOP(2) [DepositGroup]
	  FROM [WizzardDeposits]
  GROUP BY [DepositGroup]
  ORDER BY AVG([MagicWandSize])

	SELECT [DepositGroup], SUM([DepositAmount])
	  FROM [WizzardDeposits]
  GROUP BY [DepositGroup]

	SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum]
	  FROM [WizzardDeposits]
	 WHERE [MagicWandCreator] = 'Ollivander family'
  GROUP BY [DepositGroup]