using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCreatures : MonoBehaviour {

	public GameObject[] CreaturePrefabs;

	GameObject[] _queuedSpawnTargets;
	PlayerConfig _playerConfig;
	TargetSelection _targetSelection;
	int[] _queuedSpawnTypes;
	int _ownerID;
	int _spawns = 0;
	int _spawnsTotal = 0;

	// Use this for initialization
	void Start () {
		_playerConfig = GetComponent<PlayerConfig>();
		_ownerID = _playerConfig.PlayerID;
		_targetSelection = GetComponent<TargetSelection>();
	}

	// Update is called once per frame
	void Update () {
		if (_playerConfig.GetIsHuman()) {
			if (_playerConfig.Player.GetButtonUp("Spawn0")) {
				QueueSpawn(0, _targetSelection.GetTarget());
			}
			if (_playerConfig.Player.GetButtonUp("Spawn1")) {
				QueueSpawn(1, _targetSelection.GetTarget());
			}
			if (_playerConfig.Player.GetButtonUp("Spawn2")) {
				QueueSpawn(2, _targetSelection.GetTarget());
			}
		}
	}

	public void SetSpawns (int numSpawns) {
		_spawnsTotal = numSpawns;
		_spawns = 0;

		_queuedSpawnTypes = new int[numSpawns];
		_queuedSpawnTargets = new GameObject[numSpawns];
	}

	public void QueueSpawn (int creatureType, GameObject target) {
		if (_spawns < _spawnsTotal) {
			_queuedSpawnTypes[_spawns] = creatureType;
			_queuedSpawnTargets[_spawns] = target;

			_spawns++;
		}
	}

	public void Spawn () {
		GameObject newCreature;
		for (int i = 0; i < _spawns; i++) {
			newCreature = Instantiate(CreaturePrefabs[_queuedSpawnTypes[i]], transform.position, Quaternion.identity);
			newCreature.GetComponent<CreatureMove>().SetTarget(_queuedSpawnTargets[i]);
			newCreature.GetComponent<PlayerConfig>().SetPlayerID(_ownerID);
		}

		_spawns = 0;
	}
}
