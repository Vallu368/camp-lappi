using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    private CinemachineBasicMultiChannelPerlin perlin;
    private PlayerAttacked attack;
    public float beingAttackedAmplitude;
    public float beingAttackedFrequency;
    private void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        attack = GameObject.Find("Player").GetComponent<PlayerAttacked>();
        perlin = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (attack.beingAttacked)
        {
            perlin.m_AmplitudeGain = beingAttackedAmplitude;
            perlin.m_FrequencyGain = beingAttackedFrequency;
        }
        else
        {
            if (!attack.beingAttacked)
            {
                if (perlin.m_AmplitudeGain <= 2)
                {
                    perlin.m_AmplitudeGain = 1;
                    perlin.m_FrequencyGain = 1;
                }
            }
            if (perlin.m_AmplitudeGain >= 2 )
            {
                Debug.Log("smooth this shit");
                float target = 1.0f;
                float current = perlin.m_AmplitudeGain;

                float delta = target - current;
                delta *= Time.deltaTime;

                current += delta;
                perlin.m_AmplitudeGain = current;
            }
        }
        
        
    }
}
