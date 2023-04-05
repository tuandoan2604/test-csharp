select ResellerName, b.ResellerKey, SUM(OrderQuantity) as TotalQuantity, SUM(TotalProductCost) as TotalOrderCost from
DimReseller a inner join FactResellerSales b
on a.ResellerKey = b.ResellerKey
group by ResellerName, b.ResellerKey
