using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Light lampLight;
    public bool lightOn;
    void Start()
    {
        lampLight = GameObject.Find("LampLight").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(lightOn)
            {
                lampLight.enabled = false;
                lightOn = false;
            }
            else if(!lightOn)
            {
                lampLight.enabled = true;
                lightOn = true;
            }
        }
    }
}
