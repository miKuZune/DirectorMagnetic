using UnityEngine;
using System.Collections;

public class SpawningScript : MonoBehaviour {

	public Vector3 spawnPos = new Vector3(25,20,-2.71f);
	float counter = 0;
	public Object enemy;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		counter = counter + Time.deltaTime;
		if (counter > 5) {
			Instantiate (enemy, spawnPos, Quaternion.Euler (90, 180, 0));
			counter = 0;
		}
	}
}