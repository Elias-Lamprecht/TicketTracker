using Microsoft.Data.SqlClient;
using System.Windows.Documents;
using TicketTracker.Models;

namespace TicketTracker.Data.Repositories;

public class PriorityRepository
{
    #region properties

    private readonly IDbConnectionFactory _dbFactory;

    #endregion properties

    #region ctor

    public PriorityRepository(IDbConnectionFactory dbFactory)
    {
        _dbFactory = dbFactory;
    }

    #endregion ctor

    #region methods

    public async Task<List<Priority>> GetAllAsync()
    {
        List<Priority> priorities = new();

        using SqlConnection connection = await _dbFactory.CreateOpenConnectionAsync();

        const string sql = "SELECT PriorityId, Title, Description FROM Priority";

        using SqlCommand command = new(sql, connection);
        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync()) 
        {
            Priority priority = new(reader.GetGuid(0), reader.GetString(1), reader.GetString(2));
            priorities.Add(priority);
        }

        return priorities;
    }

    public async void CreatePriorityAsync(Priority priority)
    {
        using SqlConnection connection = await _dbFactory.CreateOpenConnectionAsync();

        const string sql = "INSERT INTO Priority VALUES(@PriorityId, @Title, @Description)";

        using (SqlCommand command = new(sql, connection))
        {
            command.Parameters.Add("PriorityId", System.Data.SqlDbType.UniqueIdentifier).Value = priority.Id;
            command.Parameters.Add("Title", System.Data.SqlDbType.NVarChar, 32).Value = priority.Title;
            command.Parameters.Add("Description", System.Data.SqlDbType.NVarChar, 128).Value = priority.Description;

            command.ExecuteNonQuery();
        }
    }

    #endregion methods
}
