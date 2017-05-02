using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
  [SerializeField] private int _fireRate = 2;
  [SerializeField] private int _poolLength = 20;
  [SerializeField] private GameObject _projectile;

  private List<GameObject> _projectiles;

  void InitProjectilesPool()
  {
    _projectiles = new List<GameObject>();
    for (int i = 0; i < _poolLength; i++)
    {
      GameObject projectile = Instantiate(_projectile, transform);

      projectile.SetActive(false);
      _projectiles.Add(projectile);
    }
  }

  void Start()
  {
    InitProjectilesPool();
  }
}
