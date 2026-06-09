namespace DashboardAutomation.Business.Domain.Models;

public class Filter
{
  private Filter(
    FilterLogic logic
    , bool isMultipleSelectionEnabled
    , bool isDynamicItemsBasedOnDataEnabled
    , bool isSearchOnColumnDataEnabled
    , string? search
    , IEnumerable<FilterItem> items
    , IEnumerable<FilterGroup> groups
  )
  {
    Logic = logic;
    IsMultipleSelectionEnabled = isMultipleSelectionEnabled;
    IsDynamicItemsBasedOnDataEnabled = isDynamicItemsBasedOnDataEnabled;
    IsSearchOnColumnDataEnabled = isSearchOnColumnDataEnabled;
    Search = search;
    Items = [..items];
    Groups = [.. groups];
  }


  public FilterLogic Logic { get; private set; }
  public bool IsMultipleSelectionEnabled { get; private set; }
  public bool IsDynamicItemsBasedOnDataEnabled { get; private set; }
  public bool IsSearchOnColumnDataEnabled { get; private set; }
  public string? Search { get; private set; }

  public IReadOnlyList<FilterItem> Items { get; private set; }
  public IReadOnlyList<FilterGroup> Groups { get; private set; }



  public static Filter Create(
    FilterLogic logic
    , bool isMultipleSelectionEnabled = false
    , bool isDynamicItemsBasedOnDataEnabled = false
    , bool isSearchOnColumnDataEnabled = false
    , string? search = null
    , IEnumerable<FilterItem>? items = null
    , IEnumerable<FilterGroup>? groups = null
  )
  {
    return new Filter(
      logic
      , isMultipleSelectionEnabled
      , isDynamicItemsBasedOnDataEnabled
      , isSearchOnColumnDataEnabled
      , search
      , items ?? []
      , groups ?? []
    );
  }
}