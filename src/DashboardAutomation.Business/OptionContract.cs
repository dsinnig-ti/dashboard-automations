
namespace DashboardAutomation.Business;

public class OptionContract : ValueObject
{
  private OptionContract(
    string name
    , OptionContractTypes type
    , double strike
    , double lastPrice
    , long volume
    , long openInterest
    , double bid
    , double ask
    , DateTime expiration
  )
  {
    Name = name;
    Type = type;
    Strike = strike;
    LastPrice = lastPrice;
    Volume = volume;
    OpenInterest = openInterest;
    Bid = bid;
    Ask = ask;
    Expiration = expiration;
  }

  public string Name { get; private set; }
  public OptionContractTypes Type { get; private set; }
  public double Strike { get; private set; }
  public double LastPrice { get; private set; }
  public long Volume { get; private set; }
  public long OpenInterest { get; private set; }
  public double Bid { get; private set; }
  public double Ask { get; private set; }
  public DateTime Expiration { get; private set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Name;
    yield return Expiration;
  }

  public static OptionContract Create(
    string name
    , OptionContractTypes type
    , double strike
    , double lastPrice
    , long volume
    , long openInterest
    , double bid
    , double ask
    , DateTime expiration
  )
  {
    return new OptionContract(
      name
      , type
      , strike
      , lastPrice
      , volume
      , openInterest
      , bid
      , ask
      , expiration
    );
  }
}
