﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestroyObject", 4);
	}
	
	void DestroyObject()
	{
		Destroy (gameObject);
	}
}
