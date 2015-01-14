using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;

	Transform targetTransform;

	void Awake() {
		camera.orthographicSize = ((Screen.height / 2.0f) / 100f);
	}

	void Start () {
		targetTransform = target.transform;	
	}
	
	void Update () {
		if (targetTransform) {
			transform.position = new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z);			
		}
	}
}
