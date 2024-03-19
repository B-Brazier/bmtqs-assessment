using System.Data.SqlClient;

namespace bmtqs_assessment.Services.Interfaces;

public interface IDBConnectionService
{
    SqlConnection GetDatabaseConnection();
}
