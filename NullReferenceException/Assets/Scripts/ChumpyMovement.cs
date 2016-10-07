using UnityEngine;
using System.Collections;

public class ChumpyMovement : MonoBehaviour {
	[SerializeField] private float MovementSpeed = 5.0f;
	[SerializeField] private float JumpPower = 100.0f;
	[SerializeField] private LayerMask GroundMask;
	[SerializeField] private Transform SceneSpawn;

	private Animator _animator;
	private Rigidbody2D _rb2d;

	private bool _isGrounded;

	void Start(){
		_animator = GetComponent<Animator> ();
		_rb2d = GetComponent<Rigidbody2D> ();

		Respawn ();
	}

	void Update () {
		_isGrounded = Physics2D.OverlapCircle (GetGroundCheck(), 0.2f, GroundMask);
	}

	void FixedUpdate() {
		HandleMoveInput ();
	}

	void HandleMoveInput() {
		float moveX = Input.GetAxis ("Horizontal");

		_rb2d.AddForce (new Vector2 (moveX * MovementSpeed, 0));

		if (_isGrounded && Input.GetKey (KeyCode.Space))
			_rb2d.AddForce (new Vector2 (0, JumpPower));
	}

	void Respawn(){
		_rb2d.position = SceneSpawn.position;
		_rb2d.velocity = Vector2.zero;
	}

	Vector2 GetGroundCheck(){
		return new Vector2 (_rb2d.position.x, _rb2d.position.y - 0.5f);
	}
}
