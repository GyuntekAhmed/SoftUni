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

  SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum]
	  FROM [WizzardDeposits]
	 WHERE [MagicWandCreator] = 'Ollivander family'
  GROUP BY [DepositGroup]
    HAVING SUM([DepositAmount]) < 150000
  ORDER BY [TotalSum] DESC

  SELECT [DepositGroup], [MagicWandCreator], MIN(DepositCharge) AS [MinDepositCharge]
	FROM [WizzardDeposits]
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY [MagicWandCreator], [DepositGroup]

  SELECT [AgeGroup], COUNT(*) AS [WizardCount]
  FROM
	(
	  SELECT [Age],
		CASE
			WHEN AGE BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN AGE BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN AGE BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN AGE BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN AGE BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN AGE BETWEEN 51 AND 60 THEN '[51-60]'
			WHEN AGE >= 61 THEN '[61+]'
			END
			AS [AgeGroup]
		FROM [WizzardDeposits]
	)	  AS [AgeGroupQuery]
	GROUP BY [AgeGroup]
