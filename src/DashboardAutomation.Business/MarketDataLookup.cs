
namespace DashboardAutomation.Business;

public record MarketDataLookup
{
  public LookupSymbol Lookup { get; set; }
  public IndicatorInfoRequest[] Indicators { get; set; }
  public string[] Intervals { get; set; } = [];
}
