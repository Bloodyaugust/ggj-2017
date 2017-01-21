using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureState : MonoBehaviour {

	public enum States {
		Idle,
		Moving,
		Attacking,
		Dying
	};

	public int[] _animations = new int[] {1, 1, 2, 3};

	SpriterAnimator _animator;
	int _lastState = 0;
	int _currentState = 0;
	bool _stateChanged = true;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<SpriterAnimator>();
	}

	// Update is called once per frame
	void Update () {

	}

	void LateUpdate () {
		if (_stateChanged) {
			_stateChanged = false;

			_animator.SetAnimation(_animations[_currentState]);
		}
	}

	public int GetState () {
		return _currentState;
	}

	public void SetState (int newState) {
		_lastState = _currentState;
		_currentState = newState;

		_stateChanged = true;
	}
}
