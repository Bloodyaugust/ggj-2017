using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class TargetSelection : MonoBehaviour {

	public GameObject Arrow;

	GameObject[] _possibleTargets;
	GameObject _target;
	PlayerConfig _playerConfig;

	void Awake () {
		_playerConfig = gameObject.GetComponent<PlayerConfig>();
	}

	// Use this for initialization
	void Start () {
		_possibleTargets = GameObject.FindGameObjectsWithTag("Castle");
	}

	// Update is called once per frame
	void Update () {
		Vector3 targetVector;
		bool foundTarget = false;

		if (_target == null && _possibleTargets.Length != 1) {
			_possibleTargets = GameObject.FindGameObjectsWithTag("Castle");

			while (!foundTarget) {
				_target = _possibleTargets[Random.Range(0, _possibleTargets.Length)];

				if (_target.GetComponent<PlayerConfig>().PlayerID != _playerConfig.PlayerID) {
					foundTarget = true;
				}
			}
		}

		if (_playerConfig.GetIsHuman() && _possibleTargets.Length != 1) {
			float currentDistance = 9999999999;
			float xAim = _playerConfig.Player.GetAxis("TargetSelectX");
			float yAim = _playerConfig.Player.GetAxis("TargetSelectY");
			Vector3 totalAim = new Vector3(xAim * 100, yAim * 100, 0);

			Debug.Log(Mathf.Abs(yAim + xAim));
			if (Mathf.Abs(yAim + xAim) >= 0.2f) {
				for (int i = 0; i < _possibleTargets.Length; i++) {
					if (_possibleTargets[i].GetComponent<PlayerConfig>().PlayerID == _playerConfig.PlayerID) {
						continue;
					}
					if (Vector3.Distance(_possibleTargets[i].transform.position, totalAim) < currentDistance) {
						currentDistance = Vector3.Distance(_possibleTargets[i].transform.position, totalAim);
						_target = _possibleTargets[i];
					}
				}
			}
		}

		Arrow.transform.right = _target.transform.position - Arrow.transform.position;
	}

	public GameObject GetTarget () {
		return _target;
	}

	public void SwitchTarget () {
		bool foundTarget = false;
		_possibleTargets = GameObject.FindGameObjectsWithTag("Castle");

		if (_possibleTargets.Length != 1) {
			while (!foundTarget) {
				_target = _possibleTargets[Random.Range(0, _possibleTargets.Length)];

				if (_target.GetComponent<PlayerConfig>().PlayerID != _playerConfig.PlayerID) {
					foundTarget = true;
				}
			}
		}
	}
}
