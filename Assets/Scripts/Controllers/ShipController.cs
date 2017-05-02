using UnityEditor;
using UnityEngine;

public class ShipController : MonoBehaviour
{
  private Rigidbody _rb;

  [SerializeField] private int _speed = 25;
  [SerializeField] private int _maxRotation = 40;
  [SerializeField] private Boundary2D _boundary = new Boundary2D { XMin = -6, XMax = 6, YMin = -3, YMax = 10 };

  public void Start()
  {
    _rb = gameObject.GetComponent<Rigidbody>();
  }

  public void FixedUpdate()
  {
    float horizontalMove = Input.GetAxis("Horizontal");
    float verticalMove = Input.GetAxis("Vertical");
    Vector3 movement = new Vector3(horizontalMove, 0, verticalMove);

    _rb.velocity = movement * _speed;

    float xLimit = Mathf.Clamp(_rb.position.x, _boundary.XMin, _boundary.XMax);
    float yLimit = Mathf.Clamp(_rb.position.z, _boundary.YMin, _boundary.YMax);

    // NOTE: Limits Ship position to the limits of the Level
    _rb.position = new Vector3(xLimit, 0, yLimit);
    _rb.MoveRotation(Quaternion.Euler(0, 0, -(_maxRotation * horizontalMove)));
  }
}

[CustomEditor(typeof(ShipController))]
public class ShipControllerEditor : Editor
{
  private SerializedProperty _boundaryProperty;
  private SerializedProperty _maxRotationProperty;
  private SerializedProperty _speedProperty;

  public void OnEnable()
  {
    _boundaryProperty = serializedObject.FindProperty("_boundary");
    _maxRotationProperty = serializedObject.FindProperty("_maxRotation");
    _speedProperty = serializedObject.FindProperty("_speed");
  }

  public override void OnInspectorGUI()
  {
    serializedObject.Update();
    EditorGUILayout.PropertyField(_speedProperty, new GUIContent("Speed"));
    EditorGUILayout.IntSlider(_maxRotationProperty, 0, 90, new GUIContent("Max Rotation Degrees"));
    EditorGUILayout.PropertyField(_boundaryProperty, new GUIContent("Boundary 2D"), true);
    serializedObject.ApplyModifiedProperties();
  }
}
