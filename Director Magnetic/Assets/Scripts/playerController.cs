using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	bool seesMagnet = false;
	Vector3 seenMagentPos = new Vector3(0,0,0);
	public float startMagnetSpeed;
	public float speed = 10.0f;
	public GameObject lastMagnet;

	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;
	// Use this for initialization

	public float moveSpeed;

	public int playerScore;
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;

	}
		

	void playerMove(){
		if (Input.GetKey ("d")) {
			transform.Translate (new Vector3 (0, 0, moveSpeed));
			transform.localRotation = Quaternion.AngleAxis (-90, transform.up);
		}
		if (Input.GetKey ("a")) {
			transform.Translate (new Vector3 (0, 0, moveSpeed));
			transform.localRotation = Quaternion.AngleAxis (90, transform.up);
		}

	}

	void magnetism(){
		if(Input.GetKeyDown("escape"))
			Application.Quit();

		if (Input.GetMouseButton(0) && seesMagnet == true) {
			transform.position = Vector3.MoveTowards (transform.position,seenMagentPos, 0.5f);
		}

		if (Input.GetMouseButton(1) && seesMagnet == true) {
			lastMagnet.transform.position = Vector3.MoveTowards(seenMagentPos,transform.position,0.5f);
			Debug.Log("Hell");
		}

		if (Input.GetKey ("e") && seesMagnet == true) {
			lastMagnet.transform.position = Vector3.MoveTowards(seenMagentPos,transform.position,-0.5f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		
		playerMove ();
		magnetism ();
		Debug.Log (playerScore);
	}
	
	void OnTriggerStay(Collider coll){
		if (coll.tag == "Magnetic") {
			seesMagnet = true;
			lastMagnet = coll.gameObject;
			seenMagentPos = coll.transform.position;
		}
	}
	void OnTriggerExit(Collider coll){
		seesMagnet = false;
	}
}
