namespace DashboardAutomation.Shared;

public interface ICommand<out TResponse> : IRequest<TResponse>
{

}
