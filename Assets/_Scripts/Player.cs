using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 10f;
	public float jetSpeed = 15f;
	public Vector2 maxVelocity = new Vector2 (3, 5);
	public float airSpeedMultiplier = 0.3f;

	private Animator animator;
	private PlayerController controller;
	private bool standing;

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
			if (absVelocityY < maxVelocity.y) {
				forceY = jetSpeed * controller.moving.y;
			}
		}

		rigidbody2D.AddForce(new Vector2 (forceX, forceY));
	}
}
