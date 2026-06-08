namespace DashboardAutomation.Business;

public class Watchlist
{
  public string Id { get; set; }
  public string Name { get; set; }
  public List<Symbol> Symbols { get; set; }
  public List<SelectedColumnFilterInfo> Filters { get; set; }
}