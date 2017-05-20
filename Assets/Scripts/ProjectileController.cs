using UnityEngine;

public class ProjectileController : MonoBehaviour
{
  private ProjectileTypes _type;
  private float _deactivationInterval = 2f;

  public ProjectileTypes Type { get; set; }

  private void Destroy()
  {
    gameObject.SetActive(false);
  }

  private void OnDisable()
  {
    CancelInvoke();
  }

  private void OnEnable()
  {
    Invoke("Destroy", _deactivationInterval);
  }
}
