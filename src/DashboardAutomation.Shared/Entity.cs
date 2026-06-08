namespace DashboardsAgent.Shared;

public abstract class Entity : IEntity, IEquatable<Entity>
{
  protected Entity(int id)
  {
    Id = id;
  }

  int? _requestedHashCode;
  private List<IDomainEvent> _domainEvents = [];
  public int Id { get; private init; }

  public List<IDomainEvent> DomainEvents => _domainEvents;
  public void AddDomainEvent(IDomainEvent eventItem)
    => _domainEvents.Add(eventItem);

  public void ClearEvents()
    => _domainEvents.Clear();


  public override bool Equals(object? obj)
  {
    if (obj is null || obj is not Entity)
      return false;
    if (Object.ReferenceEquals(this, obj))
      return true;
    if (this.GetType() != obj.GetType())
      return false;
    Entity item = (Entity)obj;
    return item.Id == this.Id;
  }

  public override int GetHashCode()
  {
    if (!_requestedHashCode.HasValue)
      _requestedHashCode = this.Id.GetHashCode() ^ 31;
    return _requestedHashCode.Value;
  }

  public bool Equals(Entity? other)
    => other is not null && this.Equals((object)other);

  public static bool operator ==(Entity? left, Entity? right)
    => left is not null && left.Equals(right);
  public static bool operator !=(Entity? left, Entity? right)
    => !(left == right);

}
