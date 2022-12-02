using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRotation : MonoBehaviour
{
	

	[SerializeField] Transform targetTransform;
	Vector3 target;
	private void Start()
	{
		targetTransform = GameObject.Find("CompassTarget").gameObject.transform;
	}

	void Update()
	{
			target = transform.position + (targetTransform.position - transform.position); // Vector from self to player
			target = Vector3.ProjectOnPlane(target - transform.position, transform.up) + transform.position; //Flatten vector against own up direction
			transform.LookAt(target, transform.parent.transform.up); //Convert vector to transform rotation quaternion
			Debug.DrawLine(transform.position, target, Color.red, .1f);
	}

}
