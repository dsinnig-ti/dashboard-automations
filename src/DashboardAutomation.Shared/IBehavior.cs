namespace DashboardsAgent.Shared;

public interface IBehavior<TRequest, TResponse>
  : IPipelineBehavior<TRequest, TResponse>
  where TRequest : notnull
{

}
