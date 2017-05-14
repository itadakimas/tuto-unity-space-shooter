using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour, IObserver
{
  private Image _image;
  private PlayerStore _player;

  public void OnNotification(string message, IObservable emitter)
  {
    if (message == "health:decreased")
    {
      _image.fillAmount = _player.GetHealthRate();
    }
  }

  void Start ()
  {
    _image = gameObject.GetComponent<Image>();
    _player = PlayerStore.GetInstance();
    _player.AddObserver(this);
  }
}
