using UnityEngine;
using System.Collections;

public class RotatePlatform : MonoBehaviour {

	public float Speed = 1f;

	void FixedUpdate () {
		transform.Rotate(0, 0, Speed * Time.deltaTime / 50f);
	}
}
