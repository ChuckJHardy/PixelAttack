using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D other) {
		Destroy(gameObject);
	}
}
