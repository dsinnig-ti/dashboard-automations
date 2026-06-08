
namespace DashboardsAgent.Shared;

public interface IEventHandler<T> : INotificationHandler<T> where T : IDomainEvent
{ }
