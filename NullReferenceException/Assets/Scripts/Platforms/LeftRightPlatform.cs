using UnityEngine;
using System.Collections;

public class LeftRightPlatform : MonoBehaviour {

	public float MovingSpeed = 2f;
	public Vector2 Direction = Vector2.right;
	public float Distance = 3f;
	public float StartPosition;

	void Start(){
		StartPosition = transform.position.x;
	}

	void FixedUpdate() {

		var CurrentPosition = transform.position.x;

		if (CurrentPosition > StartPosition + Distance) {
			Direction = -Direction;
		}

		if (CurrentPosition < StartPosition) {
			Direction = Vector2.right;
		}

		transform.Translate (Direction * MovingSpeed * Time.deltaTime);

	}
}
