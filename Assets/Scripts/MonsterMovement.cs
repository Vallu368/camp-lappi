using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
	[SerializeField] Vector3 MovementBoundaryMax;
	[SerializeField] Vector3 MovementBoundaryMin;
	[SerializeField] float forwardSpeed;
	[SerializeField] float turnSpeed;
	Transform player;
	Vector3 ForwardDirection;
	void Start()
	{
		ForwardDirection = Vector3.forward;
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	void Update()
	{
		transform.Translate(ForwardDirection * forwardSpeed * Time.deltaTime); //Move forward

		//Check if passed any boundary
		if (transform.position.x > MovementBoundaryMax.x 
		|| transform.position.x < MovementBoundaryMin.x 
		|| transform.position.z > MovementBoundaryMax.z
		|| transform.position.z < MovementBoundaryMin.z)
		{	//Rotate towards player
			Vector3 playerFlatPosition = new Vector3(player.position.x, transform.position.y, player.position.y); //Use own Y position instead as target's, to not move up or down
			Vector3 relativePos = playerFlatPosition - transform.position; //Create a vector pointing to target from own position
			Quaternion desiredRotation = Quaternion.LookRotation(relativePos, Vector3.up); //Convert said vector to quaternion
			transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, turnSpeed * Time.deltaTime); //Rotate
		}
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
