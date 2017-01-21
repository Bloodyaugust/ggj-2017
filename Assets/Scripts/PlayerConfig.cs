using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerConfig : MonoBehaviour {

	public Player Player;
	public int PlayerID;

	bool _isHuman = false;

	void Awake () {

	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void SetPlayerID (int newID) {
		PlayerID = newID;

		if (_isHuman) {
			Player = ReInput.players.GetPlayer(newID);
		}
	}

	public bool GetIsHuman () {
		return _isHuman;
	}

	public void SetIsHuman (bool isHuman) {
		_isHuman = isHuman;

		if (isHuman) {
			Player = ReInput.players.GetPlayer(PlayerID);
		} else {
			Player = null;
		}
	}
}
