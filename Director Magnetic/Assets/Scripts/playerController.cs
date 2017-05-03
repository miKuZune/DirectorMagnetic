using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	bool seesMagnet = false;
	Vector3 seenMagentPos = new Vector3(0,0,0);
	public float startMagnetSpeed;
	public float speed = 10.0f;
	public GameObject lastMagnet;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update () {
		float translation = Input.GetAxis("Vertical") * speed;
		float straffe = Input.GetAxis("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;
		
		transform.Translate (straffe, 0, translation);
		
		if(Input.GetKeyDown("escape"))
			Application.Quit();
		
		if (Input.GetMouseButton(0) && seesMagnet == true) {
			transform.position = Vector3.MoveTowards (transform.position,seenMagentPos, 0.5f);
		}

		if (Input.GetMouseButton(1) && seesMagnet == true) {
			lastMagnet.transform.position = Vector3.MoveTowards(seenMagentPos,transform.position,0.5f);
			Debug.Log("Hell");
		}

		if (Input.GetKey ("e")) {
			lastMagnet.transform.position = Vector3.MoveTowards(seenMagentPos,transform.position,-0.5f);
		}

		Debug.Log (seesMagnet);
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
