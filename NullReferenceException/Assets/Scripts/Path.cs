using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {
	[SerializeField] private Transform[] Points;

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
		// If there's only one point don't do anything
		if (Points == null || Points.Length < 1)
			yield break;

		// Whether or not you are going along
		// for path forwardly or backwards
		int direction = 1;
		// The index of the point the object is moving towards
		int i = 0;

		while (true) {
			// Return next point
			yield return Points[i];

			// If there is only one point don't move
			if (Points.Length == 1)
				continue;

			// Invert the direction when we reach the beginning
			// or end of the point array
			if (i <= 0) {
				direction = 1;
			} else if (i >= Points.Length - 1) {
				direction = -1;
			}

			// Increment to next point
			i += direction;
		}
	}
}
