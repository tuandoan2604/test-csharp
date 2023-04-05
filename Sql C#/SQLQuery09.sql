select top 20 CONCAT(FirstName, ' ', MiddleName, ' ', LastName), a.SalesOrderNumber, a.CustomerKey, TotalOrderCost from FactInternetSales a
inner join DimCustomer b
on a.CustomerKey = b.CustomerKey
inner join
(select SalesOrderNumber, SUM(TotalProductCost) as TotalOrderCost from FactInternetSales a
Group by SalesOrderNumber) c
on a.SalesOrderNumber = c.SalesOrderNumber
order by TotalOrderCost desc