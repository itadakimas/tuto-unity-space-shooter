using System.Collections.Generic;

abstract public class Store<T> where T : IObservable, new()
{
  private static T _instance;

  private List<IObserver> _observers;

  public static T GetInstance()
  {
    if (_instance == null)
    {
      _instance = new T();
    }
    return _instance;
  }

  public void AddObserver(IObserver o)
  {
    _observers.Add(o);
  }

  public void Notify(string message)
  {
    _observers.ForEach((o) => o.OnNotification(message, this as IObservable));
  }

  public void RemoveObserver(IObserver o)
  {
    _observers.Remove(o);
  }

  protected Store()
  {
    _observers = new List<IObserver>();
  }
}
