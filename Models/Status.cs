using Ticket_Tracker.Entity;

namespace Ticket_Tracker.Models;

public class Status : NamedEntity
{
    public Status(Guid id, string title, string description) : base(id, title, description)
    {
    }
}
