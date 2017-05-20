using UnityEngine;
using UnityEngine.UI;

public class GameOverOverlayController : MonoBehaviour, IObserver
{
  private GameObject _canvasInstance;
  private GameObject _eventSystemInstance;
  private GameObject _panelInstance;
  private GameObject _replayButtonInstance;
  private GameObject _scoreInstance;
  private GameObject _titleInstance;
  private PlayerStore _player;
  private Text _scoreText;

  [SerializeField] private GameObject _canvas;
  [SerializeField] private GameObject _eventSystem;
  [SerializeField] private GameObject _panel;
  [SerializeField] private GameObject _replayButton;
  [SerializeField] private GameObject _score;
  [SerializeField] private GameObject _title;

  public void OnNotification(string message, IObservable emitter)
  {
    if (message == "health:none")
    {
      _scoreText.text = _player.GetScore().ToString();
      gameObject.SetActive(true);
    }
  }

  private void Start ()
  {
    gameObject.SetActive(false);
    _canvasInstance = Instantiate(_canvas);
    _canvasInstance.transform.SetParent(transform, false);
    _eventSystemInstance = Instantiate(_eventSystem);
    _eventSystemInstance.transform.SetParent(transform, false);
    _panelInstance = Instantiate(_panel);
    _panelInstance.transform.SetParent(_canvasInstance.transform, false);
    _replayButtonInstance = Instantiate(_replayButton);
    _replayButtonInstance.transform.SetParent(_panelInstance.transform, false);
    _scoreInstance = Instantiate(_score);
    _scoreInstance.transform.SetParent(_panelInstance.transform, false);
    _scoreText = _scoreInstance.GetComponent<Text>();
    _titleInstance = Instantiate(_title);
    _titleInstance.transform.SetParent(_panelInstance.transform, false);
    _player = PlayerStore.GetInstance();
    _player.AddObserver(this);
  }
}
