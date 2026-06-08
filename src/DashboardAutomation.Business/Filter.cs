namespace DashboardAutomation.Business;

public class Filter
{
  public FilterLogic Logic { get; set; }
  public bool IsMultipleSelectionEnabled { get; set; }
  public bool IsDynamicItemsBasedOnDataEnabled { get; set; }
  public bool IsSearchOnColumnDataEnabled { get; set; }
}