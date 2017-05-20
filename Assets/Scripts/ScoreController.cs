using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour, IObserver
{
  private PlayerStore _player;
  private Text _text;

  public void OnNotification(string message, IObservable emitter)
  {
    if (message == "score:updated")
    {
      _text.text = _player.GetScore().ToString();
    }
  }

  private void Start ()
  {
    _player = PlayerStore.GetInstance();
    _text = gameObject.GetComponent<Text>();
    _player.AddObserver(this);
  } 
}
