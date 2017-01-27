using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	public AudioClip[] AttackSounds;
	public float AttackDamage;
	public float AttackInterval;
	public float AttackRange;

	CreatureState _creatureState;
	CreatureTargeting _creatureTargeting;
	GameObject _currentTarget;
	float _timeToAttack = 0;

	// Use this for initialization
	void Start () {
		_creatureState = GetComponent<CreatureState>();
		_creatureTargeting = GetComponent<CreatureTargeting>();

		GetComponent<CircleCollider2D>().radius = AttackRange / transform.localScale.x;
	}

	// Update is called once per frame
	void Update () {
		if (_creatureState.GetState() != (int)CreatureState.States.Dying) {
			_currentTarget = _creatureTargeting.GetCurrentTarget();
			_timeToAttack -= Time.deltaTime;

			if (_currentTarget != null && Vector3.Distance(_currentTarget.transform.position, transform.position) < AttackRange) {
				DoAttack();
				_creatureState.SetState((int)CreatureState.States.Attacking);
			} else {
				_creatureState.SetState((int)CreatureState.States.Moving);
			}
		}
	}

	void DoAttack () {
		if (_timeToAttack <= 0) {
			_currentTarget.GetComponent<Vitality>().Damage(AttackDamage);

			_timeToAttack = AttackInterval;
			AudioSource.PlayClipAtPoint(AttackSounds[Random.Range(0, AttackSounds.Length)], transform.position);
		}
	}
}
