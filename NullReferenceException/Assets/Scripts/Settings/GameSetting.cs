using UnityEngine;
using System.Collections;

public class GameSetting : MonoBehaviour {

	// For saving music setting data
	public static int isMusicOn;

	void Start() {
		
		// Load data if it is not the first time loading
		if (PlayerPrefs.HasKey("Music")) {
			isMusicOn = PlayerPrefs.GetInt("Music");

		// Initialize music on if this is the first time
		} else {
			PlayerPrefs.SetInt ("Music", 1);
			isMusicOn = 1;
		}

	}

	void OnApplicationPause(bool pauseStatus) {
		PlayerPrefs.Save ();
	}

	void OnApplicationQuit() {
		PlayerPrefs.Save ();
	}

}
