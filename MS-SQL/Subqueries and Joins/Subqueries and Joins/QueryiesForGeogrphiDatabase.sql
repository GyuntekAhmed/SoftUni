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