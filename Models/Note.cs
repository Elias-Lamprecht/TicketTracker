using TicketTracker.Entity;

namespace TicketTracker.Models;

public class Note : BaseEntity
{
    #region properties

    private string _text = string.Empty;
    public string Text
    {
        get => _text; 
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(nameof(value), "Text can't be null or whitespace.");
            
            _text = value;
        }
    }

    #endregion properties

    #region ctor
    public Note(Guid id, string text) : base(id)
    {
        Text = text;
    }
    #endregion ctor
}

