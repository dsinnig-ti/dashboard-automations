namespace DashboardAutomation.Business.Domain.Models;

public class FilterGroup
{
  private FilterGroup(
    int id
    , FilterLogic logic
    , bool isMultipleSelectionEnabled
    , bool isDynamicItemsBasedOnDataEnabled
    , IReadOnlyList<FilterItem> filterItems
  )
  {
    Id = id;
    Logic = logic;
    IsMultipleSelectionEnabled = isMultipleSelectionEnabled;
    IsDynamicItemsBasedOnDataEnabled = isDynamicItemsBasedOnDataEnabled;
    FilterItems = filterItems;
  }

  public int Id { get; private set; }
  public FilterLogic Logic { get; private set; }
  public bool IsMultipleSelectionEnabled { get; private set; }
  public bool IsDynamicItemsBasedOnDataEnabled { get; private set; }
  public IReadOnlyList<FilterItem> FilterItems { get; private set; }


  public static FilterGroup Create(
    int id
    , FilterLogic logic
    , bool isMultipleSelectionEnabled = false
    , bool isDynamicItemsBasedOnDataEnabled = false
    , IEnumerable<FilterItem>? filterItems = null
  )
  {
    return new FilterGroup(
      id
      , logic
      , isMultipleSelectionEnabled
      , isDynamicItemsBasedOnDataEnabled
      , filterItems?.ToList() ?? []
    );
  }
}