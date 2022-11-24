using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
	MonsterMind MonsterMind;
	[Tooltip("North-east maximum roaming boundary where monster makes U-turn")]
	[SerializeField] Vector3 MovementBoundaryMax;
	[Tooltip("South-west maximum roaming boundary where monster makes U-turn")]
	[SerializeField] Vector3 MovementBoundaryMin;
	[Tooltip("Forward speed factor when roaming")]
	[SerializeField] float ForwardSpeed;
	[Tooltip("How quickly monster makes U-turn when out of roaming bounds")]
	[SerializeField] float TurnSpeed;
	[Tooltip("How quickly to swerve from side to side")]
	[SerializeField] float VeerSpeed;
	[Tooltip("How long to swerve for - per swerve")]
	[SerializeField] float VeerPhaseLength;
	[Tooltip("How qickly to slow down")]
	[SerializeField] float BrakeTime;
	[Tooltip("How slow to move when braking, between 0 and 1")]
	[SerializeField] float BrakeStrength;
	[Tooltip("Distance to player within which roaming pursuit does not occur, for fairness")]
	[SerializeField] float PursueSafeDistance;
	public bool Pursuing; //Directs monster towards player location, modified by MonsterMind
	float brakeFactor; //Reducing multiplier added to movement
	float brakeVelocity; 
	float brakeTarget = 1f; //Desired brake factor
	float veerCounter; //Timer that counts down for each swerve
	float veerFactor; //Variable for angular change during current swerve
	float[] veerDirections = new float[] {1f, 0.5f, 0, 0, -0.5f, -1}; //Veer speed multipliers for directions, chosen randomly
	Transform playerTransform;
	void Start()
	{
		MonsterMind = GetComponent<MonsterMind>();
		playerTransform = MonsterMind.playerTransform;
	}

	void Update() 
	{
		//brakeFactor = Mathf.MoveTowards(brakeFactor, brakeTarget, BrakeSpeed * Time.deltaTime); //
		brakeFactor = Mathf.SmoothDamp(brakeFactor, brakeTarget, ref brakeVelocity, BrakeTime);
	}

	public void Roam() //Move forward, turn towards player when reaching boundary
	{
		transform.Translate(Vector3.forward * ForwardSpeed * brakeFactor * Time.deltaTime); //Move forward

		//Check if passed any boundary
		if (transform.position.x > MovementBoundaryMax.x	//East
		|| transform.position.x < MovementBoundaryMin.x		//West
		|| transform.position.z > MovementBoundaryMax.z		//North
		|| transform.position.z < MovementBoundaryMin.z)    //South
        {   //If so, rotate towards player and slow down
            RotateTowardsPlayer();
        	brakeTarget = BrakeStrength; //Reduce speed gradually
        }
		else if(Pursuing && MonsterMind.DistanceToPlayer > PursueSafeDistance) //MonsterMind decides when to Pursue, but we do it only when outside the Safe Distance
		{
			RotateTowardsPlayer();
			//Debug.Log($"<color=cyan>Pursuing at distance of {MonsterMind.DistanceToPlayer}</color>");
		}
        else //Otherwise veer to add unpredictably whenever not doing the U-turn
		{
			brakeTarget = 1f;
			if (veerCounter >= 0f) //While counter is running 
			{
				transform.Rotate(new Vector3 (0f, veerFactor, 0f)); //Steadily rotate
				veerCounter -= Time.deltaTime; //Run counter
			}
			else //When counter runs out
			{
				veerCounter = VeerPhaseLength; //Reset counter to maximum
				veerFactor = VeerSpeed * veerDirections[Random.Range(0, veerDirections.Length)]; //Randomize veer direction
			}
		}
	}
	

    private void RotateTowardsPlayer()
    {
        Vector3 relativePos = TargetPlayer();
        Quaternion desiredRotation = Quaternion.LookRotation(relativePos, Vector3.up); //Convert the vector to quaternion
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, TurnSpeed * Time.deltaTime); //Rotate
    }

    Vector3 TargetPlayer()
	{	
		Vector3 playerFlatPosition = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z); //Use own Y position instead as target's, to not move up or down
		Vector3 relativePos = playerFlatPosition - transform.position; //Create a vector pointing to target from own position
		return relativePos;
	}

	void OnDrawGizmosSelected()
	{
		// Draws a boundary rectangle between max and min points
		Gizmos.color = Color.cyan;
		//Max corner lines
		Gizmos.DrawLine(new Vector3 (MovementBoundaryMax.x, transform.position.y, MovementBoundaryMax.z), 
						new Vector3 (MovementBoundaryMax.x, transform.position.y, MovementBoundaryMin.z));
		Gizmos.DrawLine(new Vector3 (MovementBoundaryMax.x, transform.position.y, MovementBoundaryMax.z), 
						new Vector3 (MovementBoundaryMin.x, transform.position.y, MovementBoundaryMax.z));
		//Min corner lines
		Gizmos.DrawLine(new Vector3 (MovementBoundaryMin.x, transform.position.y, MovementBoundaryMin.z), 
						new Vector3 (MovementBoundaryMin.x, transform.position.y, MovementBoundaryMax.z));
		Gizmos.DrawLine(new Vector3 (MovementBoundaryMin.x, transform.position.y, MovementBoundaryMin.z), 
						new Vector3 (MovementBoundaryMax.x, transform.position.y, MovementBoundaryMin.z));
	}
}
