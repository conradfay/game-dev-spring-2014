using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 100.0f;
	public float jumpForce = 1000.0f;
	public float minJumpFrequency = 5.0f;
	private float lastJump = 0;
    private bool grounded;

	// Use this for initialization
	void Start () {
		// Set player to be ignored by raycasts so that it doesn't
		// get in the way of the isGrounded raycast.
		gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");	
	}
	
	// Update is called once per frame
	void Update () {
        grounded = isGrounded();
	}

    void FixedUpdate()
    {
		// Handle horizontal movement.
		float horizontalMovement = Input.GetAxis("Horizontal");
		Vector2 movementVector = new Vector2(horizontalMovement, 0);
		rigidbody2D.AddForce(movementVector * speed);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
		// Handle jumping.
		if (Input.GetButton("Jump")) {
			jump();
		}
    }

	private void jump() {
        // Restrict jumping to minJumpFrequency.
        if (Time.time - lastJump > 1 / minJumpFrequency) {
            // Jump only if player is on the ground.
            if (grounded) {
                //Debug.Log("jumping");
                //Debug.Log("" + (Time.time - lastJump) + " : " + (1 / minJumpFrequency));
				lastJump = Time.time;
				rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
			}
		}
	}

	// Check if player is touching the ground.
	private bool isGrounded() {
		// Distance from the center of the player to the bottom of the player.
		float distToFeet = GetComponent<CircleCollider2D>().radius * transform.localScale.y;
		// Vector from the center of the player to the right-hand side of the player.
		Vector3 vectorToRight = new Vector3(distToFeet, 0, 0);
		const float raycastLength = 0.05f;
		Debug.DrawRay(transform.position, -Vector2.up * distToFeet, Color.yellow);
		Debug.DrawRay(transform.position + vectorToRight, -Vector2.up * distToFeet, Color.yellow, 0.1f);
		Debug.DrawRay(transform.position - vectorToRight, -Vector2.up * distToFeet, Color.yellow, 0.1f);
		// Check if any of three rays makes contact with an object:
		// A ray from the bottom of the player down,
		// A ray from the bottom-right of the player down,
		// A ray from the bottom-left of the player down.
		if (Physics2D.Raycast(transform.position, -Vector2.up, distToFeet + raycastLength))
			return true;
		else if (Physics2D.Raycast(transform.position + vectorToRight, -Vector2.up, distToFeet + raycastLength))
			return true;
		else if (Physics2D.Raycast(transform.position - vectorToRight, -Vector2.up, distToFeet + raycastLength))
			return true;
		return false;
	}
}
