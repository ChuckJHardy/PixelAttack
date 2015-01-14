using UnityEngine;
using System.Collections;

public class AlienB : MonoBehaviour {
	public AudioClip attackSound;

	Animator animator;
	bool readyToAttack;

	void Awake () {
		animator = GetComponent<Animator>();
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			if (readyToAttack) {
				var explode = other.GetComponent<Explode> () as Explode;
				explode.OnExplode();
			} else {
				animator.SetInteger("AnimationState", 1);
				AudioSource.PlayClipAtPoint(attackSound, transform.position);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		readyToAttack = false;
		animator.SetInteger("AnimationState", 0);
	}

	void Attack() {
		readyToAttack = true;
	}
}
