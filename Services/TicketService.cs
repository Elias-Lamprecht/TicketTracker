using System.Collections.ObjectModel;
using TicketTracker.Models;

namespace TicketTracker.Services
{
    // Remove 'static' so the class can be instantiated as a Singleton
    public class TicketService
    {
        #region singleton logic
        private static TicketService? _instance;

        public static TicketService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TicketService();
                }
                return _instance;
            }
        }
        #endregion

        #region properties
        // Since this is already an ObservableCollection, 
        // any Add/Remove here will automatically update the DataGrid!
        public ObservableCollection<Ticket> Tickets { get; private set; }
        #endregion

        // Private constructor prevents other classes from using 'new TicketService()'
        private TicketService()
        {
            Tickets = new ObservableCollection<Ticket>();

            // Seed data
            CreateTicket(Guid.NewGuid(), 1, "Fix Login", "User cannot log in", new Status(Guid.NewGuid(), "Open", "Red"));
            CreateTicket(Guid.NewGuid(), 2, "DB Update", "Migration needed", new Status(Guid.NewGuid(), "In Progress", "Blue"));
        }

        #region methods
        public Ticket CreateTicket(Guid id, int ticketNumber, string title, string description, Status status)
        {
            Ticket ticket = new Ticket(id, ticketNumber, title, description, status);
            Tickets.Add(ticket);
            return ticket;
        }

        public void DeleteTicket(Ticket ticket)
        {
            Tickets.Remove(ticket);
        }
        #endregion
    }
}