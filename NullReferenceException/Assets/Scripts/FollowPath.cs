using UnityEngine;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour {
	[SerializeField] private Path path;
	[SerializeField] private float Speed = 3.0f;

	/*
	 *   If true, the object will change direction when it reaches
	 * the end of the path
	 * 
	 *   If false, the object will teleport back to the first
	 * point in the path.
	 */
	[SerializeField] private bool Bounce = true;

	// Delay when we reach the first/last point
	[SerializeField] private float FreezeDelay = 2.0f;

	private bool _isFrozen = false;
	private float MaxDistanceToGoal = 0.1f;
	private Vector3 _startLocation;
	private Vector3 _endLocation;
	private IEnumerator<Transform> _curPoint;

	public void Start(){
		// Get initial point
		_curPoint = path.GetEnumerator ();
		_curPoint.MoveNext ();

		// Get the start location and move there
		_startLocation = path.GetPoints()[0].position;
		_endLocation = path.GetPoints()[path.GetPoints().Length - 1].position;
		MoveToStart();
	}

	public void Update(){
		// Don't move if paused
		if (_isFrozen) {
			return;
		}

		// Move towards the next point
		transform.position = Vector3.MoveTowards (transform.position, _curPoint.Current.position, Time.deltaTime * Speed);

		// If we reach the destination point, update destination to next point
		if ((transform.position - _curPoint.Current.position).sqrMagnitude < MaxDistanceToGoal * MaxDistanceToGoal) {// If we have reached the beginning or end of the path
			bool _atStartLocation = _curPoint.Current.position.Equals(_startLocation);
			bool _atEndLocation = _curPoint.Current.position.Equals (_endLocation);

			// Freeze if the point we just arrived at is the start or end
			if (_atStartLocation || _atEndLocation) {
				Freeze ();
				// If object is not bouncing, move back to start position
				if(!Bounce && _atEndLocation)
					Invoke("MoveToStart", FreezeDelay);
			}

			_curPoint.MoveNext ();
		}
	}

	// Freeze for the set delay IF there is a delay
	public void Freeze(){
		if (FreezeDelay <= 0.0f)
			return;
		
		_isFrozen = true;
		Invoke ("Unfreeze", FreezeDelay);
	}

	// Unpause the object
	public void Unfreeze(){
		_isFrozen = false;
	}

	// Reset the object to the start position
	public void MoveToStart(){
		transform.position = _startLocation;
	}
}
