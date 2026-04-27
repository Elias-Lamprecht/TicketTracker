using TicketTracker.Entity;

namespace TicketTracker.Models;

public class Note : BaseEntity
{
    #region properties
    public string Text { get; private set; }
    #endregion properties

    #region ctor
    public Note(Guid id, string text) : base(id)
    {
        SetText(text);
    }
    #endregion ctor

    #region methods
    public void SetText(string text)
    {
        if (string.IsNullOrEmpty(text))
            throw new ArgumentNullException();

        Text = text;
    }
    #endregion methods
}

