using Ticket_Tracker.Entity;

namespace Ticket_Tracker.Models;

class Ticket : NamedEntity
{
    #region properties

    public int TicketNumber { get; set; }

    #region navigationProperties

    public Status Status { get; private set; }

    #endregion navigationProperties

    #endregion properties

    #region ctor
    public Ticket(Guid id, int ticketNumber, string title, string? description, Status status) : base(id, title, description)
    {
        TicketNumber = ticketNumber;
        Status = status;
    }
    #endregion ctor
}

