namespace Ticket_Tracker.Entity;

abstract class BaseEntity
{
    #region properties
    public Guid Id { get; set; }
    #endregion properties

    #region ctor
    protected BaseEntity(Guid id)
    {
        Id = id;
    }
    #endregion ctor
}