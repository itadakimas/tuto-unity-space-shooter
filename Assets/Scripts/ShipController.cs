﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShipController : MonoBehaviour
{
	[SerializeField]
	private int speed = 0;

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
	}
}

[CustomEditor(typeof(ShipController))]
public class ShipControllerEditor : Editor
{
	SerializedProperty boundaryProperty;
	SerializedProperty speedProperty;

	public void OnEnable()
	{
		boundaryProperty = serializedObject.FindProperty ("boundary");
		speedProperty = serializedObject.FindProperty ("speed");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update ();

		EditorGUILayout.IntSlider (speedProperty, 0, 20, new GUIContent("Speed"));

		EditorGUILayout.PropertyField (boundaryProperty, new GUIContent("Boundary 2D"), true);

		serializedObject.ApplyModifiedProperties ();
	}
}