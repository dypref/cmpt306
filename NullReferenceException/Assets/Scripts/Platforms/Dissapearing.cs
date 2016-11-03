using UnityEngine;
using System.Collections;

public class Dissapearing : MonoBehaviour {
	[SerializeField] private float DissapearAfter = 2.0f;

	private bool _dissapearing;

	void Start(){
		_dissapearing = false;
	}

	void OnCollisionEnter2D(Collision2D other){
		if (!_dissapearing && other.gameObject.CompareTag ("Player")) {
			_dissapearing = true;
			Invoke ("DestroyThis", DissapearAfter);
		}
	}

	void DestroyThis(){
		Destroy (gameObject);
	}
}
