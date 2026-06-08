namespace DashboardsAgent.Shared;

public interface IValidation<TRequest, TResponse>
  : IPipelineBehavior<TRequest, TResponse>
  where TRequest : notnull
{

}
