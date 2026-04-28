using Microsoft.Data.SqlClient;

namespace TicketTracker.Data;

#region interface

public interface IDbConnectionFactory
{
    Task<SqlConnection> CreateOpenConnectionAsync();
}

#endregion interface

public class SqlConnectionFactory : IDbConnectionFactory
{
    #region properties
    
    private readonly string _connectionString;
    
    #endregion properties

    #region ctor

    public SqlConnectionFactory(string connectionString = Constants.ConnectionString) => _connectionString = connectionString;
    
    #endregion ctor

    #region methods

    public async Task<SqlConnection> CreateOpenConnectionAsync()
    {
        SqlConnection sqlConnection = new(_connectionString);
        await sqlConnection.OpenAsync();
        return sqlConnection;
    }

    #endregion methods
}
