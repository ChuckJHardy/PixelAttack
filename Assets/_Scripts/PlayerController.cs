using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Vector2 moving = new Vector2 ();

	void Update () {
		moving.x = moving.y = 0;

		if (Input.GetKey("right")) {
			moving.x = 1;
		} else if (Input.GetKey("left")) {
			moving.x = -1;
		}

		if (Input.GetKey("up")) {
			moving.y = 1;
		} else if (Input.GetKey("down")) {
			moving.y = -1;
		}
	}
}
