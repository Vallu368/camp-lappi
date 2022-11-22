using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMind : MonoBehaviour
{
	[SerializeField] MonsterMovement MonsterMovementScript;
	[SerializeField] MonsterGaze MonsterGazeScript;
	[SerializeField] MonsterState _monsterState;
	[HideInInspector] public Transform playerTransform;
	enum MonsterState{Watching, Roaming, Pursuing, Attacking}
	void Awake()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	
	void Update()
	{
		switch(_monsterState)
		{
			case MonsterState.Watching:
				Debug.Log($"Monster watching");
				break;
			case MonsterState.Roaming:
				MonsterMovementScript.Roam();
				//Debug.Log($"Monster Roaming");
				break;
			case MonsterState.Pursuing:
				Debug.Log($"Monster Pursuing");
				break;
			case MonsterState.Attacking:
				Debug.Log($"Monster Attacking");
				break;
			default:
				Debug.LogError(this.gameObject+" has invalid MonsterState");
				break;
		}
	}
}
