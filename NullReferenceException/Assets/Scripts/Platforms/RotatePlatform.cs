using UnityEngine;
using System.Collections;

public class RotatePlatform : MonoBehaviour {

	public float Speed = 50f;

	void FixedUpdate () {
		transform.Rotate(Vector3.forward * Time.deltaTime * Speed);
	}
}
