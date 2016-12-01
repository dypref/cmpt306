using UnityEngine;
using System.Collections;

public class UpDownPlatform : MonoBehaviour {

	public float MovingSpeed = 2f;
	public Vector2 Direction = Vector2.up;
	public float Distance = 3f;
	public float StartPosition;


	void Start(){
		StartPosition = transform.position.y;

	}

	void FixedUpdate() {
		if (transform.parent != null)
			return;

		var CurrentPosition = transform.position.y;

		if (CurrentPosition < StartPosition - Distance) {
			Direction = -Direction;
		}

		if (CurrentPosition > StartPosition) {
			Direction = Vector2.down;
		}

		transform.Translate (Direction * MovingSpeed * Time.deltaTime);

	}



}
