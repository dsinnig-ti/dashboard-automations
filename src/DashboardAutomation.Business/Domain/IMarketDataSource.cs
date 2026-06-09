namespace DashboardAutomation.Business;

public interface IMarketDataSource
{
  Task<IEnumerable<SymbolContext>> FetchAsync(MarketDataLookup lookup, CancellationToken cancellationToken);
}