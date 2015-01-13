using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	public Door door;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			door.Open();
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			door.CloseWithDelay();
		}
	}
}
