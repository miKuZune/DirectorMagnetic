using UnityEngine;
using System.Collections;

public class SpawningScript : MonoBehaviour {

	public Vector3 spawnPos = new Vector3();
    public Vector3 spawnPos2 = new Vector3();
	float counter = 0;
	public Object enemy;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		counter = counter + Time.deltaTime;
		if (counter == 5) {
			Instantiate (enemy, spawnPos, Quaternion.Euler (90, 180, 0));
		}
        else if (counter > 10)
        {
            Instantiate(enemy, spawnPos2, Quaternion.Euler(90, 180, 0));
            counter = 0;
        }
    }
}