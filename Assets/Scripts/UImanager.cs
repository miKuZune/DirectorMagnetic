using UnityEngine;
using System.Collections;

public class UImanager : MonoBehaviour {

	public Transform canvas;

	void Start(){
		canvas.gameObject.SetActive (false);
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.P)) {
			if(canvas.gameObject.activeInHierarchy == false){
				Time.timeScale=0;
				canvas.gameObject.SetActive(true);
			}else{
				Time.timeScale = 1;
				canvas.gameObject.SetActive(false);
			}
		}
	}

	public void OnStartGame(){
		Application.LoadLevel("Level1");
		Time.timeScale = 1;
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void GoToMainMenu(){
		Application.LoadLevel("MainMenu");
	}

	public void ResumeGame(){
		canvas.gameObject.SetActive (false);
		Time.timeScale = 1;
	}
}
