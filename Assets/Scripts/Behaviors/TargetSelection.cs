using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class TargetSelection : MonoBehaviour {

	public GameObject[] PossibleTargets;

	public GameObject _target;
	PlayerConfig _playerConfig;
	Player _player;
	bool _isHuman = true;

	void Awake () {
		_playerConfig = gameObject.GetComponent<PlayerConfig>();
	}

	// Use this for initialization
	void Start () {
		_target = PossibleTargets[0];

		if (_playerConfig == null) {
			_isHuman = false;
		} else {
			_player = _playerConfig.Player;
		}
	}

	// Update is called once per frame
	void Update () {
		Vector3 targetVector;

		if (_isHuman) {
			targetVector = new Vector3(_player.GetAxis("TargetSelectX"), _player.GetAxis("TargetSelectY"), 0) + transform.position;

			for (int i = 0; i < PossibleTargets.Length; i++) {
				if (Vector3.Distance(PossibleTargets[i].transform.position, targetVector) < Vector3.Distance(_target.transform.position, targetVector)) {
					_target = PossibleTargets[i];
				}
			}
		}
	}

	public GameObject GetTarget () {
		return _target;
	}
}
