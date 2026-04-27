using TicketTracker.Entity;

namespace TicketTracker.Models;

public class Ticket : NamedEntity
{
    #region properties

    public int TicketNumber { get; set; }

    #region navigationProperties

    public Status Status { get; private set; }
    public List<Note> Notes { get; private set; }

    #endregion navigationProperties

    #endregion properties

    #region ctor
    public Ticket(Guid id, int ticketNumber, string title, string? description, Status status) : base(id, title, description)
    {
        TicketNumber = ticketNumber;
        Status = status;

        Notes = new();
    }
    #endregion ctor

    #region methods

    public void AddNote(Note note)
    {
        Notes.Add(note);
    }

    public void RemoveNode(Note note)
    {
        Notes.Remove(note);
    }

    #endregion methods
}

