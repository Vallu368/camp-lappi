using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGaze : MonoBehaviour
{
	[SerializeField] MonsterMind MonsterMind;
	[SerializeField] Light HeadLight;
	[SerializeField] Color LightColorRoaming;
	[SerializeField] Color LightColorAlerted;
	float eyeContactFactor;
	Transform playerTransform;
	void Start()
	{
		playerTransform = MonsterMind.playerTransform;
	}

	void Update() 
	{
		HeadLight.color = Color.Lerp(LightColorRoaming, LightColorAlerted, Mathf.Clamp((eyeContactFactor-0.8f)*4f, 0f, 1f));
	}
	void FixedUpdate()
	{
		eyeContactFactor = Vector3.Dot(transform.forward.normalized, (playerTransform.position - transform.position).normalized);
		Debug.DrawRay(transform.position, transform.forward*1f, Color.cyan, Time.fixedDeltaTime);
		Debug.DrawRay(transform.position, (playerTransform.position - transform.position).normalized, Color.red, Time.fixedDeltaTime);

	}
}
