using UnityEngine;
using System.Collections;

public class Buoyancy : MonoBehaviour {

	public float fluidDensity = 1.0f;
	public float fluidDrag = 15.0f;
	private bool inFluid = false;
	private float fluidArea;
	private float surfaceHeight;

	void OnTriggerEnter2D(Collider2D collider) {
		// Since the fluid is the only trigger on the map, we just assume that this object is in water.
		inFluid = true;
		BoxCollider2D fluidCollider = collider.gameObject.GetComponent<BoxCollider2D>();
		surfaceHeight = fluidCollider.transform.position.y + fluidCollider.transform.localScale.y * fluidCollider.size.y / 2;
		rigidbody2D.drag = fluidDrag;
		fluidArea = fluidCollider.transform.localScale.x * fluidCollider.size.x *
			fluidCollider.transform.localScale.y * fluidCollider.size.y;
	}
	
	void OnTriggerExit2D(Collider2D collider) {
		inFluid = false;
		rigidbody2D.drag = 0.05f;
	}

	void FixedUpdate() {
		if(inFluid) {
			// Calculate buoyant force Fb.
			float height = surfaceHeight - transform.position.y + transform.localScale.y / 2;
			float Fb = rigidbody2D.gravityScale * fluidDensity * height * fluidArea;
			this.rigidbody2D.AddForce(new Vector2(0, Fb));
		}
	}
}
