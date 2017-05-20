using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour, IObserver
{
  [SerializeField] private GameObject _healthBar;
  [SerializeField] private GameObject _healthBarBackground;
  [SerializeField] private GameObject _healthBarForeground;
  [SerializeField] private GameObject _score;
  [SerializeField] private GameObject _scoreLabel;
  [SerializeField] private GameObject _scoreValue;

  private GameObject _healthBarInstance;
  private GameObject _healthBarBackgroundInstance;
  private GameObject _healthBarForegroundInstance;
  private GameObject _scoreInstance;
  private GameObject _scoreLabelInstance;
  private GameObject _scoreValueInstance;
  private Image _healthBarForegroundImage;
  private PlayerStore _player;
  private Text _scoreValueText;

  public void OnNotification(string message, IObservable emitter)
  {
    if (message == "health:decreased")
    {
      _healthBarForegroundImage.fillAmount = _player.GetHealthRate();
    }
    if (message == "score:updated")
    {
      _scoreValueText.text = _player.GetScore().ToString();
    }
  }

  private void OnDestroy()
  {
    _player.RemoveObserver(this);
  }

  private void Start ()
  {
    _healthBarInstance = Instantiate(_healthBar);
    _healthBarInstance.transform.SetParent(gameObject.transform);

    _healthBarBackgroundInstance = Instantiate(_healthBarBackground);
    _healthBarBackgroundInstance.transform.SetParent(_healthBarInstance.transform);

    _healthBarForegroundInstance = Instantiate(_healthBarForeground);
    _healthBarForegroundInstance.transform.SetParent(_healthBarBackgroundInstance.transform);

    _healthBarForegroundImage = _healthBarForegroundInstance.GetComponent<Image>();

    _player = PlayerStore.GetInstance();
    _player.AddObserver(this);

    _scoreInstance = Instantiate(_score);
    _scoreInstance.transform.SetParent(gameObject.transform);

    _scoreLabelInstance = Instantiate(_scoreLabel);
    _scoreLabelInstance.transform.SetParent(_scoreInstance.transform);

    _scoreValueInstance = Instantiate(_scoreValue);
    _scoreValueInstance.transform.SetParent(_scoreInstance.transform);

    _scoreValueText = _scoreValueInstance.GetComponent<Text>();
  }
}
