using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	public BodyPart bodyPart;
	public int totalBodyParts = 5;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Deadly") OnExplode();
	}

	void OnExplode () {
		Destroy (gameObject);

		var currentTransform = transform;

		for (int i = 0; i < totalBodyParts; i++) {
			currentTransform.TransformPoint(0, -100, 0);
			BodyPart clone = Instantiate(bodyPart, currentTransform.position, Quaternion.identity) as BodyPart;

			clone.rigidbody2D.AddForce (Vector2.right * Random.Range(-50, 50));
			clone.rigidbody2D.AddForce (Vector2.up * Random.Range(100, 400));
		}
	}
}
