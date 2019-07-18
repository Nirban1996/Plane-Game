using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour {

	public float speed;
	public float turnSpeed;

	void FixedUpdate()
	{
		transform.Translate (0, speed*Time.deltaTime, 0);
		HandleRotation ();
	}

	private void HandleRotation()
	{
		float hor = Input.GetAxis ("Horizontal");

		transform.Rotate (0, 0, -hor*turnSpeed);
			
	}
}
