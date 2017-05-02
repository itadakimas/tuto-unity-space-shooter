using UnityEngine;

public class ProjectileController : MonoBehaviour
{
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
