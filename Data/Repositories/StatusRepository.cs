using Microsoft.Data.SqlClient;
using TicketTracker.Models;

namespace TicketTracker.Data.Repositories;

public class StatusRepository
{
    #region properties
    private readonly IDbConnectionFactory _dbFactory;
    #endregion properties

    #region ctor
    public StatusRepository(IDbConnectionFactory dbFactory)
    {
        _dbFactory = dbFactory;
    }
    #endregion ctor

    #region methods

    public async void GetAllAsync()
    {
        List<Status> statuses = new();

        using SqlConnection connection = await _dbFactory.CreateOpenConnectionAsync();

        const string sql = "SELECT StatusId, Title, Description FROM Status";

        using SqlCommand command = new(sql, connection);
        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            Console.WriteLine($"{reader.GetGuid(0)} {reader.GetString(1)} {(reader.IsDBNull(2) ? (string?)null : reader.GetString(2))}");
        }
    }

    #endregion methods
}
