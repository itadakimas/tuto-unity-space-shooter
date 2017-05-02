using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnController : MonoBehaviour
{
  [SerializeField] private int _poolLength = 20;
  [SerializeField] private float _maxPosX = 7;
  [SerializeField] private float _minPosX = -7;
  [SerializeField] private float _spawnRate = 2f;
  [SerializeField] private GameObject _enemy;
  [SerializeField] private GameObject _level;

  private List<GameObject> _enemies;

  void Start()
  {
    InitEnemiesPool();
    InvokeRepeating("SpawnEnemy", 0, _spawnRate);
  }

  void InitEnemiesPool()
  {
    _enemies = new List<GameObject>();
    for (int i = 0; i < _poolLength; i++)
    {
      GameObject enemy = Instantiate(_enemy);
      Vector3 pos = gameObject.transform.position;

      enemy.transform.position = new Vector3(Random.Range(_minPosX, _maxPosX), pos.y, pos.z);
      enemy.SetActive(false);
      _enemies.Add(enemy);
    }
  }

  void SpawnEnemy()
  {
    foreach (GameObject enemy in _enemies)
    {
      if (!enemy.activeInHierarchy)
      {
        enemy.SetActive(true);
        break;
      }
    }
  }
}
