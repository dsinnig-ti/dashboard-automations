
namespace DashboardAutomation.Shared;

public interface IEntity
{
  int Id { get; }

  List<IDomainEvent> DomainEvents { get; }

  void ClearEvents();
}
