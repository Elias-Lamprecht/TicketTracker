using TicketTracker.Entity;

namespace TicketTracker.Models;

public class Status : NamedEntity
{
    public Status(Guid id, string title, string description) : base(id, title, description)
    {
    }
}
