using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2 (3, 5);

	void Update () {
		float forceX = 0f;
		float forceY = 0f;

		float absVelocityX = Mathf.Abs(rigidbody2D.velocity.x);

		if (Input.GetKey("right")) {
			if (absVelocityX < maxVelocity.x) {
				forceX = speed;
			}

			transform.localScale = new Vector3 (1, 1, 1);
		} else if (Input.GetKey("left")) {
			if (absVelocityX < maxVelocity.x) {
				forceX = -speed;
			}

			transform.localScale = new Vector3 (-1, 1, 1);
		}

		rigidbody2D.AddForce(new Vector2 (forceX, forceY));
	}
}
