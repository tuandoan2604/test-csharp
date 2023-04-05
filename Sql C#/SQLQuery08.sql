select SalesOrderNumber, SalesOrderLineNumber, CONCAT(b.FirstName, ' ', b.MiddleName, ' ', b.LastName) CustomerName,
c.EnglishProductName ProductName, OrderQuantity, UnitPrice, DiscountAmount, SalesAmount, ProductStandardCost, TotalProductCost
from FactInternetSales a inner join DimCustomer b
on a.CustomerKey = b.CustomerKey inner join DimProduct c on a.ProductKey = c.ProductKey