using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	[SerializeField] private bool SpinRight = true;
	[SerializeField] private float Speed = 50f;

	void FixedUpdate () {
		transform.Rotate(Vector3.forward * Time.deltaTime * Speed * ((SpinRight) ? -1 : 1));
	}
}
