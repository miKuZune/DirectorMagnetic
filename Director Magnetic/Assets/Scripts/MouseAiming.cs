using UnityEngine;
using System.Collections;

public class MouseAiming : MonoBehaviour {

	public GameObject charcter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Input.mousePosition;

		float characterXPos = charcter.transform.position.x;
		float xPos;
		if (characterXPos > mousePos.x) {
			xPos = 100;
		} else {
			xPos = -100;
		}

		transform.eulerAngles = new Vector3 (mousePos.y, xPos, 0);

	}
}
