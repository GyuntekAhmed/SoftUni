SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM Peaks AS p
  INNER JOIN Mountains AS m
	ON p.MountainId = m.Id
  INNER JOIN MountainsCountries AS mc
	ON m.Id = mc.MountainId
	WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
	ORDER BY p.Elevation DESC

SELECT c.CountryCode, COUNT(mc.MountainId) AS MountainRanges
	FROM Countries AS c
  LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
	WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
	GROUP BY c.CountryCode

SELECT TOP(5) c.CountryName, r.RiverName
	FROM Countries AS c
  LEFT JOIN CountriesRivers AS cr
	ON c.CountryCode = cr.CountryCode
  LEFT JOIN Rivers AS r
	ON r.Id = cr.RiverId
	WHERE c.ContinentCode = 'AF'
	ORDER BY c.CountryName

SELECT ContinentCode, CurrencyCode, CurrencyUsage
	FROM
	(
		SELECT *,
			DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC)
			AS CurrencyRank
			FROM
			(
				SELECT cnt.ContinentCode, c.CurrencyCode,
				 COUNT(c.CurrencyCode) AS CurrencyUsage
					FROM Continents AS cnt
				  LEFT JOIN Countries AS c
					ON c.ContinentCode = cnt.ContinentCode
					GROUP BY cnt.ContinentCode, c.CurrencyCode
			) AS CurrencyQuery
		WHERE CurrencyUsage > 1
	) AS CurrencyRankingQuery
	WHERE CurrencyRank = 1
  ORDER BY ContinentCode

SELECT COUNT(c.CountryCode) as CountryCount
	FROM Countries as c
  LEFT JOIN MountainsCountries as mc ON c.CountryCode = mc.CountryCode
	WHERE mc.MountainId IS NULL;

SELECT TOP(5) [c].[CountryName],
	   MAX([p].[Elevation]) AS HighestPeakElevation,
	   MAX([r].[Length]) AS [LongestRiverLength]
	  FROM [Countries] AS [c]
 LEFT JOIN [CountriesRivers] AS [cr]
		ON [c].[CountryCode] = [cr].[CountryCode]
 LEFT JOIN [Rivers] AS [r]
		ON [cr].[RiverId] = [r].[Id]
 LEFT JOIN [MountainsCountries] AS [mc]
		ON [mc].CountryCode = [c].[CountryCode]
 LEFT JOIN [Mountains] AS m
		ON [mc].[MountainId] = [m].[Id]
 LEFT JOIN [Peaks] AS [p]
		ON [p].[MountainId] = [m].[Id]
  GROUP BY [c].[CountryName]
  ORDER BY [HighestPeakElevation] DESC,
		   [LongestRiverLength] DESC,
		   [CountryName]

SELECT TOP(5) [Country],
		CASE
		 WHEN [PeakName] IS NULL THEN '(no highest peak)'
		 ELSE [PeakName]
	   END AS [Highest Peak Name],
		CASE
		 WHEN [Elevation] IS NULL THEN 0
		 ELSE [Elevation]
	   END AS [Highest Peak Elevation],
	    CASE
		 WHEN [MountainRange] IS NULL THEN '(no mountain)'
		 ELSE [MountainRange]
	   END AS [Mountain]
	FROM
	(
	   SELECT [c].[CountryName] AS [Country],
			  [m].[MountainRange],
			  [p].[PeakName],
			  [p].[Elevation],
			  DENSE_RANK() OVER(PARTITION BY [c].[CountryName] ORDER BY [p].[Elevation] DESC)
		   AS [PeakRank]
		 FROM [Countries] AS c
	LEFT JOIN [MountainsCountries] AS mc
		   ON [mc].[CountryCode] = [c].[CountryCode]
	LEFT JOIN [Mountains] AS [m]
		   ON [mc].[MountainId] = [m].[Id]
	LEFT JOIN [Peaks] AS [p]
		   ON [p].[MountainId] = [m].[Id]
	)	   AS [RankingQuery]
		WHERE [PeakRank] = 1
	 ORDER BY [Country], [Highest Peak Name]