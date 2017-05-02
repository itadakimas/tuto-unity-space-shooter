using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
  [SerializeField] private GameObject _cannon;
  [SerializeField] private GameObject _reactor;

  private float _deactivationInterval = 20f;

  void Destroy()
  {
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
      Debug.Log("collision with " + other.gameObject.name);
    }
  }

  void Start()
  {
    GameObject cannon = Instantiate(_cannon, transform, false);
    GameObject reactor = Instantiate(_reactor, transform, false);

    cannon.transform.SetParent(transform, false);
    reactor.transform.SetParent(transform, false);
  }
}
