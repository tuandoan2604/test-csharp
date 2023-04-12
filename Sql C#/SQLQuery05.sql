
select n.ProductKey, EnglishProductName, ModelName, ProductCategoryName, EnglishProductSubcategoryName, UnitsBalance, UnitCost
from (select c.ProductKey, EnglishProductName, ModelName, EnglishProductCategoryName as ProductCategoryName,
EnglishProductSubcategoryName from DimProductSubcategory a inner join DimProductCategory b on a.ProductCategoryKey = b.ProductCategoryKey
inner join DimProduct c on c.ProductSubcategoryKey = a.ProductSubcategoryKey) n
inner join (select g.ProductKey, UnitsBalance, f.DateKey, g.UnitCost from (select ProductKey, Max(DateKey) DateKey from FactProductInventory
group by ProductKey ) f
inner join FactProductInventory g
on f.ProductKey = g.ProductKey
where g.DateKey = f.DateKey
) m
on n.ProductKey = m.ProductKey