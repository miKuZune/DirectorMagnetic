using UnityEngine;
using System.Collections;

public class RotaterScript : MonoBehaviour {

	Vector3 mousePos;
	public Transform target;
	Vector3 objectPos;
	float angle;
	
	// Update is called once per frame
	void Update () {
		mousePos = Input.mousePosition;
		mousePos.z = 5.23f;
		objectPos = Camera.main.WorldToScreenPoint (target.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;
		angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
	}
}
