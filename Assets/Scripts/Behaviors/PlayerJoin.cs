using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerJoin : MonoBehaviour {

	GameObject[] _castles;

	// Use this for initialization
	void Start () {
		_castles = GameObject.FindGameObjectsWithTag("Castle");
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < ReInput.players.playerCount; i++) {
			Player p = ReInput.players.Players[i];

			if (p.GetButton("Join")) {
				for (int i2 = 0; i2 < _castles.Length; i2++) {
					if (_castles[i2].GetComponent<PlayerConfig>().PlayerID == i) {
						_castles[i2].GetComponent<PlayerConfig>().SetIsHuman(true);
					}
				}
			}
		}
	}
}
