using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 10f;
	public float jetSpeed = 15f;
	public Vector2 maxVelocity = new Vector2 (3, 5);
	public float airSpeedMultiplier = 0.3f;

	bool standing;

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

		if (Input.GetKey("right")) {
			if (absVelocityX < maxVelocity.x) {
				forceX = standing ? speed : (speed * airSpeedMultiplier);
			}

			transform.localScale = new Vector3 (1, 1, 1);
		} else if (Input.GetKey("left")) {
			if (absVelocityX < maxVelocity.x) {
				forceX = standing ? -speed : (-speed * airSpeedMultiplier);
			}

			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if (Input.GetKey("up")) {
			if (absVelocityY < maxVelocity.y) {
				forceY = jetSpeed;
			}
		}

		rigidbody2D.AddForce(new Vector2 (forceX, forceY));
	}
}
