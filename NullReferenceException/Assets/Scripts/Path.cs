using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {
	[SerializeField] private Transform[] Points;

	public void OnDrawGizmos(){
		if (Points == null || Points.Length < 2)
			return;

		for (int i = 0; i < Points.Length-1; i++) {
			Gizmos.DrawLine (Points [i].position, Points [i + 1].position);
		}
	}

	public IEnumerator<Transform> GetEnumerator(){
		if (Points == null || Points.Length < 1)
			yield break;

		int direction = 1;
		int i = 0;

		while (true) {
			yield return Points[i];

			if (Points.Length == 1)
				continue;

			if (i <= 0) {
				direction = 1;
			} else if (i >= Points.Length - 1) {
				direction = -1;
			}

			i += direction;
		}
	}
}
