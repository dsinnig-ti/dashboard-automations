namespace DashboardAutomation.Business;

public abstract class Dashboard
{

  private List<TableColumn> _columns;
  private List<Watchlist> _watchlists;
  private List<SymbolContext> _symbolContexts;
  private Dictionary<string, string> _columnValues;


  public string Name { get; private set; }
  public string Url { get; private set; }
  public string APIPath { get; private set; }

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