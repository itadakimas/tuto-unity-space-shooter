using UnityEngine;

public class ProjectileController : MonoBehaviour
{
  private ProjectileTypes _type;

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
    Invoke("Destroy", 2f);
  }
}
