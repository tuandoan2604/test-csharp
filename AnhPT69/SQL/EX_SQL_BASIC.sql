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
	fpi_1.ProductKey,
	EnglishProductName as ProductName, 
	ModelName, 
	EnglishProductCategoryName as ProductCategoryName, 
	EnglishProductSubcategoryName as ProductSubcategoryName,
	UnitsBalance, 
	UnitCost  from FactProductInventory as fpi_1
join (
	select 
		ProductKey, 
		MAX(MovementDate) as LatestDate 
	from FactProductInventory
	group by ProductKey) as fpi_2 
on fpi_1.ProductKey = fpi_2.ProductKey and fpi_1.MovementDate = fpi_2.LatestDate
join DimProduct as dp on fpi_1.ProductKey = dp.ProductKey
left join DimProductSubcategory as dps on dp.ProductSubcategoryKey = dps.ProductSubcategoryKey
left join DimProductCategory as dpc on dpc.ProductCategoryKey = dps.ProductCategoryKey


--Inventory ex6
select top 10
	fpi_1.ProductKey,
	EnglishProductName as ProductName, 
	ModelName,
	EnglishProductCategoryName as ProductCategoryName,
	EnglishProductSubcategoryName as ProductSubcategoryName,
	UnitsBalance,
	UnitCost,
	InventoryValue
from FactProductInventory as fpi_1
join (
	select 
		ProductKey, 
		SUM(UnitCost * UnitsBalance) as InventoryValue,
		MAX(MovementDate) as LatestDate
	from FactProductInventory
	where UnitsBalance > 0
	group by ProductKey) as fpi_2 
on fpi_1.ProductKey = fpi_2.ProductKey and fpi_1.MovementDate = fpi_2.LatestDate
join DimProduct as dp on fpi_1.ProductKey = dp.ProductKey
left join DimProductSubcategory as dps on dp.ProductSubcategoryKey = dps.ProductSubcategoryKey
left join DimProductCategory as dpc on dpc.ProductCategoryKey = dps.ProductCategoryKey
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

--Internet Sales ex9
select top 20
	CONCAT(dc.FirstName, ' ', dc.MiddleName, ' ', dc.LastName) AS FullName,
	SalesOrderNumber,
	dc.CustomerKey,
	TotalOrderCost
from
	(select
		SalesOrderNumber,
		CustomerKey,
		Sum(TotalProductCost) as TotalOrderCost
	from FactInternetSales
	group by SalesOrderNumber, CustomerKey) as fis
join DimCustomer as dc on fis.CustomerKey = dc.CustomerKey
order by TotalOrderCost desc

--Reseller Sales ex10
select top 10
	ResellerName,
	dr.ResellerKey,
	TotalQuantity,
	TotalOrderCost
from
	(select 
		ResellerKey,
		sum(OrderQuantity) as TotalQuantity,
		sum(TotalProductCost) as TotalOrderCost
	from FactResellerSales
	group by  ResellerKey) as frs
join DimReseller as dr on dr.ResellerKey = frs.ResellerKey
order by TotalOrderCost desc
