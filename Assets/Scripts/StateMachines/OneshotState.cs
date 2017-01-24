using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneshotState : MonoBehaviour {

	public enum States {
		Playing,
		Done
	};

	public AudioClip[] EffectSounds;
	public float PlayTime;

	SpriterAnimator _animator;
	float _currentTime = 0;
	int _currentState = 0;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<SpriterAnimator>();
	}

	// Update is called once per frame
	void Update () {

	}

	void LateUpdate () {
		if (_currentState == (int)States.Playing) {
			if (_currentTime == 0) {
				_animator.SetAnimation(1);
				if (EffectSounds.Length != 0) {
					AudioSource.PlayClipAtPoint(EffectSounds[Random.Range(0, EffectSounds.Length)], transform.position);
				}
			}

			_currentTime += Time.deltaTime;

			if (_currentTime >= PlayTime) {
				_currentState = (int)States.Done;
			}
		} else {
			Destroy(gameObject);
		}
	}
}
