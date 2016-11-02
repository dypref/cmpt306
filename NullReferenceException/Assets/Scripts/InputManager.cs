using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public ChumpyMovement Chumpy;
	public GameObject Player;

	void Start() {
		// Enable gyro
		Input.gyro.enabled = true;

		// Get Access to Chumpy Movement Script
		Player = GameObject.FindGameObjectWithTag ("Player");
		Chumpy = Player.GetComponent<ChumpyMovement> ();
	}

	void Update(){

		// Let Chumpy jump by tapping on the touch screen
		if (Input.GetMouseButtonDown(0)) {
			Chumpy.Jump ();
		}

		// Let Chumpy move by tilting the phone at any angle
		float initialOrientationX = Input.gyro.rotationRateUnbiased.x;
		float initialOrientationY = Input.gyro.rotationRateUnbiased.y;
		Chumpy.Move (initialOrientationX, initialOrientationY);

	}

}
