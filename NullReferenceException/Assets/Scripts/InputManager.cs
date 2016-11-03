using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	public ChumpyMovement Chumpy;

	void Start() {
		Chumpy = GetComponent<ChumpyMovement> ();
	}

	void Update(){
		// Let Chumpy jump by tapping on the touch screen
		if (Input.GetMouseButtonDown(0) || Input.GetKey (KeyCode.Space)) {
			Chumpy.Jump ();
		}

		// Let Chumpy move by tilting the phone at any angle
		//float moveX = Input.acceleration.x;
		// PC movement
		float moveX = Input.GetAxis("Horizontal");
		Chumpy.Move (moveX, 0);
	}
}