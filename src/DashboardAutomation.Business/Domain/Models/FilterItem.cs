namespace DashboardAutomation.Business.Domain.Models;

public class FilterItem
{
  private FilterItem(int id, Func<IEnumerable<SymbolContext>, IEnumerable<SymbolContext>> filter)
  {
    Id = id;
    Filter = filter;
  }

  public int Id { get; private set; }
  public Func<IEnumerable<SymbolContext>, IEnumerable<SymbolContext>> Filter { get; private set; }


  public static FilterItem Create(
    int id
    , Func<IEnumerable<SymbolContext>, IEnumerable<SymbolContext>> filter
  )
  {
    return new FilterItem(id, filter);
  }
}