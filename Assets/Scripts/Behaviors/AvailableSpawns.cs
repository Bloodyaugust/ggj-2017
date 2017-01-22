using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableSpawns : MonoBehaviour {

	public GameObject[] Clams;

	SpriteRenderer[] _clamRenderers;

	// Use this for initialization
	void Start () {
		_clamRenderers = new SpriteRenderer[Clams.Length];
		for (int i = 0; i < Clams.Length; i++) {
			Clams[i].transform.position += new Vector3(4 * i, 0, 0);
			_clamRenderers[i] = Clams[i].GetComponent<SpriteRenderer>();
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void HideClam (int index) {
		_clamRenderers[index].enabled = false;
	}

	public void ShowClams () {
		for (int i = 0; i < _clamRenderers.Length; i++) {
			_clamRenderers[i].enabled = true;
		}
	}
}
