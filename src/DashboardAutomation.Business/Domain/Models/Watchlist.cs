namespace DashboardAutomation.Business.Domain.Models;

public class Watchlist
{
  private Watchlist(
    string id
    , string name
    , string ownerEmail
    , IEnumerable<Symbol> symbols
    , IEnumerable<SelectedColumnFilterInfo> filters
  )
  {
    Id = id;
    Name = name;
    OwnerEmail = ownerEmail;
    Symbols = [.. symbols];
    Filters = [.. filters];
  }

  public string Id { get; private set; }
  public string Name { get; private set; }
  public string OwnerEmail { get; private set; }
  public IReadOnlyList<Symbol> Symbols { get; private set; }
  public IReadOnlyList<SelectedColumnFilterInfo> Filters { get; private set; }


  public static Watchlist Create(
    string id
    , string name
    , string ownerEmail
    , IEnumerable<Symbol> symbols
    , IEnumerable<SelectedColumnFilterInfo> filters
  )
  {
    return new Watchlist(id, name, ownerEmail, symbols, filters);
  }
}