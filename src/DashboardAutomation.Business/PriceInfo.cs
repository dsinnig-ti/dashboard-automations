
namespace DashboardAutomation.Business;

public class PriceInfo : ValueObject
{
  internal PriceInfo(double open, double close, double high, double low, double change, long volume, DateTime date, long timestamp)
  {
    Open = open;
    Close = close;
    High = high;
    Low = low;
    Change = change;
    Volume = volume;
    Date = date;
    Timestamp = timestamp;
  }


  public double Open { get; private set; }
  public double Close { get; private set; }
  public double High { get; private set; }
  public double Low { get; private set; }
  public double Change { get; private set; }
  public long Volume { get; private set; }
  public DateTime Date { get; private set; }
  public long Timestamp { get; private set; }


  public static PriceInfo Create(
  double open
  , double close
  , double high
  , double low
  , double change
  , long volume
  , DateTime date
  , long timestamp
)
  => new(open, close, high, low, change, volume, date, timestamp);

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Timestamp;
    yield return Open;
    yield return Close;
  }
}
