using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShipController : MonoBehaviour
{
  [SerializeField]
  int _speed = 0;

  [SerializeField]
  int _maxRotation = 20;

  [SerializeField]
  Boundary2D _boundary;

  Rigidbody _rb;

  void Start()
  {
    _rb = gameObject.GetComponent<Rigidbody> ();
  }

  void FixedUpdate ()
  {
    float horizontalMove = Input.GetAxis ("Horizontal");
    float verticalMove = Input.GetAxis ("Vertical");
    Vector3 movement = new Vector3 (horizontalMove, 0, verticalMove);

    _rb.velocity = movement * _speed;
    _rb.position = new Vector3 (
      Mathf.Clamp (_rb.position.x, _boundary.xMin, _boundary.xMax),
      0,
      Mathf.Clamp (_rb.position.z, _boundary.yMin, _boundary.yMax)
    );
    _rb.MoveRotation (Quaternion.Euler (0, 0, -(_maxRotation * horizontalMove)));
  }
}

[CustomEditor(typeof(ShipController))]
public class ShipControllerEditor : Editor
{
  SerializedProperty _boundaryProperty;
  SerializedProperty _maxRotationProperty;
  SerializedProperty _speedProperty;

  void OnEnable()
  {
    _boundaryProperty = serializedObject.FindProperty ("_boundary");
    _maxRotationProperty = serializedObject.FindProperty ("_maxRotation");
    _speedProperty = serializedObject.FindProperty ("_speed");
  }

  public override void OnInspectorGUI()
  {
    serializedObject.Update ();

    EditorGUILayout.IntSlider (_speedProperty, 0, 20, new GUIContent("Speed"));

    EditorGUILayout.IntSlider (_maxRotationProperty, 0, 90, new GUIContent("Max Rotation"));

    EditorGUILayout.PropertyField (_boundaryProperty, new GUIContent("Boundary 2D"), true);

    serializedObject.ApplyModifiedProperties ();
  }
}
