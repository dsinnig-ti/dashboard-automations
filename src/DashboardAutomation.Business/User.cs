namespace DashboardAutomation.Business;

public class User
{
  public int Id { get; set; }
  public string Email { get; set; }
  public string[] WatchlistIds { get; set; }
  public string[] AllowedColumns { get; set; }

}