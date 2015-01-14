using UnityEngine;
using System.Collections;

public class ClickToContinue : MonoBehaviour {
	public string sceneName;

	bool loadLock;

	void Start () {
	
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0) && !loadLock) {
			LoadLevel();
		}	
	}

	void LoadLevel() {
		loadLock = true;
		Application.LoadLevel(sceneName);
	}
}
