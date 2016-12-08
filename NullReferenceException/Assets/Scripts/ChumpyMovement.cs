using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChumpyMovement : MonoBehaviour {
	// Movement speed for this unit
	[SerializeField] private float MovementSpeed = 5.0f;
	// Force to be added when this Chumpy jumps
	[SerializeField] private float JumpPower = 100.0f;
	// Water movement reduction
	[SerializeField] private float WaterModifier = 0.6f;
	// Mask containing blocks that are considered the ground
	[SerializeField] private LayerMask GroundMask;
	// The sound that Chumpy make when it jumps
	[SerializeField] private AudioClip JumpSound;
	// The sound plays when Chumpy gets a coin
	[SerializeField] private AudioClip ItemGetSound;

	private Rigidbody2D _rb2d;
	private bool _isGrounded;
    private bool _canJump;

	void Start() {
		// Instantiate Chumpy's GameObjects
		_rb2d = GetComponent<Rigidbody2D> ();
		_canJump = true;
	}

	void Update () {
		// Update if Chumpy is on the ground or not
		_isGrounded = Physics2D.OverlapCircle (GetGroundCheck(), 0.2f, GroundMask);
	}

	public void Move(float x, float y) {
		Vector2 movement = new Vector2(x * MovementSpeed, _rb2d.velocity.y);

		if (Physics2D.OverlapCircle (transform.position, 0.2f).CompareTag ("Water"))
			movement.x = movement.x * WaterModifier;
		
		_rb2d.velocity = movement;

	}

	// Jump for InputManager Script on mobile device
	public void Jump() {
		if (_isGrounded && _canJump) {
			_rb2d.AddForce (new Vector2 (_rb2d.velocity.x, JumpPower));
			AudioSource.PlayClipAtPoint(JumpSound, transform.localPosition);
		}
	}

	void Respawn() {

		//Reloads current scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Respawn"))
			Respawn ();

        if (other.CompareTag("Water"))
            _canJump = false;
        else
            _canJump = true;
            


		// The number of coins is increased by one, 
		// and the coin will disappear when Chumpy touches a coin
		if (other.CompareTag("Coin")) {

			// Play the item get sound
			AudioSource.PlayClipAtPoint(ItemGetSound, transform.localPosition);

			// Increase the count of coins
			GameManager.CoinCount += 1;

			// Destroy the coin that got by Chumpy
			Destroy (other.gameObject);

		}
	}

	// Calculate the point below Chumpy
	Vector2 GetGroundCheck() {
		return new Vector2 (_rb2d.position.x, _rb2d.position.y - 0.5f);;
	}
		
}
