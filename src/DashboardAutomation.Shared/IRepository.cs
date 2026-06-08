namespace DashboardsAgent.Shared;

public interface IRepository<T> where T : Entity, IAggregateRoot
{

}
