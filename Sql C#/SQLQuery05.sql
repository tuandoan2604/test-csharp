
select d.ProductKey, EnglishProductName as 'ProductName (English)', ModelName,ProductCategoryName,
EnglishProductSubcategoryName as 'ProductSubcategoryName', UnitsBalance, UnitCost
from
(select c.ProductKey, EnglishProductName, ModelName, EnglishProductCategoryName as ProductCategoryName,
EnglishProductSubcategoryName from DimProductSubcategory a inner join DimProductCategory b on a.ProductCategoryKey = b.ProductCategoryKey
inner join DimProduct c on c.ProductSubcategoryKey = a.ProductSubcategoryKey) d inner join FactProductInventory e
on d.ProductKey = e.ProductKey