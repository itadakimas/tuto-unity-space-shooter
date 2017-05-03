using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
  [SerializeField] private float _explosionDuration;
  [SerializeField] private GameObject _cannon;
  [SerializeField] private GameObject _explosion;
  [SerializeField] private GameObject _reactor;

  private float _deactivationInterval = 20f;
  private GameObject _explosionInstance;

  void Destroy()
  {
    _explosionInstance.SetActive(false);
    gameObject.SetActive(false);
  }

  void OnDisable()
  {
    CancelInvoke();
  }

  void OnEnable()
  {
    Invoke("Destroy", _deactivationInterval);
  }

  void OnTriggerEnter(Collider other)
  {
    ProjectileController projectileController = other.gameObject.GetComponent<ProjectileController>();

    if (projectileController != null && projectileController.Type == ProjectileTypes.Player)
    {
      _explosionInstance.SetActive(true);
      Invoke("Destroy", _explosionDuration);
    }
  }

  void Start()
  {
    _explosionInstance = Instantiate(_explosion, transform, false);
    _explosionInstance.SetActive(false);
    Instantiate(_cannon, transform, false);
    Instantiate(_reactor, transform, false);
  }
}
