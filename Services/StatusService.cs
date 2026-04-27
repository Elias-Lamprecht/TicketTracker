using TicketTracker.Models;

namespace TicketTracker.Services;

public class StatusService
{
    #region properties

    private StatusService? _instance { get; set; }
    private List<Status> _statuses { get; set; }

    #endregion properties

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