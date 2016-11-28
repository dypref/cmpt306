using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {

	// Exit the game, for the back button on the android phone
	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			doExitGame ();
		}
	}

	// Exit the game, for the exit button on the main menu
	public void doExitGame() {
		Application.Quit();
	}

}
