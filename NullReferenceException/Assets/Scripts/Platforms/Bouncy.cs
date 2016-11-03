using UnityEngine;
using System.Collections;

public class Bouncy : MonoBehaviour {
	[SerializeField] private float BounceForce = 100.0f;

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("Player")){
			other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, BounceForce));
		}
	}
}
