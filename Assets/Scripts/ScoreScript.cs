using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public int playerScore;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
		GUILayout.Label (playerScore.ToString());
	}
}
