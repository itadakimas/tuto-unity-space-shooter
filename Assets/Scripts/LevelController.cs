using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
  [SerializeField] private GameObject _background;
  [SerializeField] private List<GameObject> _lights;

  private GameObject _backgroundInstance;
  private List<GameObject> _lightsInstances;

  void Start ()
  {
    _backgroundInstance = Instantiate(_background);
    _backgroundInstance.transform.SetParent(transform);

    _lightsInstances = new List<GameObject>();
    foreach (GameObject light in _lights)
    {
      GameObject lightInstance = Instantiate(light);

      lightInstance.transform.SetParent(transform);
      _lightsInstances.Add(lightInstance);
    }
  }
}
