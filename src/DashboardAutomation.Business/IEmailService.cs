namespace DashboardAutomation.Business;

public interface IEmailService
{
  Task SendEmailAsync(string to, string subject, string body, CancellationToken cancellationToken);
}