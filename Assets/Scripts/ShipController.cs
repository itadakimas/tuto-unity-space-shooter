using System.Collections;
using UnityEngine;

public class ShipController : MonoBehaviour, IObserver
{
  private bool _isTakingDamage = false;
  private GameObject _cannonInstance;
  private GameObject _explosionInstance;
  private GameObject _reactorInstance;
  private Renderer _renderer;
  private Rigidbody _rb;
  private PlayerStore _player;

  [SerializeField] private float _explosionDuration;
  [SerializeField] private int _speed = 25;
  [SerializeField] private int _maxRotation = 40;
  [SerializeField] private Boundary2D _boundary = new Boundary2D { XMin = -6, XMax = 6, YMin = -3, YMax = 10 };
  [SerializeField] private GameObject _cannon;
  [SerializeField] private GameObject _explosion;
  [SerializeField] private GameObject _reactor;

  public void OnNotification(string message, IObservable emitter)
  {
    if (message == "health:decreased")
    {
      if (!_isTakingDamage)
      {
        _isTakingDamage = true;
        StartCoroutine(Blink(0.2f, 0.1f));
      }
    }
    if (message == "health:none")
    {
      _explosionInstance.SetActive(true);
      Invoke("Destroy", _explosionDuration);
    }
  }

  private IEnumerator Blink(float duration, float delay)
  {
    while (duration > 0)
    {
      duration -= Time.deltaTime;
      _renderer.enabled = !_renderer.enabled;
      _reactorInstance.SetActive(!_reactorInstance.activeInHierarchy);
      yield return new WaitForSeconds(delay);
    }
    _renderer.enabled = true;
    _reactorInstance.SetActive(true);
    _isTakingDamage = false;
  }

  private void Destroy()
  {
    gameObject.SetActive(false);
    _explosionInstance.SetActive(false);
  }

  private void FixedUpdate()
  {
    float horizontalMove = Input.GetAxis("Horizontal");
    float verticalMove = Input.GetAxis("Vertical");
    Vector3 movement = new Vector3(horizontalMove, 0, verticalMove);

    _rb.velocity = movement * _speed;

    float xLimit = Mathf.Clamp(_rb.position.x, _boundary.XMin, _boundary.XMax);
    float yLimit = Mathf.Clamp(_rb.position.z, _boundary.YMin, _boundary.YMax);

    _rb.position = new Vector3(xLimit, 0, yLimit); // NOTE: Limits Ship position to the limits of the Level
    _rb.MoveRotation(Quaternion.Euler(0, 0, -(_maxRotation * horizontalMove)));
  }

  private void OnDisable()
  {
    CancelInvoke("Destroy");
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.name == "enemyProjectile" || other.name == "enemy")
    {
      _player.DecreaseHealth(10);
    }
  }

  private void Start()
  {
    _cannonInstance = Instantiate(_cannon);
    _cannonInstance.transform.SetParent(transform);
    _explosionInstance = Instantiate(_explosion);
    _explosionInstance.transform.SetParent(transform);
    _explosionInstance.SetActive(false);
    _reactorInstance = Instantiate(_reactor);
    _reactorInstance.transform.SetParent(transform);
    _renderer = gameObject.GetComponent<Renderer>();
    _rb = gameObject.GetComponent<Rigidbody>();
    _player = PlayerStore.GetInstance();
    _player.AddObserver(this);
  }
}
