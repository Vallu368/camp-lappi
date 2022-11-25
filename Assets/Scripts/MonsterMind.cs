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
	
	void Awake()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	void Update()
    {
		DistanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        CheckMonsterState();
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
                //Debug.Log($"Monster Roaming");
                break;
            case MonsterState.Hunting:
                Debug.Log($"Monster Hunting");
                break;
            case MonsterState.Attacking:
                Debug.Log($"Monster Attacking");
                break;
            default:
                Debug.LogError(this.gameObject + " has invalid MonsterState");
                break;
        }
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
