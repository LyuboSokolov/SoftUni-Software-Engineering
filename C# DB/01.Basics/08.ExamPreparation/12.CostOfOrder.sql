CREATE FUNCTION dbo.udf_GetCost (@jobId INT)
RETURNS DECIMAL(8,2)
AS
BEGIN
   DECLARE @countId INT
   SET @countId = 0
   SET @countId = ( SELECT COUNT(OrderId)
					FROM [Jobs] AS j
					LEFT JOIN [Orders] AS o ON j.[JobId] = o.[JobId]
					WHERE j.[JobId] = @jobId )

 	IF (@countId = 0)
			BEGIN
			 RETURN 0.00
			END
		
		RETURN (SELECT SUM (p.Price*op.Quantity) 
		FROM [Jobs] AS j
		JOIN [Orders] AS o ON j.JobId = o.JobId
		JOIN [OrderParts] AS op ON o.OrderId = op.OrderId
		JOIN [Parts] AS p ON op.PartId = p.PartId
		WHERE j.[JobId] = @jobId
		GROUP BY j.[JobId])

END