using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour {

	public Transform plane;
	public float speed, turnSpeed;
	public GameObject blast;

	
	// Update is called once per frame
	void Update () {
		if(!GameManager.Instance.gameOver)
		if (plane == null )
			plane = GameObject.FindGameObjectWithTag ("Player").transform;

	}

	public Vector3 dir;
	public float dr;
	void FixedUpdate()
	{
		transform.Translate (speed * Time.deltaTime, 0 , 0);

		if(!GameManager.Instance.gameOver)
		if (plane != null) {
			dir = plane.transform.position - transform.position;
			dr = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(dr, Vector3.forward);
			transform.rotation = Quaternion.Lerp (transform.rotation, rotation, turnSpeed * Time.deltaTime);


		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		Instantiate (blast, transform.position, transform.rotation);

		if (col.tag == "Player") {
			Destroy (col.gameObject);
			GameManager.Instance.gameOver = true;
		}
        else
        {
            Destroy(col.gameObject);
            GameManager.Instance.IncrementScore();
        }
		GameManager.Instance.numberOfMissiles--;
		Destroy (gameObject);
	}

}
