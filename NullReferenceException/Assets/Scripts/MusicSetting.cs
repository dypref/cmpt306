using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour {

	// Music icons for on and off
	[SerializeField]
	public Sprite MusicOn;
	[SerializeField] 
	public Sprite MusicOff;

	// Two states for music setting: on and off
	private enum MusicState {
		Off,
		On
	};

	// Load corresponding image for initial state
	void Start() {

		if (PlayerPrefs.GetInt("Music") == (int)MusicState.On) {
			TurnOnMusic ();

		} else {
			TurnOffMusic ();
		}

	}

	// For Setting scene to flip music state
	public void MusicToggle() {
		
		if (PlayerPrefs.GetInt("Music") == (int)MusicState.On) {
			TurnOffMusic ();

		} else {
			TurnOnMusic ();
		}

	}

	public void TurnOnMusic() {
		AudioListener.volume = (float)(int)MusicState.On;
		PlayerPrefs.SetInt ("Music", (int)MusicState.On);
		GetComponent<Image> ().sprite = MusicOn;
	}

	public void TurnOffMusic() {
		AudioListener.volume = (float)(int)MusicState.Off;
		PlayerPrefs.SetInt ("Music", (int)MusicState.Off);
		GetComponent<Image> ().sprite = MusicOff;
	}

}
