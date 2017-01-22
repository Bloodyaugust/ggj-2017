using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureTargeting : MonoBehaviour {

	GameObject _currentTarget;
	PlayerConfig _playerConfig;

	// Use this for initialization
	void Start () {
		_playerConfig = GetComponent<PlayerConfig>();
	}

	// Update is called once per frame
	void Update () {
		if (_currentTarget == null) {
			AcquireTarget();
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
