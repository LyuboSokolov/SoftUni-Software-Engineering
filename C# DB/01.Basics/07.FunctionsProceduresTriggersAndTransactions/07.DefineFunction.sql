CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @isComprise BIT
	SET @isComprise = 1
	DECLARE @currentLetter NVARCHAR(1)

	 WHILE (LEN(@word)>=1)
	 BEGIN
			SET @currentLetter = LEFT(@word,1)
			SET @word = SUBSTRING(@word,2,LEN(@word)-1)
			  IF(CHARINDEX(@currentLetter,@setOfLetters) = 0)
				 BEGIN
					SET @isComprise = 0
				 END
	  END
	  	 RETURN @isComprise
END