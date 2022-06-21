CREATE PROC dbo.usp_GetTownsStartingWith(@letter NVARCHAR(30))
AS
SELECT [Name] AS [Town]
FROM [Towns]
WHERE LEFT([Name],LEN(@letter)) = @letter