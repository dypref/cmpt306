using UnityEngine;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour {
	[SerializeField] private Path path;
	[SerializeField] private float Speed = 3.0f;
	[SerializeField] private float MaxDistanceToGoal = 0.1f;

	private IEnumerator<Transform> _curPoint;

	public void Start(){
		// Need a path to do anything
		if (path == null) {
			return;
		}

		// Get the Enumerator
		_curPoint = path.GetEnumerator ();
		// Get the location of the initial point
		_curPoint.MoveNext ();

		if (_curPoint.Current == null)
			return;

		// Move to the initial point
		transform.position = _curPoint.Current.position;
	}

	public void Update(){
		if (_curPoint == null || _curPoint.Current == null)
			return;

		// Move towards the next point
		transform.position = Vector3.MoveTowards (transform.position, _curPoint.Current.position, Time.deltaTime * Speed);

		// If we reach the destination point, move on to the next
		if ((transform.position - _curPoint.Current.position).sqrMagnitude < MaxDistanceToGoal * MaxDistanceToGoal)
			_curPoint.MoveNext ();
	}

}
