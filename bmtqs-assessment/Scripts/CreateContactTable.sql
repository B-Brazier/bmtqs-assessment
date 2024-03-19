USE BMT_ASSESSMENT;

CREATE TABLE Contact (
	ContactID INT IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(125) NOT NULL,
	LastName NVARCHAR(255) NOT NULL,
	CompanyName NVARCHAR(MAX) NULL,
	MobileNumber NVARCHAR(20) NULL,
	EmailAddress NVARCHAR(MAX) NULL,
	CreatedDateTime DATETIME NOT NULL,
	LastUpdatedDateTime DATETIME NOT NULL,
	IsDeleted BIT DEFAULT 0 NOT NULL,
	CONSTRAINT PK_ContactID PRIMARY KEY (ContactID)
);