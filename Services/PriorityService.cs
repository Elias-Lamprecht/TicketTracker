using TicketTracker.Models;

namespace TicketTracker.Services;

public class PriorityService
{
    #region properties

    private static PriorityService? _instance { get; set; }
    private List<Priority> _priorities { get; set; }

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
        _priorities = new();
    }

    #endregion ctor

    #region methods

    public Priority CreatePriority(Guid id, string title, string description)
    {
        Priority priority = new(id, title, description);
        _priorities.Add(priority);
        return priority;
    }

    public void DeletePriority(Priority priority)
    {
        _priorities.Remove(priority);
    }

    #endregion methods
}
