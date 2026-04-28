using TicketTracker.CoreLibrary.Entity;

namespace TicketTracker.CoreLibrary.Models;

public class Status : NamedEntity
{
    #region ctor
    public Status(Guid id, string title, string description) : base(id, title, description)
    {
    }
    #endregion ctor
}
