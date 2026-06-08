namespace DashboardAutomation.Business;

public class SymbolContext
{
  public Symbol Symbol { get; set; }
  public PriceInfo PriceInfo { get; set; }
  public List<IndicatorResult> IndicatorResults { get; set; }

  public IndicatorResult? GetIndicatorResult(string name)
  {
    return IndicatorResults.FirstOrDefault(x => x.Name == name);
  }
}