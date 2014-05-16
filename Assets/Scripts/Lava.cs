using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

	public ParticleSystem playerExplosion;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			GameObject player = collider.gameObject;
			GameObject.Instantiate(playerExplosion, player.transform.position, player.transform.rotation);
			Destroy(player);
		}
	}
}
