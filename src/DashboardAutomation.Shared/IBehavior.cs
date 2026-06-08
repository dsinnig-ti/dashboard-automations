namespace DashboardAutomation.Shared;

public interface IBehavior<TRequest, TResponse>
  : IPipelineBehavior<TRequest, TResponse>
  where TRequest : notnull
{

}
