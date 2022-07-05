CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN 

 RETURN(SELECT COUNT(*)
FROM [Clients] AS c
JOIN [ClientsCigars] AS cc ON c.[Id] = cc.[ClientId]
WHERE c.[FirstName] = @name)

END