namespace DashboardAutomation.Business.Domain.Models;

public class UserPreference
{
  private UserPreference(
    int id
    , bool isTradeAlertEnabled
    , bool isReceiveSharedWatchlistNotificationEnabled
    , bool isPreviousChangeSectionEnabled
    , string email
    , string language
    , IEnumerable<Watchlist> watchlists
    , IEnumerable<string> allowedColumns
  )
  {
    Id = id;
    IsTradeAlertEnabled = isTradeAlertEnabled;
    IsReceiveSharedWatchlistNotificationEnabled = isReceiveSharedWatchlistNotificationEnabled;
    IsPreviousChangeSectionEnabled = isPreviousChangeSectionEnabled;
    Email = email;
    Language = language;
    Watchlists = [.. watchlists];
    AllowedColumnIds = [.. allowedColumns];
  }

  public int Id { get; private set; }
  public bool IsTradeAlertEnabled { get; private set; }
  public bool IsReceiveSharedWatchlistNotificationEnabled { get; private set; }
  public bool IsPreviousChangeSectionEnabled { get; private set; }
  public string Email { get; private set; }
  public string Language { get; private set; }
  public IReadOnlyList<string> AllowedColumnIds { get; private set; }
  public IReadOnlyList<Watchlist> Watchlists { get; private set; }


  public static UserPreference Create(
    int id
    , bool isTradeAlertEnabled
    , bool isReceiveSharedWatchlistNotificationEnabled
    , bool isPreviousChangeSectionEnabled
    , string email
    , string language
    , IEnumerable<Watchlist> watchlists
    , IEnumerable<string> allowedColumns
  )
  {
    return new(
      id
      , isTradeAlertEnabled
      , isReceiveSharedWatchlistNotificationEnabled
      , isPreviousChangeSectionEnabled
      , email
      , language
      , watchlists
      , allowedColumns
    );
  }

}