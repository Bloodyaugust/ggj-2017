using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerConfig : MonoBehaviour {

	public Player Player;
	public int PlayerID;

	void Awake () {
		Player = ReInput.players.GetPlayer(PlayerID);
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}
}
