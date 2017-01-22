using UnityEngine;
using System.Collections;

public class SpriteCarousel : MonoBehaviour {

	public Sprite[] sprites;
	public int currentIndex;

	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
		currentIndex = (int)Mathf.Floor(Time.time % sprites.Length);
		spriteRenderer.sprite = sprites[currentIndex];
	}
}
