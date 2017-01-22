using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

	public float WanderSpeed;

	Vector3[] _wanderPoints;
	int _currentWanderPoint = 0;

	// Use this for initialization
	void Start () {
		_wanderPoints = new Vector3[2];
		_wanderPoints[0] = new Vector3(-125, transform.position.y, 0);
		_wanderPoints[1] = new Vector3(125, transform.position.y, 0);
	}

	// Update is called once per frame
	void Update () {
		if (transform.position == _wanderPoints[_currentWanderPoint]) {
			if (_currentWanderPoint == 0) {
				_currentWanderPoint = 1;
			} else {
				_currentWanderPoint = 0;
			}
			transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		}
		transform.position = Vector3.MoveTowards(transform.position, _wanderPoints[_currentWanderPoint], WanderSpeed * Time.deltaTime);
	}
}
