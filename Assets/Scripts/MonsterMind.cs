using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMind : MonoBehaviour
{
	[SerializeField] MonsterMovement MonsterMovementScript;
	[SerializeField] MonsterGaze MonsterGazeScript;
	[SerializeField] MonsterState _monsterState;
	[Tooltip("Minimum and maximum duration for pursuing phase")]
	[SerializeField] float PursueTimeMin, PursueTimeMax;
	[Tooltip("Minimum and maximum duration between pursuing phases")]
	[SerializeField] float PursueDelayMin, PursueDelayMax;
	[Tooltip("Multiplier for how long pursuit happens for and how often. Value of 0.5 means pursuit takes twice as long, and happens twice as much.")]
	[SerializeField] float PursueDifficultyMultiplier;
	[HideInInspector] public Transform playerTransform {get; private set;} 
	public float DistanceToPlayer {get; private set;} 
	enum MonsterState{Watching, Roaming, Hunting, Attacking}
	float pursueTimer; //Cached variable to keep track of pursue duration
	float suspicion; //Variable that is increased when player is sensed, gives the monster pause to investigate and eventually initiates attack
	
	void Awake()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	void Update()
	{
		DistanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
		CheckMonsterState();
		CoolOffSuspicion();

	}

	private void CheckMonsterState()
	{
		switch (_monsterState)
		{
			case MonsterState.Watching:
				Debug.Log($"Monster watching");
				break;
			case MonsterState.Roaming:
				MonsterMovementScript.Roam();
				PursueTime();
				if(suspicion>=100f) //Temporary anger placeholder
				{
					Debug.Log($"<color=red>Monster angy!!</color>");
					_monsterState = MonsterState.Attacking;
				}
				break;
			case MonsterState.Hunting:
				Debug.Log($"Monster Hunting");
				break;
			case MonsterState.Attacking:
				if(suspicion<=0f) //Temporary calming placeholder
				{
					Debug.Log($"<color=white>Monster calmed down</color>");
					_monsterState = MonsterState.Roaming;
				}
				break;
			default:
				Debug.LogError(this.gameObject + " has invalid MonsterState");
				break;
		}
	}

	void CoolOffSuspicion()
	{
		suspicion = Mathf.MoveTowards(suspicion, 0f, Time.deltaTime*20f); //deltaTime*20 means suspicion goes from 100 to 0 in 5 seconds
		suspicion = Mathf.Clamp(suspicion, 0f, 100f);
	}
	public void GetSuspicious(float sus)
	{
		suspicion += sus;
		//Debug.Log(suspicion);
	}

	void PursueTime() //Counts Pursue timers, delays and toggles Pursue bool of MonsterMovement
	{
		if(MonsterMovementScript.Pursuing)	//Pursuing, count when to stop
		{
			pursueTimer -= (Time.deltaTime * PursueDifficultyMultiplier);
			if(pursueTimer <= 0f)	//counter runs out when pursuing
			{
				MonsterMovementScript.Pursuing = false; //Stop pursuing
				pursueTimer = Random.Range(PursueDelayMin, PursueDelayMax); //Randomize with Delay
				//Debug.Log($"<color=cyan>Pursuit ends with a delay of {pursueTimer}</color>");
			}
		}
		else	//Not pursuing, count when to start
		{
			pursueTimer -= (Time.deltaTime / PursueDifficultyMultiplier);
			if(pursueTimer <= 0f)	//counter runs out when not pursuing
			{
				MonsterMovementScript.Pursuing = true; //Start pursuing
				pursueTimer = Random.Range(PursueTimeMin, PursueTimeMax); //Randomize with Time
				//Debug.Log($"<color=cyan>Pursuit starts with a duration of {pursueTimer}</color>");
			}
		}
	}
}
