using TicketTracker.CoreLibrary.Models;

namespace TicketTracker.CoreLibrary.Services;

public class PriorityService
{
    #region properties

    private static PriorityService? _instance { get; set; }
    public List<Priority> Priorities { get; init; }

    #endregion properties

    #region singleton

    public static PriorityService Instance()
    {
        if (_instance == null)
        {
            _instance = new PriorityService();
        }

        return _instance;
    }

    #endregion singleton

    #region ctor

    private PriorityService()
    {
        Priorities = new();
    }

    #endregion ctor

    #region methods

    public Priority CreatePriority(Guid id, string title, string description)
    {
        Priority priority = new(id, title, description);
        Priorities.Add(priority);
        return priority;
    }

    public void DeletePriority(Priority priority)
    {
        Priorities.Remove(priority);
    }

    public void DeleteAllPrioritys()
    {
        Priorities.Clear();
    }

    #endregion methods
}
