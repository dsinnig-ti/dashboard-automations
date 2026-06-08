namespace DashboardsAgent.Common;

public record Subscription(string Key, Action Unsubscribe);
