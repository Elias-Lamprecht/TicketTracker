using TicketTracker.Models;

namespace TicketTracker.Services;

public class NoteService
{
    #region properties

    private static NoteService? _instance { get; set; }
    public List<Note> Notes { get; init; }

    #endregion properties

    #region singleton

    public static NoteService Instance()
    {
        if (_instance == null)
        {
            _instance = new NoteService();
        }

        return _instance;
    }

    #endregion singleton

    #region ctor

    public NoteService()
    {
        Notes = new();
    }

    #endregion ctor

    #region methods

    public Note CreateNote(Guid id, string text)
    {
        Note note = new(id, text);
        Notes.Add(note);
        return note;
    }

    public void DeleteNote(Note note) 
    { 
        Notes.Remove(note);
    }
    }

    #endregion methods
}

