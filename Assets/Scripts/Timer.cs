using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float countDownTimer;

	// Update is called once per frame
	void Update () {

	
		countDownTimer -= Time.deltaTime;
		if (countDownTimer < 0) {
			Application.LoadLevel("MainMenu");
		} else {
			Debug.Log (countDownTimer);
		}

	}
}
