using Ticket_Tracker.Models;

namespace Ticket_Tracker.Services;

class TicketService
{
    #region properties
    private TicketService? _instance {  get; set; }
    private List<Ticket> _tickets { get; set; }
    #endregion properties

    #region singleton
    public TicketService Instance()
    {
        if (_instance == null)
        {
            _instance = new TicketService();
        }

        return _instance;
    }
    #endregion singleton

    #region ctor
    public TicketService()
    {
        _tickets = new();
    }
    #endregion ctor

    #region methods

    public Ticket CreateTicket(Guid id, int ticketNumber, string Title, string Description, Status status)
    {
        Ticket ticket = new Ticket(id, ticketNumber, Title, Description, status);
        _tickets.Add(ticket);
        return ticket;
    }

    public void DeleteTicket(Ticket ticket)
    {
        _tickets.Remove(ticket);
    }

    #endregion methods
}

