using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 10f;
	public float jetSpeed = 15f;
	public Vector2 maxVelocity = new Vector2 (3, 5);
	public float airSpeedMultiplier = 0.3f;

	public AudioClip leftFootSound;
	public AudioClip rightFootSound;
	public AudioClip thudSound;
	public AudioClip rocketSound;

	Animator animator;
	PlayerController controller;
	bool standing;

	void Start () {
		controller = GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}

	void Update () {
		float forceX = 0f;
		float forceY = 0f;

		float absVelocityX = Mathf.Abs(rigidbody2D.velocity.x);
		float absVelocityY = Mathf.Abs(rigidbody2D.velocity.y);

		if (absVelocityY < 0.2f) {
			standing = true;
		} else {
			standing = false;
		}

		if (controller.moving.x != 0) {
			if (absVelocityX < maxVelocity.x) {
				forceX = standing ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);

	 			transform.localScale = new Vector3 (forceX > 0 ? 1 : -1, 1, 1);
			}

			animator.SetInteger ("AnimationState", 1);
		} else {
			animator.SetInteger ("AnimationState", 0);
		}

		if (controller.moving.y > 0) {
			PlayRocketSound();
			
			if (absVelocityY < maxVelocity.y) {
				forceY = jetSpeed * controller.moving.y;
			}

			animator.SetInteger ("AnimationState", 2);
		} else if (absVelocityY > 0) {
			animator.SetInteger ("AnimationState", 3);
		}

		rigidbody2D.AddForce(new Vector2 (forceX, forceY));
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (!standing) {
			var absVelX = Mathf.Abs(rigidbody2D.velocity.x);
			var absVelY = Mathf.Abs(rigidbody2D.velocity.y);

			if (absVelX <= 0.1f || absVelY <= 0.1f) {
				AudioSource.PlayClipAtPoint(thudSound, transform.position);
			}
		}
	}

	void PlayLeftFootSound() {
		AudioSource.PlayClipAtPoint(leftFootSound, transform.position);
	}

	void PlayRightFootSound() {
		AudioSource.PlayClipAtPoint(rightFootSound, transform.position);
	}

	void PlayRocketSound() {
		if (GameObject.Find("RocketSound")) return;

		GameObject go = new GameObject("RocketSound");
		AudioSource audioSource = go.AddComponent<AudioSource> ();

		audioSource.clip = rocketSound;
		audioSource.volume = 0.7f;
		audioSource.Play();

		Destroy(go, rocketSound.length);
	}
}
