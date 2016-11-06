using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	
	[SerializeField] private bool KeyboardInput = true;

	private ChumpyMovement Chumpy;

	void Start() {
		Chumpy = GetComponent<ChumpyMovement> ();
	}

	void Update(){
		// Let Chumpy jump by tapping on the touch screen or pressing space bar
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown (KeyCode.Space)) {
			Chumpy.Jump ();
		}

		// Let Chumpy move by taking input from the keyboard or the device
		float moveX = (KeyboardInput) ? Input.GetAxis("Horizontal") : Input.acceleration.x;

		Chumpy.Move (moveX, 0);
	}
}