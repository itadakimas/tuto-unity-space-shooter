using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShipController : MonoBehaviour
{
	[SerializeField]
	private int speed = 0;

	[SerializeField]
	private int maxRotation = 20;

	[SerializeField]
	private Boundary2D boundary;

	private Rigidbody rb;

	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		float horizontalMove = Input.GetAxis ("Horizontal");
		float verticalMove = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (horizontalMove, 0, verticalMove);

		rb.velocity = movement * speed;
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0,
			Mathf.Clamp (rb.position.z, boundary.yMin, boundary.yMax)
		);
		rb.MoveRotation (Quaternion.Euler (0, 0, -(maxRotation * horizontalMove)));
	}
}

[CustomEditor(typeof(ShipController))]
public class ShipControllerEditor : Editor
{
	SerializedProperty boundaryProperty;
	SerializedProperty maxRotationProperty;
	SerializedProperty speedProperty;

	public void OnEnable()
	{
		boundaryProperty = serializedObject.FindProperty ("boundary");
		maxRotationProperty = serializedObject.FindProperty ("maxRotation");
		speedProperty = serializedObject.FindProperty ("speed");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update ();

		EditorGUILayout.IntSlider (speedProperty, 0, 20, new GUIContent("Speed"));

		EditorGUILayout.IntSlider (maxRotationProperty, 0, 90, new GUIContent("Max Rotation"));

		EditorGUILayout.PropertyField (boundaryProperty, new GUIContent("Boundary 2D"), true);

		serializedObject.ApplyModifiedProperties ();
	}
}