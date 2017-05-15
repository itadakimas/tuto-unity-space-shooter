﻿using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
  [SerializeField] private int _basePoints;
  [SerializeField] private int _level;
  [SerializeField] private float _deactivationInterval;
  [SerializeField] private float _explosionDuration;
  [SerializeField] private GameObject _cannon;
  [SerializeField] private GameObject _explosion;
  [SerializeField] private GameObject _reactor;

  private GameObject _explosionInstance;
  private PlayerStore _player;

  public int Level
  {
    get
    {
      return _level;
    }
    set
    {
      _level = value;
    }
  }

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
      _player.IncreaseScore(_level * _basePoints);
      Invoke("Destroy", _explosionDuration);
    }
  }

  void Start()
  {
    _player = PlayerStore.GetInstance();
    _explosionInstance = Instantiate(_explosion, transform, false);
    _explosionInstance.SetActive(false);
    Instantiate(_cannon, transform, false);
    Instantiate(_reactor, transform, false);
  }
}
