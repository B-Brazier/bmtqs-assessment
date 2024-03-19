CREATE PROCEDURE CreateNewContact (
	@FirstName NVARCHAR(125),
	@LastName NVARCHAR(255),
	@CompanyName NVARCHAR(MAX),
	@MobileNumber NVARCHAR(20),
	@EmailAddress NVARCHAR(MAX)
)
	AS	
INSERT INTO Contact 
	(FirstName, LastName, CompanyName, MobileNumber, EmailAddress, CreatedDateTime, LastUpdatedDateTime, IsDeleted)
VALUES 
	(@FirstName, @LastName, @CompanyName, @MobileNumber, @EmailAddress, GETDATE(), GETDATE(), 0)
