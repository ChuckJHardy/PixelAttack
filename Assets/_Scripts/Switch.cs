using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public DoorTrigger[] doorTriggers;

	Animator animator;

	void Awake () {
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		animator.SetInteger ("AnimationState", 1);

		foreach (DoorTrigger doorTrigger in doorTriggers) {
			doorTrigger.door.Open();
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		animator.SetInteger ("AnimationState", 2);

		foreach (DoorTrigger doorTrigger in doorTriggers) {
			doorTrigger.door.Close();
		}
	}
}
