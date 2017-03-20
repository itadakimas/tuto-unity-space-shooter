using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
	Rigidbody rb;

	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		float horizontalAxis = Input.GetAxis ("Horizontal");

		moveLeft ();
	}

	private void moveLeft()
	{

	}
}
