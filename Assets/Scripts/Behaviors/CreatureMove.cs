﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMove : MonoBehaviour {

	public float MoveSpeed;

	GameObject _target;
	CreatureState _state;

	void Awake () {
		_state = GetComponent<CreatureState>();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (_state.GetState() == (int)CreatureState.States.Moving) {
			transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, MoveSpeed * Time.deltaTime);
		}
	}

	public void SetTarget (GameObject newTarget) {
		_target = newTarget;
		_state.SetState((int)CreatureState.States.Moving);
	}
}