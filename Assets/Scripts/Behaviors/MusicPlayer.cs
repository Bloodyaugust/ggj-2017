using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public AudioClip[] musics;

	float currentMusicLength;
	float currentMusicElapsed = 0;
	int currentMusicIndex = 0;

	// Use this for initialization
	void Start () {
		currentMusicLength = musics[currentMusicIndex].length;
		AudioSource.PlayClipAtPoint(musics[currentMusicIndex], Vector3.zero, 0.5f);
	}

	// Update is called once per frame
	void Update () {
		currentMusicElapsed += Time.deltaTime;

		if (currentMusicElapsed >= currentMusicLength + 1) {
			if (currentMusicIndex == musics.Length - 1) {
				currentMusicIndex = 0;
			} else {
				currentMusicIndex++;
			}

			currentMusicLength = musics[currentMusicIndex].length;
			currentMusicElapsed = 0;
			AudioSource.PlayClipAtPoint(musics[currentMusicIndex], Vector3.zero, 0.5f);
		}
	}
}
