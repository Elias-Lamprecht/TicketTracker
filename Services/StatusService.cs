using TicketTracker.Models;

namespace TicketTracker.Services;

public class StatusService
{
    #region properties

    private static StatusService? _instance { get; set; }
    private List<Status> _statuses { get; set; }

    #endregion properties

    #region singleton

    public static StatusService Instance()
    {
        if (_instance == null)
        {
            _instance = new StatusService();
        }

        return _instance;
    }

    #endregion singleton

    #region ctor

    public StatusService()
    {
        _statuses = new();
    }

    #endregion ctor

    #region methods

    public Status CreateStatus(Guid id, string title, string description)
    {
        Status status = new(id, title, description);
        _statuses.Add(status);
        return status;
    }

    public void DeleteStatus(Status status)
    {
        _statuses.Remove(status);
    }

    #endregion methods
}