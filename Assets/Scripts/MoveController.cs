using UnityEngine;

public class MoveController : MonoBehaviour
{
  private Rigidbody _rb;

  [SerializeField] private float _speed = 20;
  [SerializeField] private Vector3 _direction;

  public void SetDirection(Vector3 direction)
  {
    _direction = direction;
  }

  void Start ()
  {
    _rb = gameObject.GetComponent<Rigidbody> ();
    _rb.velocity = _direction * _speed;
  }
}
