using UnityEngine;
using System.Collections;

public class LookForward : MonoBehaviour {
	public Transform sightStart, sightEnd;

	private bool collision = false;

	void Update () {
		collision = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer ("Solid"));
		Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

		if (collision) {
			int posX = transform.localScale.x == 1 ? -1 : 1;
			this.transform.localScale = new Vector3(posX, 1, 1);
		}
	}
}
