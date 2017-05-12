using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {

	public float MoveSpeed;
	float magnetCharge;
	public float magnetChargeIncrease;
	public GameObject lastMagnet;
	bool seesMagnet = false;
	bool goingRight = false;
	Vector3 seenMagentPos = new Vector3(0,0,0);
	Rigidbody magnetRB;


	void magnetism(){
		if (Input.GetMouseButton(0) && seesMagnet == true) {
			float distanceFromPlayer;
			distanceFromPlayer = transform.position.x - lastMagnet.transform.position.x;
			
			if (distanceFromPlayer < 0) {
				distanceFromPlayer = -distanceFromPlayer;
			}
			
			if (distanceFromPlayer > 1.0f) {
				transform.position = Vector3.MoveTowards (transform.position, seenMagentPos, 0.5f);
			} 
		}
		
		if (Input.GetKey("e") && seesMagnet == true) {
			
			float distanceFromPlayer;
			distanceFromPlayer = transform.position.x - lastMagnet.transform.position.x;
			lastMagnet.GetComponent<AI> ().beingPulled = true;
			if (distanceFromPlayer < 0) {
				distanceFromPlayer = -distanceFromPlayer;
			}
			
			if (distanceFromPlayer > 3.5f) {
				lastMagnet.transform.position = Vector3.MoveTowards (seenMagentPos, transform.position, 0.5f);
			} else {
				lastMagnet.transform.position = seenMagentPos;
				lastMagnet.GetComponent<AI> ().heldStill = true;
			}
			
			if (lastMagnet.GetComponent<AI> ().heldStill == true) {
				Vector3 tempPos = GameObject.FindGameObjectWithTag ("MagnetHolder").transform.position;
				lastMagnet.transform.position = tempPos;
			}
			
			magnetCharge += magnetChargeIncrease;
			
		}
		
		if (Input.GetKeyUp("e") && seesMagnet == true) {
			float tempVal = 0;
			if (magnetCharge > 20.0f) {
				lastMagnet.GetComponent<CapsuleCollider>().enabled = false;
				if (goingRight) {
					tempVal = 50.0f;
				} else {
					tempVal = -50.0f;
				}
			} else {
				tempVal = 0f;
			}
			magnetRB.velocity = new Vector3(-tempVal,magnetCharge,0);
			magnetCharge = 0.0f;
			lastMagnet.GetComponent<AI> ().beingPulled = false;
		}
	}
	
	void playerMove(){
		float tempMove;
		if (Input.GetKey (KeyCode.D)) {
			tempMove = MoveSpeed;
			goingRight = true;
		} else if (Input.GetKey (KeyCode.A)) {
			tempMove = -MoveSpeed;
			goingRight = false;
		} else {
			tempMove = 0;
		}

		gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (tempMove,gameObject.GetComponent<Rigidbody>().velocity.y,0);
	}

	// Update is called once per frame
	void Update () {
		playerMove ();
		magnetism ();
	}

	void OnTriggerStay(Collider coll){
		if (coll.tag == "Magnetic") {
			seesMagnet = true;
			lastMagnet = coll.gameObject;
			seenMagentPos = coll.transform.position;
			magnetRB = coll.gameObject.GetComponent<Rigidbody> ();
		}
	}
	void OnTriggerExit(Collider coll){
		seesMagnet = false;
		lastMagnet.GetComponent<AI> ().beingPulled = false;
		lastMagnet.GetComponent<AI> ().heldStill = false;
	}
}
