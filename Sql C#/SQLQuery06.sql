select top 10 EnglishProductName as 'ProductName', ModelName,ProductCategoryName,
EnglishProductSubcategoryName as 'ProductSubcategoryName', UnitsBalance, UnitCost
from
(select c.ProductKey, EnglishProductName, ModelName, EnglishProductCategoryName as ProductCategoryName,
EnglishProductSubcategoryName from DimProductSubcategory a inner join DimProductCategory b on a.ProductCategoryKey = b.ProductCategoryKey
inner join DimProduct c on c.ProductSubcategoryKey = a.ProductSubcategoryKey) d inner join (select c.ProductKey, SUM(e.UnitCost*e.UnitsBalance) as UnitCost, e.UnitsBalance from DimProduct c
inner join FactProductInventory e
on c.ProductKey = e.ProductKey
group by c.ProductKey, e.UnitsBalance
) m
on d.ProductKey = m.ProductKey
Order by UnitCost desc


select * from FactProductInventory