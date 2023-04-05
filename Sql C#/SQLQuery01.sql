select CONCAT(FirstName, ' ', MiddleName, ' ', LastName) as FullName,
BirthDate, IIF(Gender = 'F', 'Female', 'Male') as Gender, EmailAddress, EnglishEducation as 'Education (English)', Phone, AddressLine1,
AddressLine2
from DimCustomer
