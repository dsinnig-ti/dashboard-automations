namespace DashboardAutomation.Business;

public abstract class Dashboard
{

  private IReadOnlyList<TableColumn> _columns;
  private IReadOnlyList<Watchlist> _watchlists;
  private IReadOnlyList<SymbolContext> _symbolContexts;

  public MarketDataLookup MarketDataLookup { get; private set; }


  public void SetSymbolContexts(IEnumerable<SymbolContext> symbolContexts)
  {
    _symbolContexts = [.. symbolContexts];
  }

  public SymbolContext[] GetWatchlistRows(Watchlist watchlist)
  {

    return [];
  }
}