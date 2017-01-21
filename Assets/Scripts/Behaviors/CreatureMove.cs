using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMove : MonoBehaviour {

	JellyfishState _state;
	bool _isMoving = false;

	// Use this for initialization
	void Start () {
		_state = GetComponent<JellyfishState>();
	}

	// Update is called once per frame
	void Update () {

	}

	void LateUpdate () {
		if (!_isMoving) {
			_isMoving = true;
			_state.SetState((int)JellyfishState.States.Moving);
		}
	}
}
