using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform plane;

	public float followSpeed;

	private Vector3 pos;
	// Update is called once per frame
	void LateUpdate () {
		if (plane != null) {
			pos = new Vector3 (plane.position.x, plane.position.y, transform.position.z);

			transform.position = Vector3.Lerp (transform.position, pos, followSpeed);
		}
	}
}
