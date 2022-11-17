using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMind : MonoBehaviour
{
	[SerializeField] MonsterMovement movement;
	enum MonsterState {Idle, Wandering, Attacking};
/* 	public MonsterState states; */
/* 	void Start()
	{
		states = MonsterState.Wandering;
		//var state : states = MonsterState.Wandering;
	}

	void Update()
	{
		switch (states)
		{
			case MonsterState.Idle:
			{

			}
			
			default:
				Debug.LogError(this.gameObject+" has invalid MonsterState");
				break;
		}
	} */
}
