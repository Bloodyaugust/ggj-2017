using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	public enum States {
		SpawnQueue,
		Combat
	};

	int _lastState = 0;
	public int _currentState = 0;
	bool _stateChanged = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void LateUpdate () {
		if (_stateChanged) {
			_stateChanged = false;
		}
	}

	public int GetState () {
		return _currentState;
	}

	public void SetState (int newState) {
		if (_currentState != newState) {
			_lastState = _currentState;
			_currentState = newState;

			_stateChanged = true;
		}
	}
}
