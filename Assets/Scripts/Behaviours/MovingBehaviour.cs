using UnityEditor;
using UnityEngine;

public class MovingBehaviour : MonoBehaviour
{
  private Rigidbody _rb;

  [SerializeField] private int _speed = 20;

  public void Start ()
  {
    _rb = gameObject.GetComponent<Rigidbody> ();
    _rb.velocity = new Vector3 (0, 0, 1) * _speed;
  }
}

[CustomEditor(typeof(MovingBehaviour))]
public class MovingBehaviourEditor : Editor
{
  private SerializedProperty _speedField;

  public void OnEnable()
  {
    _speedField = serializedObject.FindProperty ("_speed");
  }

  public override void OnInspectorGUI()
  {
    serializedObject.Update ();

    EditorGUILayout.IntSlider (_speedField, 0, 30, new GUIContent("Speed"));

    serializedObject.ApplyModifiedProperties ();
  }
}
