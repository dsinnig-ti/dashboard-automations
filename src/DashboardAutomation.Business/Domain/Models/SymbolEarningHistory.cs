

namespace DashboardAutomation.Business;

public class SymbolEarningHistory : ValueObject
{
  private SymbolEarningHistory(DateTime date, double amount, double estimateAmount, DateTime reportedDate)
  {
    Date = date;
    Amount = amount;
    EstimateAmount = estimateAmount;
    ReportedDate = reportedDate;
  }

  public DateTime Date { get; private set; }
  public DateTime ReportedDate { get; private set; }
  public double Amount { get; private set; }
  public double EstimateAmount { get; private set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Date;
    yield return Amount;
    yield return EstimateAmount;
  }

  public static SymbolEarningHistory Create(DateTime date, double amount, double estimateAmount, DateTime reportedDate)
  {
    return new SymbolEarningHistory(date, amount, estimateAmount, reportedDate);
  }
}
