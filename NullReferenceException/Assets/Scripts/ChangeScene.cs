using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public string SceneName;

	// Move to the named scene
	// It is used for entering the next level
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			SceneManager.LoadScene (SceneName);
		}
	}
}
