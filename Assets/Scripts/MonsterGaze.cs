using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGaze : MonoBehaviour
{
	[SerializeField] MonsterMind MonsterMind;
	[SerializeField] Light HeadLight;
	[SerializeField] Color LightColorRoaming;
	[SerializeField] Color LightColorAlerted;
	[SerializeField] float gazeSuspicion;
	public InventoryScript inv;
	public LayerMask obstructionLayer;
	float eyeContactFactor;
	Transform playerTransform;
	FieldOfView fov;
	void Start()
	{
		inv = GameObject.Find("Canvas").GetComponent<InventoryScript>();
		playerTransform = MonsterMind.playerTransform;
		fov = this.gameObject.GetComponentInChildren<FieldOfView>();
	}

	void Update()
	{
		HeadLight.color = Color.Lerp(LightColorRoaming, LightColorAlerted, Mathf.Clamp((eyeContactFactor - 0.8f) * 4f, 0f, 1f)); //Magic numbers to tint head light color when looking at player

	}
	void FixedUpdate()
	{
		eyeContactFactor = Vector3.Dot(transform.forward.normalized, (playerTransform.position - transform.position).normalized); //Compare alignment of direction forward and direction to player
		if (eyeContactFactor > 0.75f)
		{
			Debug.DrawRay(transform.position, (playerTransform.position - transform.position).normalized * 10f, Color.red, Time.fixedDeltaTime);
			//Debug.Log($"<color=cyan>Monster gets suspicious...</color>");
			// MonsterMind.GetSuspicious(gazeSuspicion);
			RaycastHit hit;
			if (!Physics.Raycast(transform.position, (playerTransform.position - transform.position).normalized * 10f, out hit, Mathf.Infinity, obstructionLayer))
			{
                if(!inv.running)
                {
					MonsterMind.GetSuspicious(gazeSuspicion);
				}
            }
			

        }
		void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawRay(transform.position, transform.forward * 10f);
		}
	}
}
