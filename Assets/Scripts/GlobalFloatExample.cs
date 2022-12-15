using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFloatExample : MonoBehaviour
{
	float time;
	float timeponged;
	void Update()
	{
		time += Time.deltaTime;
		timeponged = Mathf.PingPong(time, 1f);

		Shader.SetGlobalFloat("_FullscreenIntensity", timeponged);
	}
}
