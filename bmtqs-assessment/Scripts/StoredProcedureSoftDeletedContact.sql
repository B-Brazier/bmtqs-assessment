CREATE PROCEDURE SoftDeleteContact (
	@ContactID INT
)
AS
	UPDATE Contact
	SET IsDeleted = 1, LastUpdatedDateTime = GETDATE()
	WHERE ContactID = @ContactID