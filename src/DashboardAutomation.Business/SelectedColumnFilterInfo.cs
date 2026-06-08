namespace DashboardAutomation.Business;

public class SelectedColumnFilterInfo
{
  public string ColumnId { get; set; }
  public FilterLogic Logic { get; set; }
  public bool IsMultipleSelectionEnabled { get; set; }
  public bool IsDynamicItemsBasedOnDataEnabled { get; set; }
  public bool IsSearchOnColumnDataEnabled { get; set; }
  public string SearchValue { get; set; }
  
  public List<int> SelectedItems { get; set; }

  public List<SelectedGroupFilterInfo> GroupFilters { get; set; }
}