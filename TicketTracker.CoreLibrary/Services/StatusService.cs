using TicketTracker.CoreLibrary.Models;

namespace TicketTracker.CoreLibrary.Services;

public class StatusService
{
    #region ctor

    public StatusService()
    {
        Statuses = new List<Status>();
    }

    #endregion ctor

    #region singleton

    public static StatusService Instance()
    {
        if (_instance == null) _instance = new StatusService();

        return _instance;
    }

    #endregion singleton

    #region properties

    private static StatusService? _instance { get; set; }
    public List<Status> Statuses { get; init; }

    #endregion properties

    #region methods

    public Status CreateStatus(Guid id, string title, string description)
    {
        Status status = new(id, title, description);
        Statuses.Add(status);
        return status;
    }

    public void DeleteStatus(Status status)
    {
        Statuses.Remove(status);
    }

    public void DeleteAllStatuses()
    {
        Statuses.Clear();
    }

    #endregion methods
}