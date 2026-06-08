namespace DashboardAutomation.Business;

public class TableColumn
{
  public string Id { get; set; }
  public string Title { get; set; }
  public Func<SymbolContext, string> Display { get; set; } // Provide HTML string for the cell
  public Filter Filter { get; set; }
}