SELECT [CountryName],[IsoCode] 
FROM [Countries]
WHERE LOWER([CountryName]) LIKE 'a%a%a%' OR LOWER([CountryName]) LIKE '%a%a%a%'
ORDER BY [IsoCode]