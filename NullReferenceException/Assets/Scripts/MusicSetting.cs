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

	// For Setting scene to turn on/off music and sound effects
	public void MusicToggle() {
		
		if(AudioListener.volume == (float)(int)MusicState.On) {
			AudioListener.volume = (float)(int)MusicState.Off;
			GetComponent<Image> ().sprite = MusicOff;
		}
		else if(AudioListener.volume == (float)(int)MusicState.Off) {
			AudioListener.volume = (float)(int)MusicState.On;
			GetComponent<Image> ().sprite = MusicOn;
		}
	}
}
