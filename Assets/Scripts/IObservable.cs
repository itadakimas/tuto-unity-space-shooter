public interface IObservable
{
  void AddObserver(IObserver o);
  void RemoveObserver(IObserver o);
  void Notify(string message);
}