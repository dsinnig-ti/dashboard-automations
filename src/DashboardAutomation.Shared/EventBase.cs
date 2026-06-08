namespace DashboardAutomation.Shared;

public record EventBase : IDomainEvent
{
  public DateTime Date { get; } = DateTime.UtcNow;
}
