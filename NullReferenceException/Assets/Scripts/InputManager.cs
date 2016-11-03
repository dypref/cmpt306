using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	[SerializeField] private bool KeyboardInput = true;

	public ChumpyMovement Chumpy;

	void Start() {
		Chumpy = GetComponent<ChumpyMovement> ();
	}

	void Update(){
		// Let Chumpy jump by tapping on the touch screen
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown (KeyCode.Space)) {
			Chumpy.Jump ();
		}

		float moveX = (KeyboardInput) ? Input.GetAxis("Horizontal") : Input.acceleration.x;

		Chumpy.Move (moveX, 0);
	}
}