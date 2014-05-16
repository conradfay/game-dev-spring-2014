using UnityEngine;
using System.Collections;

public class SpeedBoost : MonoBehaviour {

	public Vector2 boostDirection;
	public float boostForce = 1.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D collider) {
		GameObject collidingObject = collider.gameObject;
		if (collidingObject.tag == "Player") {
			// Add force to colliding object.
			collidingObject.rigidbody2D.AddForce(boostDirection * boostForce);
		}
	}
}
