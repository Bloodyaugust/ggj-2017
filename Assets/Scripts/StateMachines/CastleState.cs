using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleState : MonoBehaviour {

	public enum States {
		LightDamage,
		MediumDamage,
		HeavyDamage,
		Dying
	};

	int _lastState = 0;
	int _currentState = 0;
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

			if (_currentState == (int)States.Dying) {
				Destroy(gameObject, 1);
			}
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
