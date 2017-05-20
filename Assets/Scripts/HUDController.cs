using UnityEngine;

public class HUDController : MonoBehaviour
{
  [SerializeField] private GameObject _healthBar;
  [SerializeField] private GameObject _score;

  private GameObject _healthBarInstance;
  private GameObject _scoreInstance;

  void Start ()
  {
    _healthBarInstance = Instantiate(_healthBar);
    _healthBarInstance.transform.SetParent(gameObject.transform);
    _scoreInstance = Instantiate(_score);
    _scoreInstance.transform.SetParent(gameObject.transform);
  }
}
