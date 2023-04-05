SELECT AccountDescription, [France], [Germany], [Australia]
FROM  
    (select AccountDescription, Amount, OrganizationName from FactFinance a inner join DimAccount b on a.AccountKey = b.AccountKey
		inner join DimOrganization c on a.OrganizationKey = c.OrganizationKey
	)   AS t 
PIVOT  
(  
    SUM(Amount)
FOR   
    OrganizationName
    IN ([France], [Germany], [Australia])  
) AS BangChuyen  