using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
	[SerializeField] Vector3 MovementBoundaryMax;
	[SerializeField] Vector3 MovementBoundaryMin;
	[SerializeField] float forwardSpeed;
	Vector3 ForwardDirection;
	void Start()
	{
		ForwardDirection = Vector3.forward;
	}

	void Update()
	{
		transform.Translate(ForwardDirection * forwardSpeed * Time.deltaTime);
		if (transform.position.x > MovementBoundaryMax.x 
		|| transform.position.x < MovementBoundaryMin.x 
		|| transform.position.z > MovementBoundaryMax.z
		|| transform.position.z < MovementBoundaryMin.z)
		{
			Debug.Log("Monster out of bounds");
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
