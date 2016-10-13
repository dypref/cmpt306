using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {
	[SerializeField] private Transform[] Points;
	private bool Bounce = true;

	public void OnDrawGizmos(){
		// Can't draw a line without two points
		if (Points == null || Points.Length < 2)
			return;

		// Draw lines between the points
		for (int i = 0; i < Points.Length-1; i++) {
			Gizmos.DrawLine (Points [i].position, Points [i + 1].position);
		}
	}

	public IEnumerator<Transform> GetEnumerator(){
		if (Points == null || Points.Length < 1)
			yield break;

		// Direction moving through points
		int direction = 1;
		// index of current point
		int i = 0;

		while (true) {
			yield return Points[i];

			// Special Case
			if (Points.Length == 1) {
				continue;
			}

			// If I reach the first point
			if (i <= 0) {
				direction = 1;
			} else if (i >= Points.Length - 1) {
				if (Bounce) {
					direction = -1;
				} else {
					i = 0;
				}
			}

			// Increment to next point
			i += direction;
		}
	}

	public void SetBounce(bool _bounce){
		Bounce = _bounce;
	}

	public Transform[] GetPoints(){
		return Points;
	}
}
