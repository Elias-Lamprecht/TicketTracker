using TicketTracker.Entity;

namespace TicketTracker.Models;

public class Note : BaseEntity
{
    public string Text { get; private set; }

    public Note(Guid id, string text) : base(id)
    {
        SetText(text);
    }

    public void SetText(string text)
    {
        if (string.IsNullOrEmpty(text))
            throw new ArgumentNullException();

        Text = text;
    }
}

