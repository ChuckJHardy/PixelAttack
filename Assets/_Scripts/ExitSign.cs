using UnityEngine;
using System.Collections;

public class ExitSign : MonoBehaviour {
	public string sceneName;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy(other.gameObject);
			LoadLevel();
		}
	}

	void LoadLevel() {
		Application.LoadLevel(sceneName);
	}
}
