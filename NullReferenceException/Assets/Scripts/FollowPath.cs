using UnityEngine;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour {
	[SerializeField] private Path path;
	[SerializeField] private float Speed = 3.0f;
	[SerializeField] private float MaxDistanceToGoal = 0.1f;

	private IEnumerator<Transform> _curPoint;

	public void Start(){
		if (path == null) {
			return;
		}

		_curPoint = path.GetEnumerator ();
		_curPoint.MoveNext ();

		if (_curPoint.Current == null)
			return;

		transform.position = _curPoint.Current.position;
	}

	public void Update(){
		if (_curPoint == null || _curPoint.Current == null)
			return;

		transform.position = Vector3.MoveTowards (transform.position, _curPoint.Current.position, Time.deltaTime * Speed);

		if ((transform.position - _curPoint.Current.position).sqrMagnitude < MaxDistanceToGoal * MaxDistanceToGoal)
			_curPoint.MoveNext ();
	}

}
