using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour {

	public float SpawnInterval;
	public int NumSpawns;

	GameObject[] _castles;
	float _timeToSpawn = 0;

	// Use this for initialization
	void Start () {
		_timeToSpawn = SpawnInterval;
		_castles = GameObject.FindGameObjectsWithTag("Castle");

		for (int i = 0; i < _castles.Length; i++) {
			_castles[i].GetComponent<SpawnCreatures>().SetSpawns(NumSpawns);
		}
	}

	// Update is called once per frame
	void Update () {
		_timeToSpawn -= Time.deltaTime;

		if (_timeToSpawn <= 0) {
			_timeToSpawn = SpawnInterval;
			
			for (int i = 0; i < _castles.Length; i++) {
				_castles[i].GetComponent<SpawnCreatures>().Spawn();
				_castles[i].GetComponent<SpawnCreatures>().SetSpawns(NumSpawns);
			}
		}
	}
}
