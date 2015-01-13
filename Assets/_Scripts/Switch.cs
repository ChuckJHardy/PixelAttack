using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public Animator animator;

	void Awake () {
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		animator.SetInteger ("AnimationState", 1);
	}

	void OnTriggerExit2D(Collider2D other) {
		animator.SetInteger ("AnimationState", 2);
	}
}
