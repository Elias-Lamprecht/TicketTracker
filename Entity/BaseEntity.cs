namespace Ticket_Tracker.Entity;

public abstract class BaseEntity
{
    #region properties
    public Guid Id { get; set; }
    #endregion properties

    #region ctor
    public BaseEntity(Guid id)
    {
        Id = id;
    }
    #endregion ctor
}