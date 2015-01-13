using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	public Door door;
	public bool ignoreTrigger;

	void OnTriggerEnter2D(Collider2D other) {
		if (ignoreTrigger) return;

		if (other.gameObject.tag == "Player") {
			door.Open();
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (ignoreTrigger) return;

		if (other.gameObject.tag == "Player") {
			door.CloseWithDelay();
		}
	}
}
