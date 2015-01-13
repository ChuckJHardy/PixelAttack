using UnityEngine;
using System.Collections;

public class BodyPart : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	Color start;
	Color end;
	
	float time = 0.0f;
	
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		start = spriteRenderer.color;
		end = new Color (start.r, start.g, start.b, 0.0f);
	}
	
	void Update () {
		time += Time.deltaTime;
		
		renderer.material.color = Color.Lerp (start, end, time / 2);
		
		if (renderer.material.color.a <= 0.0) {
			Destroy (gameObject);
		}
	}
}
