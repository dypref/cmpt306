using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class SwipeHandler : MonoBehaviour {

	// swipe distance and tolerance 
	private float swipeDistance = 0;
	private float swipeStandard = 20f;
	
	// initial values
	private Vector3 initialPosition = Vector3.zero;
	private float fingerX = 0;
	private float fingerY = 0;

	// adjacent sceces 
	public String leftScene;
	public String rightScene;

//	void Awake() {
//		DontDestroyOnLoad (gameObject);
//	}

	void Update() {
		
		if (Input.GetMouseButtonDown(0)) {
			initialPosition = Input.mousePosition;

		// get swipe distance and direction
		} else if (Input.GetMouseButton(0)) {
			fingerX = initialPosition.x - Input.mousePosition.x;
			fingerY = initialPosition.y - Input.mousePosition.y;
			swipeDistance = Mathf.Sqrt(Mathf.Pow(fingerX, 2) + Mathf.Pow(fingerY, 2));
		
		// swipe to different scene according to the result above
		} else if (Input.GetMouseButtonUp(0)) {
			if (swipeDistance > swipeStandard) {
				if (fingerX > 0 && this.rightScene != null) {
					SceneManager.LoadScene (rightScene);
				} else if (fingerX < 0 && this.leftScene != null) {
					SceneManager.LoadScene (leftScene);
				}
			}

			// reset value back
			fingerX = 0;
			fingerY = 0;
			initialPosition = Vector3.zero;
		}
	}

}
