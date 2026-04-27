namespace TicketTracker.Entity;

public abstract class NamedEntity : BaseEntity
{
    #region properties

    public string Title 
    { 
        get => _title; 
        set 
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("Title can't be null or whitespace.");

            _title = value;
        }
    }
    private string _title = string.Empty;

    public string? Description 
    { 
        get => _description; 
        set 
        {
            _description = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }
    }
    private string? _description = string.Empty;
    #endregion properties

    #region ctor
    public NamedEntity(Guid id, string title, string? description) : base(id)
    {
        Title = title;
        Description = description;
    }
    #endregion ctor
}

