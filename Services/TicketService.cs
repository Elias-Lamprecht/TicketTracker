using TicketTracker.Models;

namespace TicketTracker.Services;

public class TicketService
{
    #region properties

    public List<Ticket> Tickets { get; private set; }
    private static TicketService? _instance;

    #endregion properties

    #region singleton

    public static TicketService Instance()
    {
        if (_instance == null)
        {
            _instance = new TicketService();
        }

        return _instance;
     }
    
    #endregion singleton

    #region ctor
    private TicketService()
    {
        Tickets = new();
    }
    #endregion ctor

    #region methods
    public Ticket CreateTicket(Guid id, int ticketNumber, string title, string description, Status status, Priority priority)
    {
        Ticket ticket = new(id, ticketNumber, title, description, status, priority);
        Tickets.Add(ticket);
        return ticket;
    }

    public void DeleteTicket(Ticket ticket)
    {
        Tickets.Remove(ticket);
    }
    #endregion
}