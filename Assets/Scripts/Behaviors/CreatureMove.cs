using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMove : MonoBehaviour {

	public float MoveSpeed;

	PlayerConfig _playerConfig;
	GameObject[] _castles;
	GameObject _target;
	CreatureState _state;

	void Awake () {
		_state = GetComponent<CreatureState>();
		_playerConfig = GetComponent<PlayerConfig>();
	}

	// Use this for initialization
	void Start () {
		_castles = GameObject.FindGameObjectsWithTag("Castle");
	}

	// Update is called once per frame
	void Update () {
		Vector3 newScale;
		float currentDistance;
		float testingDistance;

		if (_state.GetState() == (int)CreatureState.States.Moving) {
			if (_target == null) {
				currentDistance = 99999999999;
				testingDistance = 0;
				_castles = GameObject.FindGameObjectsWithTag("Castle");

				for (int i = 0; i < _castles.Length; i++) {
					if (_castles[i].GetComponent<PlayerConfig>().PlayerID != _playerConfig.PlayerID) {
						testingDistance = Vector3.Distance(_castles[i].transform.position, transform.position);

						if (testingDistance < currentDistance) {
							_target = _castles[i];
							currentDistance = testingDistance;
						}
					}
				}

				SetTarget(_target);
			}

			transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, MoveSpeed * Time.deltaTime);

			if (transform.position.x < _target.transform.position.x) {
				newScale = transform.localScale;

				newScale.x = -1 * Mathf.Abs(newScale.x);
				transform.localScale = newScale;
			} else {
				newScale = transform.localScale;

				newScale.x = Mathf.Abs(newScale.x);
				transform.localScale = newScale;
			}

			if (transform.position == _target.transform.position) {
				_target.GetComponent<Vitality>().Damage(1);

				_state.SetState((int)CreatureState.States.Dying);
			}
		}
	}

	public void SetTarget (GameObject newTarget) {
		_target = newTarget;
		_state.SetState((int)CreatureState.States.Moving);
	}
}
