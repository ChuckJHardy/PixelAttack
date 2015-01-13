using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Deadly") OnExplode();
	}

	void OnExplode () {
		Destroy (gameObject);
	}
}
