  SELECT [FullName],
		 [Country],
		 [ZIP],
		 [CigarPrice]
  FROM( 
    SELECT
			DENSE_RANK() OVER (PARTITION BY (c.[Id]) ORDER BY ci.[PriceForSingleCigar] DESC) AS [RankByPrice],
			CONCAT(c.[FirstName],' ',c.[LastName]) AS [FullName],
			a.[Country] AS [Country],
			a.[ZIP] AS [ZIP],
			ci.[PriceForSingleCigar] AS [CigarPrice]
			FROM [Clients] AS c
			JOIN [Addresses] AS a ON c.[AddressId] = a.[Id]
			LEFT JOIN [ClientsCigars] AS cc ON c.[Id] = cc.[ClientId]
			LEFT JOIN [Cigars] AS ci ON cc.[CigarId] = ci.[Id]
			WHERE a.[ZIP] NOT LIKE '%[A-Z,a-z]%') AS [RankingSubquery]

WHERE [RankByPrice] = 1
ORDER BY [FullName]