SELECT
[CountryCode],
COUNT(CountryCode)
FROM [MountainsCountries] 
WHERE [CountryCode] IN ('BG','RU','US')
GROUP BY [CountryCode] 