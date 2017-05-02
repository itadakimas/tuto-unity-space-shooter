using UnityEngine;

public class CollisionController : MonoBehaviour
{
  void OnTriggerEnter(Collider other)
  {
    ProjectileController projectileController = other.gameObject.GetComponent<ProjectileController>();

    if (projectileController != null && projectileController.Type == ProjectileTypes.Player)
    {
      Debug.Log("On collision gameobject = " + other.gameObject.name);
    }
  }
}
