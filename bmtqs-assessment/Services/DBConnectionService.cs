using System.Data.SqlClient;
using bmtqs_assessment.Models;
using bmtqs_assessment.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace bmtqs_assessment.Services;

public class DBConnectionService : IDBConnectionService
{

    private readonly ILogger _logger;
    private readonly DatabaseConnectionModel _connectionModel;

    public DBConnectionService(
        ILogger<DBConnectionService> logger,
        IOptions<DatabaseConnectionModel> connectionModel)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _connectionModel = connectionModel.Value ?? throw new ArgumentNullException(nameof(connectionModel));
    }

    // Create a database connection
    public SqlConnection GetDatabaseConnection()
    {
        var connectionString = _connectionModel.ConnectionString;
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString), "No value for database conneciton string");
        }

        return new SqlConnection(connectionString);
    }
}
