namespace Ticket_Tracker.Entity;

abstract class NamedEntity : BaseEntity
{
    #region properties
    public string Title { get; private set; }
    public string? Description { get; private set; } = null;
    #endregion properties

    #region ctor
    protected NamedEntity(Guid id, string title, string? description) : base(id)
    {
        SetTitle(title);

        if (description != null)
        {
            SetDescription(description);
        }
    }
    #endregion ctor

    #region methods
    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException(nameof(title), "Ticket Title can't be null, empty or whitespace.");

        Title = title;
    }

    public void SetDescription(string description)
    {
        if (!string.IsNullOrWhiteSpace(description))
            RemoveDescription();

        Description = description;
    }

    public void RemoveDescription()
    {
        Description = null;
    }
    #endregion methods
}

