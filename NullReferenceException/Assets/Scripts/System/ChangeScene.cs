using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public string nextLevel;
	public string theme;

	// It is used for entering the next level
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			SceneManager.LoadScene (nextLevel);
		}
	}

	// Reload current level
	public void ReloadCurrentLevel() {
		Scene scene = SceneManager.GetActiveScene(); 
		SceneManager.LoadScene(scene.name);
	}
	
	// Back to 10 level select scene
	void BackToSceneSelect() {
		SceneManager.LoadScene (theme.ToString());
	}
	
}
