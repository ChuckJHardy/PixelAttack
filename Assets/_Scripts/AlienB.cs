using UnityEngine;
using System.Collections;

public class AlienB : MonoBehaviour {
	private Animator animator;

	void Awake () {
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		animator.SetInteger("AnimationState", 1);
	}
}
