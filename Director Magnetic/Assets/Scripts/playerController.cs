using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	bool seesMagnet = false;
	Vector3 seenMagentPos = new Vector3(0,0,0);
	public float startMagnetSpeed;
	public float speed = 10.0f;
	public GameObject lastMagnet;
	public float magnetCharge;
	public float magnetChargeIncrease;
	bool goingRight;

	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;
	// Use this for initialization

	Rigidbody magnetRB;

	public float moveSpeed;

	public int playerScore;
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
		

	void playerMove(){
		if (Input.GetKey ("d")) {
			transform.Translate (new Vector3 (0, 0, moveSpeed));
			transform.localRotation = Quaternion.AngleAxis (-90, transform.up);
			goingRight = true;
		}
		if (Input.GetKey ("a")) {
			transform.Translate (new Vector3 (0, 0, moveSpeed));
			transform.localRotation = Quaternion.AngleAxis (90, transform.up);
			goingRight = false;
		}

	}

	void magnetism(){
		if(Input.GetKeyDown("escape"))
			Application.Quit();

		if (Input.GetMouseButton(0) && seesMagnet == true) {
			float distanceFromPlayer;
			distanceFromPlayer = transform.position.x - lastMagnet.transform.position.x;

			if (distanceFromPlayer < 0) {
				distanceFromPlayer = -distanceFromPlayer;
			}

			if (distanceFromPlayer > 1.0f) {
				transform.position = Vector3.MoveTowards (transform.position, seenMagentPos, 0.5f);
			} else {

			}
			Debug.Log (distanceFromPlayer);
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

				Debug.Log (distanceFromPlayer);
			} else {
				lastMagnet.transform.position = seenMagentPos;
			}

			magnetCharge += magnetChargeIncrease;
		}

		if (Input.GetKeyUp("e") && seesMagnet == true) {
			float tempVal = 0;
			if (magnetCharge > 20.0f) {
				if (goingRight) {
					tempVal = 50.0f;
				} else {
					tempVal = -50.0f;
				}
			} else {
				tempVal = 0f;
			}
			magnetRB.velocity = new Vector3(-tempVal,magnetCharge,0);
			Debug.Log (magnetCharge);
			magnetCharge = 0.0f;
			lastMagnet.GetComponent<AI> ().beingPulled = false;
		}
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
	}
}