select top 10 EnglishProductName as 'ProductName', ModelName,ProductCategoryName,
EnglishProductSubcategoryName as 'ProductSubcategoryName', UnitsBalance, SUM(UnitCost) as UnitCost
from
(select c.ProductKey, EnglishProductName, ModelName, EnglishProductCategoryName as ProductCategoryName,
EnglishProductSubcategoryName from DimProductSubcategory a inner join DimProductCategory b on a.ProductCategoryKey = b.ProductCategoryKey
inner join DimProduct c on c.ProductSubcategoryKey = a.ProductSubcategoryKey) d inner join FactProductInventory e
on d.ProductKey = e.ProductKey
Group by d.EnglishProductName, d.ModelName, d.ProductCategoryName, d.EnglishProductSubcategoryName, e.UnitsBalance
Order by UnitCost desc
