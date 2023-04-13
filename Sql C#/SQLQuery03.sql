select top 100 EnglishProductName as 'ProductName (English)', ModelName, ProductLine, 
EnglishProductSubcategoryName as 'ProductSubcategoryName (English)', DealerPrice, ListPrice, Color, 
EnglishDescription as 'Description (English)' 
from DimProduct a inner join DimProductSubcategory b on a.ProductSubcategoryKey = b.ProductSubcategoryKey
inner join DimProductCategory as c on b.ProductCategoryKey = c.ProductCategoryKey
order by ListPrice DESC
