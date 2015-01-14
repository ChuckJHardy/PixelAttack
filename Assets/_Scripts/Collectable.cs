using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
	public AudioClip pickupSound;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			Destroy (gameObject);
		}
	}
}
