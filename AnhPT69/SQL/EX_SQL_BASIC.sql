USE Microsoft

--Dimensions ex1
Select
CONCAT(dc.FirstName, ' ', dc.MiddleName, ' ', dc.LastName) AS FULLNAME,
dc.BirthDate,
IIF(dc.Gender = 'M', 'Male', 'Female') as Gender,
dc.EmailAddress,
dc.EnglishEducation as Education,
dc.Phone,
dc.AddressLine1,
dc.AddressLine2
FROM DimCustomer as dc
join DimGeography as dg on dc.GeographyKey = dg.GeographyKey
where dg.CountryRegionCode = 'GB'

--Dimensions ex2
select dg.EnglishCountryRegionName, count(dc.CustomerKey) from DimCustomer as dc
join DimGeography as dg on dc.GeographyKey = dg.GeographyKey
group by dg.EnglishCountryRegionName

--Dimensions ex3
select top 100
EnglishProductName as ProductName,
ModelName,
ProductLine,
EnglishProductCategoryName as ProductCategoryName,
EnglishProductSubcategoryName as ProductSubcategoryName,
DealerPrice,
ListPrice,
Color,
EnglishDescription as 'Description'
from DimProductCategory as dpc
join DimProductSubcategory as dpsc on dpc.ProductCategoryKey = dpsc.ProductCategoryKey
join DimProduct as dp on dp.ProductSubcategoryKey = dpsc.ProductSubcategoryKey
order by ListPrice desc;

--Finance ex4
select AccountDescription, France, Germany, Australia from
(select AccountDescription, OrganizationName, Amount from FactFinance as ff
join DimOrganization as do on ff.OrganizationKey = do.OrganizationKey
join DimAccount as da on ff.AccountKey = da.AccountKey) as SoureTable
pivot
(
sum(Amount)
for OrganizationName in (France, Germany, Australia)
) as PiVotTable

--Inventory ex5
select
dp.ProductKey, 
EnglishProductName as ProductName, 
ModelName, 
EnglishProductCategoryName as ProductCategoryName, 
EnglishProductSubcategoryName as ProductSubcategoryName,
UnitsBalance,
UnitCost 
from DimProductCategory as dpc
join DimProductSubcategory as dps on dpc.ProductCategoryKey = dps.ProductCategoryKey
join DimProduct as dp on dp.ProductSubcategoryKey = dps.ProductSubcategoryKey
join FactProductInventory as fpi on fpi.ProductKey = dp.ProductKey
where DateKey = (
	select max(DateKey) from FactProductInventory
)

--Inventory ex6
select top 10
	ProductName, 
	ModelName,
	EnglishProductCategoryName as ProductCategoryName,
	EnglishProductSubcategoryName as ProductSubcategoryName,
	UnitsBalance,
	UnitCost,
	InventoryValue as 'InventoryValue = UnitsBalance * UnitCost'
from (
	select
		EnglishProductName as ProductName, 
		ModelName,
		UnitsBalance,
		UnitCost,
		ProductSubcategoryKey,
		(UnitCost * UnitsBalance) as InventoryValue
	from DimProduct as dp 
	join FactProductInventory as fpi on fpi.ProductKey = dp.ProductKey
	where DateKey = 
		(
			select max(DateKey) from FactProductInventory 
		)
	) as sub 
join DimProductSubcategory as dps on sub.ProductSubcategoryKey = dps.ProductSubcategoryKey
join DimProductCategory as dpc on dpc.ProductCategoryKey = dps.ProductCategoryKey
order by InventoryValue desc


select top 10
	EnglishProductName as ProductName, 
	ModelName,
	EnglishProductCategoryName as ProductCategoryName,
	EnglishProductSubcategoryName as ProductSubcategoryName,
	UnitsBalance,
	UnitCost,
	InventoryValue as 'InventoryValue = UnitsBalance * UnitCost',
	MAX(DateKey) as DateKey
from FactProductInventory as fpi_1
join 
	(
	select 
		ProductKey, 
		max(UnitCost*UnitsBalance) AS InventoryValue 
	from FactProductInventory 
	group by ProductKey) as fpi_2 
on fpi_1.ProductKey = fpi_2.ProductKey and fpi_1.UnitCost*fpi_1.UnitsBalance = fpi_2.InventoryValue
join DimProduct as dp on dp.ProductKey = fpi_1.ProductKey
left join DimProductSubcategory as dps on dps.ProductSubcategoryKey = dp.ProductSubcategoryKey
left join DimProductCategory as dpc on dpc.ProductCategoryKey = dps.ProductCategoryKey
group by EnglishProductName, ModelName, EnglishProductCategoryName, EnglishProductSubcategoryName, fpi_1.UnitCost, fpi_1.UnitsBalance, InventoryValue
order by InventoryValue desc

--Internet Sales ex8
select
SalesOrderNumber,
SalesOrderLineNumber,
CONCAT(dc.FirstName, ' ', dc.MiddleName, ' ', dc.LastName) AS FullName,
dp.EnglishProductName as ProductName,
OrderQuantity,
UnitPrice,
DiscountAmount, 
SalesAmount, 
ProductStandardCost, 
TotalProductCost
from FactInternetSales as fis
join DimCustomer as dc on fis.CustomerKey = dc.CustomerKey
join DimProduct as dp on fis.ProductKey = dp.ProductKey
where dp.EnglishProductName = 'Road-150 Red, 48'


select
EnglishProductName as ProductName, 
ModelName, 
EnglishProductCategoryName as ProductCategoryName, 
EnglishProductSubcategoryName as ProductSubcategoryName,
UnitsBalance,
UnitCost 
from DimProductCategory as dpc
join DimProductSubcategory as dps on dpc.ProductCategoryKey = dps.ProductCategoryKey
join DimProduct as dp on dp.ProductSubcategoryKey = dps.ProductSubcategoryKey
join FactProductInventory as fpi on fpi.ProductKey = dp.ProductKey
where DateKey = (
	select max(DateKey) from FactProductInventory
)
order by UnitCost desc
--Internet Sales ex9
select
FullName,
SalesOrderNumber,
CustomerKey,
sum(TotalProductCost) as TotalOrderCost
from
(select
SalesOrderNumber,
SalesOrderLineNumber,
TotalProductCost,
CONCAT(dc.FirstName, ' ', dc.MiddleName, ' ', dc.LastName) AS FullName,
dc.CustomerKey as CustomerKey,
ProductKey
from DimCustomer as dc
join FactInternetSales as fis on fis.CustomerKey = dc.CustomerKey) as SubTable
join DimProduct as dp on dp.ProductKey = SubTable.ProductKey
group by SalesOrderNumber, FullName, CustomerKey
order by SalesOrderNumber desc

--Reseller Sales ex10
select ResellerName, 
frs.ResellerKey,
sum(OrderQuantity) as TotalQuantity,
sum(TotalProductCost) as TotalOrderCost
from FactResellerSales as frs
join DimReseller as dr on frs.ResellerKey = dr.ResellerKey
group by ResellerName, frs.ResellerKey
order by TotalOrderCost desc
