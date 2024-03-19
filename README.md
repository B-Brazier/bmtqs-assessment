# BMT Tax Depreciation Quantity Surveyors

- [BMT Tax Depreciation Quantity Surveyors](#bmt-tax-depreciation-quantity-surveyors)
	- [About](#about)
	- [Setup](#setup)

## About

The BMT Tax Depreciation Quantity Surveyors solution is used for an assessment purpose. 
It is a small `C#` Web App that allows the user to Create, Update and View a list of contacts.

Contacts contain a mandatory first name and last name. As well as a company name, mobile number and email address.

## Setup
Before running a few steps need to be taken.
Ensure you have an SQL Server setup.
Find and run the following scripts from `bmtqs-assessment > Scripts`
`Note:` You will need administration priveldges to run create database on a server.
Run in the following order:
1. CreateDatabase.sql
2. CreateContactTable.sql
3. StoredProcedureCreateNewContact.sql
4. StoredProcedureGetAllContacts.sql
5. StoredProcedureUpdateContact.sql
6. StoredProcedureSoftDeletedContact.sql 

Once all scripts are run, ensure you have the connection string to the database and replace it with the current string in appsettings.json.
`bmtqs-assessment > appsettings.json` - `Database: ConnectionString`
It should look something like this: `"Server=localhost\\SQLEXPRESS;Database=BMT_ASSESSMENT;Trusted_Connection=True;"`

Once all is saved open the solution file in Visual Studio.