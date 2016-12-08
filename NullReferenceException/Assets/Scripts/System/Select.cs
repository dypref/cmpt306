using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour {

    public void LoadScene(string SceneName) {
        SceneManager.LoadScene(SceneName);
    }

    public void ReloadScene() {
        LoadScene(SceneManager.GetActiveScene().name);
    }
}
