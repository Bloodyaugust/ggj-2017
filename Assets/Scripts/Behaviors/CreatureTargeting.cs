using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureTargeting : MonoBehaviour {

	GameObject _currentTarget;
	PlayerConfig _playerConfig;
	float _reacquireInterval = 0.5f;
	float _timeToReacquire = 0.5f;

	// Use this for initialization
	void Start () {
		_playerConfig = GetComponent<PlayerConfig>();
	}

	// Update is called once per frame
	void Update () {
		_timeToReacquire -= Time.deltaTime;
		if (_currentTarget == null || _timeToReacquire <= 0) {
			AcquireTarget();
			_timeToReacquire = _reacquireInterval;
		}
	}

	void AcquireTarget () {
		float currentDistance = 9999999999;
		GameObject[] potentialTargets = MultiTags.FindGameObjectsWithMultiTag("Targetable");

		for (int i = 0; i < potentialTargets.Length; i++) {
			if (potentialTargets[i].GetComponent<PlayerConfig>().PlayerID == _playerConfig.PlayerID) {
				continue;
			}
			if (Vector3.Distance(potentialTargets[i].transform.position, transform.position) < currentDistance) {
				_currentTarget = potentialTargets[i];
				currentDistance = Vector3.Distance(potentialTargets[i].transform.position, transform.position);
			}
		}
	}

	public GameObject GetCurrentTarget () {
		if (_currentTarget == null) {
			AcquireTarget();
		}
		return _currentTarget;
	}
}
