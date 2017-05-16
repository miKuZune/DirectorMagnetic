using UnityEngine;
using System.Collections;

public class UImanager : MonoBehaviour {

	public Transform PauseScreen;
	public Transform helpScreen;

	void Start(){
		PauseScreen.gameObject.SetActive (false);
		helpScreen.gameObject.SetActive (false);
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.P)) {
			if(PauseScreen.gameObject.activeInHierarchy == false){
				Time.timeScale=0;
				PauseScreen.gameObject.SetActive(true);
			}else{
				Time.timeScale = 1;
				PauseScreen.gameObject.SetActive(false);
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
		PauseScreen.gameObject.SetActive (false);
		Time.timeScale = 1;
	}

	public void HelpScreen(){
		if (helpScreen.gameObject.activeInHierarchy == false) {
			helpScreen.gameObject.SetActive (true);
			PauseScreen.gameObject.SetActive(false);


		} else {
			helpScreen.gameObject.SetActive (false);
			PauseScreen.gameObject.SetActive(true);

		}
	}
}
