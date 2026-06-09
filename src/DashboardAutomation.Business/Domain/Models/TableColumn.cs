namespace DashboardAutomation.Business.Domain.Models;

public class TableColumn
{
  private TableColumn(int id, string title, Func<SymbolContext, string> display, Filter filter)
  {
    Id = id.ToString();
    Title = title;
    Display = display;
    Filter = filter;
  }
  

  public string Id { get; private set; }
  public string Title { get; private set; }
  public Func<SymbolContext, string> Display { get; private set; } // Provide HTML string for the cell
  public Filter Filter { get; private set; }


  public static TableColumn Create(
    int id
    , string title
    , Func<SymbolContext, string> display
    , Filter filter
  )
  {
    return new TableColumn(id, title, display, filter);
  }
}