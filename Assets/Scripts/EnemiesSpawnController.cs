﻿using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnController : MonoBehaviour
{
  [SerializeField] private int _poolLength = 20;
  [SerializeField] private float _maxPosX = 7;
  [SerializeField] private float _minPosX = -7;
  [SerializeField] private float _maxSpawnRate = 3f;
  [SerializeField] private float _minSpawnRate = 0f;
  [SerializeField] private GameObject _enemy;

  private List<GameObject> _enemies;

  private void InitEnemiesPool()
  {
    _enemies = new List<GameObject>();
    for (int i = 0; i < _poolLength; i++)
    {
      GameObject enemy = Instantiate(_enemy);
      EnemyShipController enemyController = enemy.GetComponent<EnemyShipController>();

      enemyController.Level = 1;
      enemy.name = "enemy";
      enemy.transform.SetParent(gameObject.transform);
      enemy.SetActive(false);
      _enemies.Add(enemy);
    }
  }

  private void SpawnEnemy()
  {
    Vector3 pos = gameObject.transform.position;

    foreach (GameObject enemy in _enemies)
    {
      if (!enemy.activeInHierarchy)
      {
        enemy.transform.position = new Vector3(Random.Range(_minPosX, _maxPosX), pos.y, pos.z);
        enemy.SetActive(true);
        break;
      }
    }
    Invoke("SpawnEnemy", Random.Range(_minSpawnRate, _maxSpawnRate));
  }

  private void Start()
  {
    InitEnemiesPool();
    SpawnEnemy();
  }
}
