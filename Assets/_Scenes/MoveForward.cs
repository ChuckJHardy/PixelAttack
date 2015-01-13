using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {
	public float speed = 0.5f;

	void Update () {
		rigidbody2D.velocity = new Vector2 (transform.localScale.x * speed, 0);
	}
}
