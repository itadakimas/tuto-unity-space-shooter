using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShipController : MonoBehaviour
{
	[SerializeField]
	private int speed = 0;

	private Rigidbody rb;

	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		float horizontalMove = Input.GetAxis ("Horizontal");
		float verticalMove = Input.GetAxis ("Vertical");
		float x = horizontalMove * (float)speed;
		float z = verticalMove * (float)speed;

		rb.velocity = new Vector3 (x, 0, z);
	}
}

[CustomEditor(typeof(ShipController))]
public class ShipControllerEditor : Editor
{
	SerializedProperty speedProperty;

	public void OnEnable()
	{
		speedProperty = serializedObject.FindProperty ("speed");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update ();

		EditorGUILayout.IntSlider (speedProperty, 0, 20, new GUIContent("Speed"));

		serializedObject.ApplyModifiedProperties ();
	}
}