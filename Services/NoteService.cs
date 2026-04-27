using TicketTracker.Models;

namespace TicketTracker.Services;

public class NoteService
{
    #region properties

    private static NoteService? _instance { get; set; }
    private List<Note> _notes { get; set; }

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
        _notes = new();
    }

    #endregion ctor

    #region methods

    public Note CreateNote(Guid id, string text)
    {
        Note note = new(id, text);
        _notes.Add(note);
        return note;
    }

    public void DeleteNote(Note note) 
    { 
        _notes.Remove(note);
    }

    #endregion methods
}

