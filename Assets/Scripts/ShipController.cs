using UnityEngine;

public class ShipController : MonoBehaviour, IObserver
{
  private GameObject _cannonInstance;
  private GameObject _reactorInstance;
  private Rigidbody _rb;
  private PlayerStore _player;

  [SerializeField] private int _speed = 25;
  [SerializeField] private int _maxRotation = 40;
  [SerializeField] private Boundary2D _boundary = new Boundary2D { XMin = -6, XMax = 6, YMin = -3, YMax = 10 };
  [SerializeField] private GameObject _cannon;
  [SerializeField] private GameObject _reactor;

  public void OnNotification(string message, IObservable emitter)
  {
    if (message == "health:none")
    {
      gameObject.SetActive(false);
    }
  }

  void FixedUpdate()
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

  void OnTriggerEnter(Collider other)
  {
    if (other.name == "enemyProjectile" || other.name == "enemy")
    {
      _player.DecreaseHealth(10);
    }
  }

  void Start()
  {
    _cannonInstance = Instantiate(_cannon);
    _cannonInstance.transform.SetParent(transform);

    _reactorInstance = Instantiate(_reactor);
    _reactorInstance.transform.SetParent(transform);

    _rb = gameObject.GetComponent<Rigidbody>();

    _player = PlayerStore.GetInstance();
    _player.AddObserver(this);
  }
}
