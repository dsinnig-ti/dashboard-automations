namespace DashboardsAgent.Shared;

public interface IDomainEvent : INotification
{
  DateTime Date { get; }
}
