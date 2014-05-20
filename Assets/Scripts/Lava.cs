using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

	public ParticleSystem playerExplosion;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			Player player = collider.gameObject.GetComponent<Player>();
            player.die();
		}
	}
}
