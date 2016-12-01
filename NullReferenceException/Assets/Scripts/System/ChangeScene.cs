using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	// For right navigation
    public string sceneName;
    public string currentLevel;
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
	public void BackToSceneSelect() {
		SceneManager.LoadScene (theme.ToString());
	}
	
	public void goCurrentLevel() {
		SceneManager.LoadScene(this.sceneName.ToString());
	}

    public void goNextLevel() {
        SceneManager.LoadScene(this.nextLevel.ToString());
    }

    public void goSelectionMenu() {
        SceneManager.LoadScene(this.theme.ToString());
    }
	
}
