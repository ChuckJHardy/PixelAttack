using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {
	public Sprite[] sprites;
	public string resourceName;
	public int currentSpriteIndex = -1;

	SpriteRenderer spriteRenderer;

	void Awake () {
		sprites = Resources.LoadAll<Sprite> (resourceName);	
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Start () {
		int randomNumber = Random.Range (0, sprites.Length);

		if (currentSpriteIndex < 0) {
			currentSpriteIndex = randomNumber;
		} else if (currentSpriteIndex > sprites.Length) {
			currentSpriteIndex = sprites.Length - 1;
		}

		spriteRenderer.sprite = sprites[currentSpriteIndex];
	}
}
