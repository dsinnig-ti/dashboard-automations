

namespace DashboardAutomation.Business;

public class SymbolDividendHistory : ValueObject
{
  private SymbolDividendHistory(DateTime date, double amount)
  {
    Date = date;
    Amount = amount;
  }

  public DateTime Date { get; private set; }
  public double Amount { get; private set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Date;
    yield return Amount;
  }

  public static SymbolDividendHistory Create(DateTime date, double amount)
  {
    return new SymbolDividendHistory(date, amount);
  }
}
