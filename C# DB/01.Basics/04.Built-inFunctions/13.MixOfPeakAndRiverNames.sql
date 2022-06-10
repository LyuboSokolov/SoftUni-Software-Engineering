SELECT p.[PeakName],r.[RiverName], LOWER(p.[PeakName]) + LOWER(SUBSTRING(r.[RiverName],2,LEN(r.RiverName)-1)) AS [Mix]
FROM [Peaks] AS p
JOIN [Rivers] AS r ON RIGHT(p.[PeakName],1) = LEFT(r.[RiverName],1)
ORDER BY [Mix]