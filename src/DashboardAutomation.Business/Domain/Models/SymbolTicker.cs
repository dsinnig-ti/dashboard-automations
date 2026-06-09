

namespace DashboardAutomation.Business;

public class SymbolTicker : ValueObject
{
  internal SymbolTicker(string title, string value)
  {
    Title = title;
    Value = value;
  }

  public string Title { get; private set; }
  public string Value { get; private set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Title;
    yield return Value;
  }

  public static SymbolTicker Create(string title, string value)
  {
    return new SymbolTicker(title, value);
  }
}
