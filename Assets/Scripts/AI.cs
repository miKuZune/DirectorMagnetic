using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {


	public int scoreWorth;
	//Transform playerTransform;
	Transform wallTransform;
	public bool beingPulled = false;
	public bool heldStill = false;
	// Use this for initialization
	void Start () {

		//playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		wallTransform = GameObject.FindGameObjectWithTag ("TrainWall").transform;

	}

	void setRotation(){
		transform.rotation = Quaternion.Euler(0, 0, 0);
	}
		
	
	// Update is called once per frame
	void Update () {
		//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (playerTransform.position - transform.position), 3.0f * Time.deltaTime);

		if (beingPulled == false) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (wallTransform.position - transform.position), 3.0f * Time.deltaTime);
			transform.position += transform.forward * 3.0f * Time.deltaTime;
		}

		setRotation ();

		if (transform.position.y < -20) {
			Debug.Log ("byebye");

			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<ScoreScript> ().playerScore += scoreWorth;
			Destroy (gameObject);

		}
		Vector3 tempPos = Camera.main.WorldToScreenPoint(transform.position);

		if (tempPos.x > Screen.width) {
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<ScoreScript> ().playerScore += scoreWorth;
			Destroy (gameObject);
		} else if (tempPos.x < 0) {
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<ScoreScript> ().playerScore += scoreWorth;
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider coll){
		if (coll.tag == "Floor") {
			Destroy (this);
			Debug.Log ("Destroyed");

			GameObject.FindGameObjectWithTag ("Player").GetComponent<playerController> ().playerScore += scoreWorth;

		}
	}
}
