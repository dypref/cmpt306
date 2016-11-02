using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class ChumpyMovement : MonoBehaviour {
	// Movement speed for this unit
	[SerializeField] private float MovementSpeed = 5.0f;
	// Force to be added when this Chumpy jumps
	[SerializeField] private float JumpPower = 100.0f;
	// Mask containing blocks that are considered the ground
	[SerializeField] private LayerMask GroundMask;
	// The location that Chumpy will spawn/respawn at
	[SerializeField] private Transform SceneSpawn;

	private Animator _animator;
	private Rigidbody2D _rb2d;

	private bool _isGrounded;

	void Start(){
		// Instantiate Chumpy's GameObjects
		// _animator = GetComponent<Animator> ();
		_rb2d = GetComponent<Rigidbody2D> ();

		// Move chumpy to the spawn
		Respawn ();
	}

	void Update () {
		// Update if Chumpy is on the ground or not
		_isGrounded = Physics2D.OverlapCircle (GetGroundCheck(), 0.2f, GroundMask);
	}

	void FixedUpdate() {
		HandleMoveInput ();
	}

	/*
	 * Get and execute the players input
	 */
	void HandleMoveInput() {
		float moveX = Input.GetAxis ("Horizontal");

		_rb2d.AddForce (new Vector2 (moveX * MovementSpeed, 0));

		// Jump if chumpy is on the ground
		if (_isGrounded && Input.GetKey (KeyCode.Space))
			_rb2d.AddForce (new Vector2 (0, JumpPower));

	}

	// Jump for InputManager Script on mobile device
	public void Jump() {
		if (_isGrounded)
			_rb2d.AddForce (new Vector2 (0, JumpPower*5));
	}

	// Move for InputManager Script on mobile device
	public void Move(float x, float y) {
		_rb2d.AddForce (new Vector2 (y * MovementSpeed, -x * MovementSpeed));
	}

	void Respawn(){
		// Move to spawn
		_rb2d.position = SceneSpawn.position;
		// Remove all velocity
		_rb2d.velocity = Vector2.zero;
	}

	/*
	 * Calculate the point below Chumpy
	 * (GroundCheck doesn't work because it rotates with Chumpy)
	 */
	Vector2 GetGroundCheck(){
		return new Vector2 (_rb2d.position.x, _rb2d.position.y - 0.5f);
	}
		
}
