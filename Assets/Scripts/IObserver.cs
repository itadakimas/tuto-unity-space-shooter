public interface IObserver
{
  void OnNotification(string message, IObservable emitter);
}
