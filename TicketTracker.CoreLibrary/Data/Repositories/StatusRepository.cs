using Microsoft.Data.SqlClient;
using TicketTracker.CoreLibrary.Models;

namespace TicketTracker.CoreLibrary.Data.Repositories;

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

    public async Task<List<Status>> GetAllAsync()
    {
        List<Status> statuses = new();

        using SqlConnection connection = await _dbFactory.CreateOpenConnectionAsync();

        const string sql = "SELECT StatusId, Title, Description FROM Status";

        using SqlCommand command = new(sql, connection);
        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            Status status = new(reader.GetGuid(0), reader.GetString(1), reader.GetString(2));
            statuses.Add(status);
        }

        return statuses;
    }

    public async void CreateStatusAsync(Status status)
    {
        using SqlConnection connection = await _dbFactory.CreateOpenConnectionAsync();

        const string sql = "INSERT INTO Status VALUES(@StatusId, @Title, @Description)";

        using (SqlCommand command = new(sql, connection))
        {
            command.Parameters.Add("StatusId", System.Data.SqlDbType.UniqueIdentifier).Value = status.Id;
            command.Parameters.Add("Title", System.Data.SqlDbType.NVarChar, 32).Value = status.Title;
            command.Parameters.Add("Description", System.Data.SqlDbType.NVarChar, 128).Value = status.Description;

            command.ExecuteNonQuery();
        }
    }

    public async void DeleteStatusAsync(Status status)
    {
        using SqlConnection connection = await _dbFactory.CreateOpenConnectionAsync();

        const string sql = "Delete Status WHERE StatusId = @StatusId";

        using (SqlCommand command = new(sql, connection))
        {
            command.Parameters.Add("StatusId", System.Data.SqlDbType.UniqueIdentifier).Value = status.Id;
            command.ExecuteNonQuery();
        }
    }

    #endregion methods
}
