using UnityEngine;

public class ProjectileController : MonoBehaviour
{
  private ProjectileTypes _type;
  private float _deactivationInterval = 2f;

  public ProjectileTypes Type { get; set; }

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
}
