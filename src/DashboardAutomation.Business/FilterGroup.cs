namespace DashboardAutomation.Business;

public class FilterGroup
{
  public int Id { get; set; }
  public FilterLogic Logic { get; set; }
  public bool IsMultipleSelectionEnabled { get; set; }
  public bool IsDynamicItemsBasedOnDataEnabled { get; set; }
  public List<FilterItem> FilterItems { get; set; }
}