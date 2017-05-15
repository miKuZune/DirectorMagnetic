using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public int playerScore;
    Transform scoreScreen;
	// Use this for initialization
	void Start () {
        scoreScreen = GameObject.FindGameObjectWithTag("ScoreScreen").transform;
        Debug.Log(scoreScreen.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
       Vector3 tempVector = Camera.main.WorldToScreenPoint(scoreScreen.position);
        
        GUI.Label(new Rect(tempVector.x,tempVector.y+425, 100, 20),"" + playerScore);
	}
}
