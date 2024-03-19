CREATE PROCEDURE GetAllContacts
AS
SELECT 
	ContactID,
	FirstName,
	LastName,
	CompanyName,
	MobileNumber,
	EmailAddress,
	CreatedDateTime,
	LastUpdatedDateTime
FROM Contact
WHERE IsDeleted = 0