
namespace DashboardAutomation.Business;

public record LookupSymbol
{
  public string? Search { get; set; }
  public string[]? Symbols { get; set; }
  public string[]? AssetClasses { get; set; }
  public string[]? ETFs { get; set; }
  public string[]? Groups { get; set; }
  public string[]? Countries { get; set; }
  public bool? IncludeDisabledSymbols { get; set; }
}
