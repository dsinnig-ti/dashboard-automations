namespace DashboardAutomation.Shared;

public interface IDomainEvent : INotification
{
  DateTime Date { get; }
}
