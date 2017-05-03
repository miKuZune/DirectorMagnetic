using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	//Transform playerTransform;
	Transform wallTransform;
	// Use this for initialization
	void Start () {

		//playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		wallTransform = GameObject.FindGameObjectWithTag ("TrainWall").transform;

	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (playerTransform.position - transform.position), 3.0f * Time.deltaTime);
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (wallTransform.position - transform.position), 3.0f * Time.deltaTime);
		transform.position += transform.forward * 3.0f * Time.deltaTime;
	}
}
