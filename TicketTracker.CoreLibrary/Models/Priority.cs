using TicketTracker.CoreLibrary.Entity;

namespace TicketTracker.CoreLibrary.Models;

public class Priority : NamedEntity
{
    #region ctor
    public Priority(Guid id, string title, string description) : base(id, title, description)
    {
    }
    #endregion ctor
}