namespace DashboardsAgent.Shared;

public interface ICommand<out TResponse> : IRequest<TResponse>
{

}
