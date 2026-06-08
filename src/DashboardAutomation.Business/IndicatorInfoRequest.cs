
namespace DashboardAutomation.Business;

public record IndicatorInfoRequest
{
  public IndicatorInfoRequest() { }
  

  public IndicatorInfoRequest(string name, string[] columns)
  {
    Name = name;
    Columns = columns;
  }

  public string Name { get; set; }
  public string[] Columns { get; set; }
}
