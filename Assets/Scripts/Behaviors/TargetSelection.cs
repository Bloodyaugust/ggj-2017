using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class TargetSelection : MonoBehaviour {

	public GameObject[] PossibleTargets;

	GameObject _target;
	PlayerConfig _playerConfig;

	void Awake () {
		_playerConfig = gameObject.GetComponent<PlayerConfig>();
	}

	// Use this for initialization
	void Start () {
		_target = PossibleTargets[0];
	}

	// Update is called once per frame
	void Update () {
		Vector3 targetVector;

		if (_playerConfig.GetIsHuman()) {
			targetVector = new Vector3(_playerConfig.Player.GetAxis("TargetSelectX"), _playerConfig.Player.GetAxis("TargetSelectY"), 0) + transform.position;

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
