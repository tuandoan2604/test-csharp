select EnglishCountryRegionName as CountryName, Count(LastName) as TotalCustomer from DimCustomer a, DimGeography b
where a.GeographyKey = b.GeographyKey
Group by EnglishCountryRegionName