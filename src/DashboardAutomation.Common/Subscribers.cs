
namespace DashboardAutomation.Common;

public class Subscribers<T>
{
  public Subscribers()
  {

  }

  private Dictionary<string, T> _subscribers = [];
  private SemaphoreSlim _publishLimiter = new(1, 1);

  public Subscription Subscribe(string key, T subscriber)
  {
    if (_subscribers.ContainsKey(key))
    {
      Unsubscribe(key);
    }

    _subscribers[key] = subscriber;

    return new(key, () => _subscribers.Remove(key));
  }

  public void Unsubscribe(string key)
  {
    if (!_subscribers.ContainsKey(key))
    {
      throw new KeyNotFoundException($"Subscriber with key '{key}' not found.");
    }

    _subscribers.Remove(key);
  }

  public void Unsubscribe(Subscription subscription)
  {
    Unsubscribe(subscription.Key);
  }

  public void UnsubscribeAll()
  {
    _subscribers.Clear();
  }

  public List<T> GetAll()
  {
    return [.. _subscribers.Values];
  }

  public Task WaitForPublish()
  {
    return _publishLimiter.WaitAsync();
  }

  public void PubLished()
  {
    _publishLimiter.Release();
  }
}
