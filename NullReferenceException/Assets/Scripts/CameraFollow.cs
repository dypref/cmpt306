using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	[SerializeField] private Transform Chumpy;
	[SerializeField] private Vector2 MinCamera;
	[SerializeField] private Vector2 MaxCamera;

	void Start(){
		Chumpy = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}

	void FixedUpdate () {
		transform.position = new Vector3 (
			Mathf.Clamp (Chumpy.position.x, MinCamera.x, MaxCamera.x),
			Mathf.Clamp (Chumpy.position.y, -MinCamera.y, -MaxCamera.y),
			transform.position.z);
	}
}