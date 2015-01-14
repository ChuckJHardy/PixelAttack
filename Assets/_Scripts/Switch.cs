using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
	public bool sticky;
	public DoorTrigger[] doorTriggers;
	public AudioClip triggerSound;

	Animator animator;
	bool switchActive;

	void Awake () {
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		animator.SetInteger ("AnimationState", 1);
		AudioSource.PlayClipAtPoint(triggerSound, transform.position);

		switchActive = true;

		foreach (DoorTrigger doorTrigger in doorTriggers) {
			doorTrigger.door.Open();
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (sticky && switchActive) return;

		switchActive = false;

		animator.SetInteger ("AnimationState", 2);

		foreach (DoorTrigger doorTrigger in doorTriggers) {
			doorTrigger.door.Close();
		}
	}

	void OnDrawGizmos () {
		Gizmos.color = sticky ? Color.red : Color.green;

		foreach (DoorTrigger doorTrigger in doorTriggers) {
			Gizmos.DrawLine(transform.position, doorTrigger.door.transform.position);
		}
	}
}
