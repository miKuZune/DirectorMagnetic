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
		//Cursor.lockState = CursorLockMode.Locked;
	}

	public void LoadScene(int level)
	{
		LoadScene (level);
	}
		

	void playerMove(){

		float move;
		if (Input.GetKey(KeyCode.D)) {
			move = moveSpeed;
			goingRight = true;
		}else if (Input.GetKey ("a")) {
			move = -moveSpeed;
			goingRight = false;
		} else {
			move = 0;
		}
		gameObject.GetComponent<Rigidbody> ().velocity = new Vector3(move,gameObject.GetComponent<Rigidbody>().velocity.y,0);

	}

	void magnetism(){
		

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
				//lastMagnet.transform.rotation = GameObject.FindGameObjectWithTag ("MagnetRotate").transform.rotation;
				lastMagnet.transform.position = tempPos;
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
			lastMagnet.GetComponent<CapsuleCollider> ().enabled = false;
			magnetRB.velocity = new Vector3(-tempVal,magnetCharge,0);
			magnetCharge = 0.0f;
			lastMagnet.GetComponent<AI> ().beingPulled = false;
		}
	}

	// Update is called once per frame
	void Update () {
		//if(Input.GetKeyDown("escape"))
		//	Application.Quit();

		if(Input.GetKeyDown("p")){
			LoadScene(0);
		}
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