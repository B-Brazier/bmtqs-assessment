CREATE PROCEDURE UpdateContact (
	@ContactID INT,
	@FirstName NVARCHAR(125),
	@LastName NVARCHAR(255),
	@CompanyName NVARCHAR(MAX),
	@MobileNumber NVARCHAR(20),
	@EmailAddress NVARCHAR(MAX)
) 
AS
	UPDATE Contact
	SET FirstName = @FirstName, 
		LastName = @LastName,
		CompanyName = @CompanyName,
		MobileNumber = @MobileNumber,
		EmailAddress = @EmailAddress,
		LastUpdatedDateTime = GETDATE()
	WHERE ContactID = @ContactID