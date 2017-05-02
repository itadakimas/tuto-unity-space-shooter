using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
  [SerializeField] private bool _isEnemyCannon = true;
  [SerializeField] private float _fireRate = 0.5f;
  [SerializeField] private int _poolLength = 20;
  [SerializeField] private GameObject _projectile;

  private float _nextShotInterval;
  private float _secondsElapsed;
  private List<GameObject> _projectiles;

  void Fire()
  {
    for (int i = 0; i < _projectiles.Count; i++)
    {
      GameObject projectile = _projectiles[i];

      if (!projectile.activeInHierarchy)
      {
        projectile.transform.position = gameObject.transform.position;
        projectile.transform.rotation = gameObject.transform.rotation;
        projectile.SetActive(true);
        break;
      }
    }
  }

  void InitProjectilesPool()
  {
    _projectiles = new List<GameObject>();
    for (int i = 0; i < _poolLength; i++)
    {
      GameObject projectile = Instantiate(_projectile, transform);
      MoveController moveController = projectile.GetComponent<MoveController>();
      Vector3 direction = _isEnemyCannon ? Vector3.back : Vector3.forward;

      moveController.SetDirection(direction);
      projectile.SetActive(false);
      _projectiles.Add(projectile);
    }
  }

  void Start()
  {
    InitProjectilesPool();
    if (_isEnemyCannon)
    {
      InvokeRepeating("Fire", 0, _fireRate);
    }
  }

  void Update()
  {
    _secondsElapsed = _secondsElapsed + Time.deltaTime;
    if (!_isEnemyCannon && Input.GetButton("Fire1") && _secondsElapsed > _nextShotInterval)
    {
      _nextShotInterval = _secondsElapsed + _fireRate;
      Fire();
    }
  }
}
