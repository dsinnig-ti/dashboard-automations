namespace DashboardAutomation.Business;

public class FilterItem
{
  public int Id { get; set; }
  public Func<IEnumerable<SymbolContext>, IEnumerable<SymbolContext>> Filter { get; set; }
}