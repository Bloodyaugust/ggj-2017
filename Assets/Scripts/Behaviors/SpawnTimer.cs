using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour {

	public TextMesh _spawnTimerText;
	public float SpawnInterval;
	public int NumSpawns;

	GameState _gameState;
	GameObject[] _castles;
	float _timeToSpawn = 0;
	bool _spawnsSet = false;

	// Use this for initialization
	void Start () {
		_timeToSpawn = SpawnInterval;
		_castles = GameObject.FindGameObjectsWithTag("Castle");
		_gameState = GetComponent<GameState>();

		for (int i = 0; i < _castles.Length; i++) {
			_castles[i].GetComponent<SpawnCreatures>().SetSpawns();
		}
	}

	// Update is called once per frame
	void Update () {
		if (_gameState.GetState() == (int)GameState.States.SpawnQueue) {
			_timeToSpawn -= Time.deltaTime;

			_spawnTimerText.text = Mathf.Floor(_timeToSpawn).ToString();

			if (!_spawnsSet) {
				_castles = GameObject.FindGameObjectsWithTag("Castle");

				for (int i = 0; i < _castles.Length; i++) {
					_castles[i].GetComponent<SpawnCreatures>().SetSpawns();
				}

				_spawnsSet = true;
			}

			if (_timeToSpawn <= 0) {
				_timeToSpawn = SpawnInterval;

				_gameState.SetState((int)GameState.States.Combat);
				_spawnTimerText.text = ' '.ToString();

				_castles = GameObject.FindGameObjectsWithTag("Castle");

				for (int i = 0; i < _castles.Length; i++) {
					_castles[i].GetComponent<SpawnCreatures>().Spawn();
				}
			}
		} else {
			GameObject[] creatures = GameObject.FindGameObjectsWithTag("Creature");

			if (creatures.Length == 0) {
				_gameState.SetState((int)GameState.States.SpawnQueue);
			}

			_spawnsSet = false;
		}
	}
}
