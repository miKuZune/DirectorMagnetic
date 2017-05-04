﻿using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var pos = Camera.main.WorldToScreenPoint (transform.position);
		var dir = Input.mousePosition - pos;
		var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}
}
