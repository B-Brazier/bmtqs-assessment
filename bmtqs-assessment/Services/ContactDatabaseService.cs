using bmtqs_assessment.Models;
using bmtqs_assessment.Services.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace bmtqs_assessment.Services;

public class ContactDatabaseService : IContactDatabaseService
{
    private readonly ILogger _logger;
    private readonly IDBConnectionService _connectionService;

    public ContactDatabaseService (
        ILogger<ContactDatabaseService> logger,
        IDBConnectionService connectionService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _connectionService = connectionService ?? throw new ArgumentNullException(nameof(connectionService));
    }

    // Used to get a list of all contacts (not soft deleted)
    public async Task<List<ContactModel>> GetContactsAsync(CancellationToken cancellationToken)
    {
        // Create Database connection
        using SqlConnection sqlConnection = _connectionService.GetDatabaseConnection();

        // Create command 
        using var command = new SqlCommand("GetAllContacts", sqlConnection)
        {
            CommandType = CommandType.StoredProcedure
        };

        // Prepare Command
        await command.PrepareAsync(cancellationToken);

        // Create a blank list to populate
        List<ContactModel> contacts = new();

        // Open Reader and Database Connection
        await sqlConnection.OpenAsync(cancellationToken);
        using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);

        // Read all results
        while (await reader.ReadAsync(cancellationToken))
        {
            // Read this result
            ContactModel contact = new()
            {
                ContactID = (int)reader["ContactID"],
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                CompanyName = reader["CompanyName"].ToString(),
                MobileNumber = reader["MobileNumber"].ToString(),
                EmailAddress = reader["EmailAddress"].ToString(),
                CreatedDateTime = (DateTime)reader["CreatedDateTime"],
                LastUpdatedDateTime = (DateTime)reader["LastUpdatedDateTime"]
            };

            // Add this result to the list
            contacts.Add(contact);
        }

        // Return all results
        return contacts;
    }

    public async Task CreateNewContactAsync(ContactModel contact, CancellationToken cancellationToken)
    {
        // Create Database connection
        using SqlConnection sqlConnection = _connectionService.GetDatabaseConnection();

        // Create command 
        using var command = new SqlCommand("CreateNewContact", sqlConnection)
        {
            CommandType = CommandType.StoredProcedure
        };

        // Create and add parameters
        SqlParameter firstNameParameter = command.Parameters.AddWithValue("@FirstName", contact.FirstName);
        firstNameParameter.SqlDbType = SqlDbType.NVarChar;
        SqlParameter lastNameParameter = command.Parameters.AddWithValue("@LastName", contact.LastName);
        lastNameParameter.SqlDbType = SqlDbType.NVarChar;
        SqlParameter companyNameParameter = command.Parameters.AddWithValue("@CompanyName", contact.CompanyName);
        companyNameParameter.SqlDbType = SqlDbType.NVarChar;
        SqlParameter mobileNumberParameter = command.Parameters.AddWithValue("@MobileNumber", contact.MobileNumber);
        mobileNumberParameter.SqlDbType = SqlDbType.NVarChar;
        SqlParameter emailAddressParameter = command.Parameters.AddWithValue("@EmailAddress", contact.EmailAddress);
        emailAddressParameter.SqlDbType = SqlDbType.NVarChar;

        // Prepare Command
        await command.PrepareAsync(cancellationToken);

        // Open connection and execute query
        await sqlConnection.OpenAsync(cancellationToken);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    public async Task SoftDeleteContactAsync(ContactModel contact, CancellationToken cancellationToken)
    {
        // Create Database connection
        using SqlConnection sqlConnection = _connectionService.GetDatabaseConnection();

        // Create command 
        using var command = new SqlCommand("SoftDeleteContact", sqlConnection)
        {
            CommandType = CommandType.StoredProcedure
        };

        // Create and add parameters
        SqlParameter contactIDParameter = command.Parameters.AddWithValue("@ContactID", contact.ContactID);
        contactIDParameter.SqlDbType = SqlDbType.Int;

        // Prepare Command
        await command.PrepareAsync(cancellationToken);

        // Open connection and execute query
        await sqlConnection.OpenAsync(cancellationToken);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    public async Task UpdateContactAsync(ContactModel contact, CancellationToken cancellationToken)
    {
        // Create Database connection
        using SqlConnection sqlConnection = _connectionService.GetDatabaseConnection();

        // Create command 
        using var command = new SqlCommand("UpdateContact", sqlConnection)
        {
            CommandType = CommandType.StoredProcedure
        };

        // Create and add parameters
        SqlParameter contactIDParameter = command.Parameters.AddWithValue("@ContactID", contact.ContactID);
        contactIDParameter.SqlDbType = SqlDbType.Int;
        SqlParameter firstNameParameter = command.Parameters.AddWithValue("@FirstName", contact.FirstName);
        firstNameParameter.SqlDbType = SqlDbType.NVarChar;
        SqlParameter lastNameParameter = command.Parameters.AddWithValue("@LastName", contact.LastName);
        lastNameParameter.SqlDbType = SqlDbType.NVarChar;
        SqlParameter companyNameParameter = command.Parameters.AddWithValue("@CompanyName", contact.CompanyName);
        companyNameParameter.SqlDbType = SqlDbType.NVarChar;
        SqlParameter mobileNumberParameter = command.Parameters.AddWithValue("@MobileNumber", contact.MobileNumber);
        mobileNumberParameter.SqlDbType = SqlDbType.NVarChar;
        SqlParameter emailAddressParameter = command.Parameters.AddWithValue("@EmailAddress", contact.EmailAddress);
        emailAddressParameter.SqlDbType = SqlDbType.NVarChar;

        // Prepare Command
        await command.PrepareAsync(cancellationToken);

        // Open connection and execute query
        await sqlConnection.OpenAsync(cancellationToken);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }
}
