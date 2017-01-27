using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureTargeting : MonoBehaviour {

	List<GameObject> _potentialTargets;
	public GameObject _currentTarget;
	PlayerConfig _playerConfig;

	// Use this for initialization
	void Start () {
		_playerConfig = GetComponent<PlayerConfig>();
		_potentialTargets = new List<GameObject>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D otherCollider) {
		if (otherCollider.GetComponent<PlayerConfig>().PlayerID != _playerConfig.PlayerID) {
			_potentialTargets.Add(otherCollider.gameObject);
		}
	}
	void OnTriggerExit2D (Collider2D otherCollider) {
		_potentialTargets.Remove(otherCollider.gameObject);
	}

	void AcquireTarget () {
		float currentDistance = 9999999999;

		_potentialTargets.RemoveAll(item => item == null);

		for (int i = 0; i < _potentialTargets.Count; i++) {
			if (Vector3.Distance(_potentialTargets[i].transform.position, transform.position) < currentDistance) {
				_currentTarget = _potentialTargets[i];
				currentDistance = Vector3.Distance(_potentialTargets[i].transform.position, transform.position);
			}
		}
	}

	public GameObject GetCurrentTarget () {
		AcquireTarget();

		return _currentTarget;
	}
}
