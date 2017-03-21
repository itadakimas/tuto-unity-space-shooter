using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingBehaviour : MonoBehaviour
{
  [SerializeField]
  int _speed;

  Rigidbody _rb;

  void Start ()
  {
    _rb = gameObject.GetComponent<Rigidbody> ();
    _rb.velocity = new Vector3 (0, 0, 1) * _speed;
  }
}

[CustomEditor(typeof(MovingBehaviour))]
public class MovingBehaviourEditor : Editor
{
  SerializedProperty _speedField;

  void OnEnable()
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
