
namespace DashboardAutomation.Business;

[DebuggerDisplay("{Name} {AssetClass} {DecimalPoints}")]
public class Symbol : Entity
{
  private Symbol(int id) : base(id) { }

  internal Symbol(
    int id
   , string name
   , string description
   , int decimalPoints
   , string assetClass
   , bool isEnabled
   , string? country
   , string? sector
   , string? industry
   , string? summary
   , long? earningsDate
   , bool earningsDateEstimate
   , int? strikes
   , int? expirations
   , long? marketCap
   , DateTime? dividendDate
   , DateTime? exDividendDate
   , double? dividendYield
   , double? forwardDividend
   , double? payoutRatio
   , double? beta
   , double? annualTargetEstimate
   , double? trailingPE
   , double? forwardPE
   , double? pegRatio
   , double? priceToSales
   , double? priceToBook
   , double? profitMargin
   , double? operatingMargin
   , double? returnOnEquity
   , double? quarterlyRevenueGrowth
   , double? quarterlyEarningsGrowth
   , double? totalDebtToEquity
   , double? operatingCashFlow
   , double? leveredFreeCashFlow
   , double? heldByInsiders
   , double? heldByInstitutions
   , double? shortSharesOutstanding
   , double? fiftyTwoWeekLow
   , double? fiftyTwoWeekHigh
   , DateTime? shortInterestDate
   , double? shortInterest
   , string? exchange
   , string? exchangeShortName
   , string? currency
   , IEnumerable<string>? eTFs
   , IEnumerable<string>? groups
   , IEnumerable<SymbolTicker>? tickers
   , IEnumerable<SymbolDividendHistory>? dividends
   , IEnumerable<SymbolEarningHistory>? earnings
   , IEnumerable<OptionContract>? optionContracts
   , IEnumerable<long>? expirationTimes
  ) : base(id)
  {
    Name = name;
    Description = description;
    DecimalPoints = decimalPoints;
    AssetClass = assetClass;
    IsEnabled = isEnabled;
    Country = country;
    Sector = sector;
    Industry = industry;
    Summary = summary;
    EarningsDate = earningsDate;
    EarningsDateEstimate = earningsDateEstimate;
    Strikes = strikes;
    Expirations = expirations;
    MarketCap = marketCap;
    DividendDate = dividendDate;
    ExDividendDate = exDividendDate;
    DividendYield = dividendYield;
    ForwardDividend = forwardDividend;
    PayoutRatio = payoutRatio;
    _tickers = tickers?.ToList() ?? [];
    _eTFs = eTFs?.ToList() ?? [];
    _groups = groups?.ToList() ?? [];
    _dividends = dividends?.ToList() ?? [];
    _earnings = earnings?.ToList() ?? [];
    _optionContracts = optionContracts?.ToList() ?? [];
    _expirationTimes = expirationTimes?.ToList() ?? [];

    // New assignments for market info properties
    Beta = beta;
    AnnualTargetEstimate = annualTargetEstimate;
    TrailingPE = trailingPE;
    ForwardPE = forwardPE;
    PegRatio = pegRatio;
    PriceToSales = priceToSales;
    PriceToBook = priceToBook;
    ProfitMargin = profitMargin;
    OperatingMargin = operatingMargin;
    ReturnOnEquity = returnOnEquity;
    QuarterlyRevenueGrowth = quarterlyRevenueGrowth;
    QuarterlyEarningsGrowth = quarterlyEarningsGrowth;
    TotalDebtToEquity = totalDebtToEquity;
    OperatingCashFlow = operatingCashFlow;
    LeveredFreeCashFlow = leveredFreeCashFlow;
    HeldByInsiders = heldByInsiders;
    HeldByInstitutions = heldByInstitutions;
    ShortSharesOutstanding = shortSharesOutstanding;
    FiftyTwoWeekLow = fiftyTwoWeekLow;
    FiftyTwoWeekHigh = fiftyTwoWeekHigh;
    ShortInterestDate = shortInterestDate;
    ShortInterest = shortInterest;

    Exchange = exchange;
    ExchangeShortName = exchangeShortName;
    Currency = currency;
  }

  public string Name { get; private set; }
  public string Description { get; private set; }
  public int DecimalPoints { get; private set; }
  public string AssetClass { get; private set; }
  public string? Country { get; private set; }
  public string? Sector { get; private set; }
  public string? Industry { get; private set; }
  public string? Summary { get; set; }
  public long? EarningsDate { get; private set; }
  public bool EarningsDateEstimate { get; private set; }
  public int? Strikes { get; private set; }
  public int? Expirations { get; private set; }
  public long? MarketCap { get; private set; }
  public bool IsEnabled { get; private set; }
  public DateTime? ExDividendDate { get; set; }
  public DateTime? DividendDate { get; set; }
  public double? DividendYield { get; private set; }
  public double? ForwardDividend { get; private set; }
  public double? PayoutRatio { get; private set; }

  public double? Beta { get; private set; }
  public double? AnnualTargetEstimate { get; private set; }
  public double? TrailingPE { get; private set; }
  public double? ForwardPE { get; private set; }
  public double? PegRatio { get; private set; }
  public double? PriceToSales { get; private set; }
  public double? PriceToBook { get; private set; }
  public double? ProfitMargin { get; private set; }
  public double? OperatingMargin { get; private set; }
  public double? ReturnOnEquity { get; private set; }
  public double? QuarterlyRevenueGrowth { get; private set; }
  public double? QuarterlyEarningsGrowth { get; private set; }
  public double? TotalDebtToEquity { get; private set; }
  public double? OperatingCashFlow { get; private set; }
  public double? LeveredFreeCashFlow { get; private set; }
  public double? HeldByInsiders { get; private set; }
  public double? HeldByInstitutions { get; private set; }
  public double? ShortSharesOutstanding { get; private set; }
  public double? FiftyTwoWeekLow { get; private set; }
  public double? FiftyTwoWeekHigh { get; private set; }
  public DateTime? ShortInterestDate { get; private set; }
  public double? ShortInterest { get; private set; }

  public string? Exchange { get; private set; }
  public string? ExchangeShortName { get; private set; }
  public string? Currency { get; private set; }

  private readonly List<string> _groups;
  public IReadOnlyList<string> Groups => _groups;

  private readonly List<string> _eTFs;
  public IReadOnlyList<string> ETFs => _eTFs;

  private readonly List<SymbolTicker> _tickers;
  public IReadOnlyList<SymbolTicker> Tickers => [.. _tickers];

  private readonly List<SymbolDividendHistory> _dividends;
  public IReadOnlyList<SymbolDividendHistory> Dividends => [.. _dividends];

  private readonly List<SymbolEarningHistory> _earnings;
  public IReadOnlyList<SymbolEarningHistory> Earnings => [.. _earnings];

  private readonly List<OptionContract> _optionContracts;
  public IReadOnlyList<OptionContract> OptionContracts => [.. _optionContracts];

  private readonly List<long> _expirationTimes = [];
  public IReadOnlyList<long> ExpirationTimes => _expirationTimes;


  public static Symbol Create(
    int id
   , string name
   , string description
   , int decimalPoints
   , string assetClass
   , bool isEnabled
   , string? country
   , string? sector
   , string? industry
   , string? summary
   , long? earningsDate
   , bool earningsDateEstimate
   , int? strikes
   , int? expirations
   , long? marketCap
   , DateTime? dividendDate
   , DateTime? exDividendDate
   , double? dividendYield
   , double? forwardDividend
   , double? payoutRatio
   , double? beta
   , double? annualTargetEstimate
   , double? trailingPE
   , double? forwardPE
   , double? pegRatio
   , double? priceToSales
   , double? priceToBook
   , double? profitMargin
   , double? operatingMargin
   , double? returnOnEquity
   , double? quarterlyRevenueGrowth
   , double? quarterlyEarningsGrowth
   , double? totalDebtToEquity
   , double? operatingCashFlow
   , double? leveredFreeCashFlow
   , double? heldByInsiders
   , double? heldByInstitutions
   , double? shortSharesOutstanding
   , double? fiftyTwoWeekLow
   , double? fiftyTwoWeekHigh
   , DateTime? shortInterestDate
   , double? shortInterest
   , string? exchange
   , string? exchangeShortName
   , string? currency
   , IEnumerable<string>? eTFs
   , IEnumerable<string>? groups
   , IEnumerable<SymbolTicker>? tickers
   , IEnumerable<SymbolDividendHistory>? dividends
   , IEnumerable<SymbolEarningHistory>? earnings
   , IEnumerable<OptionContract>? optionContracts
   , IEnumerable<long>? expirationTimes
  )
  {
    return new Symbol(
      id
     , name
     , description
     , decimalPoints
     , assetClass
     , isEnabled
     , country
     , sector
     , industry
     , summary
     , earningsDate
     , earningsDateEstimate
     , strikes
     , expirations
     , marketCap
     , dividendDate
     , exDividendDate
     , dividendYield
     , forwardDividend
     , payoutRatio
     , beta
     , annualTargetEstimate
     , trailingPE
     , forwardPE
     , pegRatio
     , priceToSales
     , priceToBook
     , profitMargin
     , operatingMargin
     , returnOnEquity
     , quarterlyRevenueGrowth
     , quarterlyEarningsGrowth
     , totalDebtToEquity
     , operatingCashFlow
     , leveredFreeCashFlow
     , heldByInsiders
     , heldByInstitutions
     , shortSharesOutstanding
     , fiftyTwoWeekLow
     , fiftyTwoWeekHigh
     , shortInterestDate
     , shortInterest
     , exchange
     , exchangeShortName
     , currency
     , eTFs
     , groups
     , tickers
     , dividends
     , earnings
     , optionContracts
     , expirationTimes
    );
  }
}
