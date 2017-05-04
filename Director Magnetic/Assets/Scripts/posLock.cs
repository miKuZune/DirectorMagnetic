using UnityEngine;
using System.Collections;

public class posLock : MonoBehaviour {

	Vector3 objectPosition;
	// Use this for initialization
	void Start () {
		objectPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = objectPosition;
	}
}
