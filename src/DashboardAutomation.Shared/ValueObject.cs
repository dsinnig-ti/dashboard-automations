
namespace DashboardsAgent.Shared;

public abstract class ValueObject : IEquatable<ValueObject>
{
  protected abstract IEnumerable<object> GetEqualityComponents();

  public override bool Equals(object? obj)
  {
    if (obj == null || obj.GetType() != GetType())
      return false;

    var other = (ValueObject)obj;

    return Object.ReferenceEquals(this, obj) || GetEqualityComponents()
      .SequenceEqual(other.GetEqualityComponents());
  }

  public override int GetHashCode()
  {
    return GetEqualityComponents()
        .Select(x => x != null ? x.GetHashCode() : 0)
        .Aggregate((x, y) => x ^ y);
  }

  public bool Equals(ValueObject? other)
    => other is not null && this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());

  public static bool operator ==(ValueObject? one, ValueObject? two)
    => one is not null && one.Equals(two);

  public static bool operator !=(ValueObject? one, ValueObject? two)
    => !(one == two);
}
