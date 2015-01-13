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

	void OnDrawGizmos () {
		Gizmos.color = ignoreTrigger ? Color.grey : Color.green;

		var bc2d = GetComponent<BoxCollider2D> ();
		var bcPos = bc2d.transform.position;
		var newPos = new Vector2 (bcPos.x + bc2d.center.x, bcPos.y + bc2d.center.y);
		var size = new Vector2 (bc2d.size.x, bc2d.size.y);

		Gizmos.DrawWireCube(newPos, size);
	}
}
