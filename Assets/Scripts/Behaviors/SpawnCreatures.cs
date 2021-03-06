﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCreatures : MonoBehaviour {

	public GameObject[] CreaturePrefabs;
	public int NumSpawns;

	AvailableSpawns _availableSpawns;
	GameObject[] _queuedSpawnTargets;
	PlayerConfig _playerConfig;
	TargetSelection _targetSelection;
	int[] _queuedSpawnTypes;
	int _ownerID;
	int _spawns = 0;

	// Use this for initialization
	void Start () {
		_availableSpawns = GetComponent<AvailableSpawns>();
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
		} else {
			if (_spawns < NumSpawns) {
				_targetSelection.SwitchTarget();
				QueueSpawn(Random.Range(0, CreaturePrefabs.Length), _targetSelection.GetTarget());
			}
		}
	}

	public void SetSpawns () {
		_spawns = 0;

		_queuedSpawnTypes = new int[NumSpawns];
		_queuedSpawnTargets = new GameObject[NumSpawns];

		_availableSpawns.ShowClams();
	}

	public void QueueSpawn (int creatureType, GameObject target) {
		if (_spawns < NumSpawns) {
			_queuedSpawnTypes[_spawns] = creatureType;
			_queuedSpawnTargets[_spawns] = target;

			_availableSpawns.HideClam(_spawns);

			_spawns++;
		}
	}

	public void Spawn () {
		GameObject newCreature;
		for (int i = 0; i < _spawns; i++) {
			newCreature = Instantiate(CreaturePrefabs[_queuedSpawnTypes[i]], transform.position + new Vector3(Random.value, Random.value, 0), Quaternion.identity);
			newCreature.transform.position = newCreature.transform.position - new Vector3(0, 6, 0);
			newCreature.GetComponent<CreatureMove>().SetTarget(_queuedSpawnTargets[i]);
			newCreature.GetComponent<PlayerConfig>().SetPlayerID(_ownerID);
		}

		_spawns = 0;
	}
}
