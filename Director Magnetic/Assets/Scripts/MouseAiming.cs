using UnityEngine;
using System.Collections;

public class MouseAiming : MonoBehaviour {

	//public float speed = 2000000f;
	//private Quaternion mousePos = Quaternion.Euler(0,0,0);


	public Vector3 mousePos;
	public Vector3 gunPos;
	public float angle;
	
	// Update is called once per frame
	void Update () {
		
		mousePos = Input.mousePosition;
		mousePos.z = 5.23f;

		gunPos = transform.position;
		//gunPos = Camera.main.WorldToViewportPoint (transform.position);
		mousePos.x = mousePos.x - gunPos.x;
		mousePos.y = mousePos.y - gunPos.y;

		float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg * 2 - 400;
		//angle = (mousePos.y - 100) * 0.8f;
		Debug.Log (Screen.width);

		if (mousePos.x < (Screen.width/2)) {
			transform.rotation = Quaternion.Euler (new Vector3 (-angle, 90, 0));
		} else {
			transform.rotation = Quaternion.Euler (new Vector3 (-angle, -90, 0));
		}
	}	
}

//mousePos = Input.mousePosition;
//gunPos = Camera.main.WorldToScreenPoint (transform.position);
//mousePos.x = mousePos.x - gunPos.x;
//mousePos.y = mousePos.y - gunPos.y;
//angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
//transform.rotation = Quaternion.Euler (new Vector3 (-angle, 0, 0));


//float smooth = 2.0f;
//
//Vector3 playerPos = transform.position;
//Vector3 mousePos = Input.mousePosition;
//mousePos.z = -2.348f;
//mousePos = Camera.main.ScreenToWorldPoint (mousePos);
//playerPos = Camera.main.ScreenToWorldPoint (playerPos);
//float yAmount = mousePos.y * 360;
//Quaternion target;
//
//float mousePosX = mousePos.x * mousePos.x;
//mousePosX = checkIfNegative (mousePosX);
//float mousePosY = mousePos.y * mousePos.y;
//mousePosY = checkIfNegative (mousePosY);
//float tempNum = GameObject.FindGameObjectWithTag ("Player").transform.position.x;
//float objectPosX = tempNum * tempNum;
//objectPosX = checkIfNegative (objectPosX);
//tempNum = GameObject.FindGameObjectWithTag ("Player").transform.position.y;
//float objectPosY = tempNum * tempNum;
//objectPosY = checkIfNegative (objectPosY);
//
////Debug.Log (mousePosX + " : " + mousePosY);
//
//float difference = (objectPosX - mousePosX) + (objectPosY - mousePosY);
//difference = Mathf.Sqrt (difference);
//Debug.Log (difference);
//target = Quaternion.Euler (difference*100, 0, 0);
//
//transform.rotation = Quaternion.Slerp(transform.rotation,target,Time.deltaTime * smooth);