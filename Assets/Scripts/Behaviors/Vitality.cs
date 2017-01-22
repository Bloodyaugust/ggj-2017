using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitality : MonoBehaviour {

	public float MaxHealth;

	CastleState _castleState;
	CreatureState _creatureState;
	float _health;

	// Use this for initialization
	void Start () {
		_castleState = GetComponent<CastleState>();
		_creatureState = GetComponent<CreatureState>();
		_health = MaxHealth;
	}

	// Update is called once per frame
	void Update () {
		if (_health <= 0) {
			if (_creatureState != null) {
				_creatureState.SetState((int)CreatureState.States.Dying);
			} else {
				_castleState.SetState((int)CastleState.States.Dying);
			}
		}
	}

	public void Damage (float amount) {
		_health -= amount;

		if (_health <= 0) {
			if (_creatureState != null) {
				_creatureState.SetState((int)CreatureState.States.Dying);
			} else {
				_castleState.SetState((int)CastleState.States.Dying);
			}
		}
	}
}
