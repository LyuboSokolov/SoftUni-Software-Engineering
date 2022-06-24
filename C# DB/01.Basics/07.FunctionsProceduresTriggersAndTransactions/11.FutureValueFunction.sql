CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(15,4),@yearlyInterestRate FLOAT,@numberOfYear INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
		DECLARE @result DECIMAL(18,4)

		SET @result= @sum*(POWER(1.000+@yearlyInterestRate,@numberOfYear))
		RETURN @result
END