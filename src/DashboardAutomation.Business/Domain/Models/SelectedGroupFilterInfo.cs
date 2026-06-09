namespace DashboardAutomation.Business;

public class SelectedGroupFilterInfo
{
  public int Id { get; set; }
  public FilterLogic Logic { get; set; }
  public bool IsMultipleSelectionEnabled { get; set; }
  public bool IsDynamicItemsBasedOnDataEnabled { get; set; }
  public List<int> Items { get; set; }
}