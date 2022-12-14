using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightScript : MonoBehaviour
{
    public Light lampLight;
    public bool lightOn;
    public GameObject spotLight;
    void Start()
    {
        lampLight = GameObject.Find("LampLight").GetComponent<Light>();
        spotLight = GameObject.Find("Spot Light");

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
                spotLight.SetActive(false);
            }
            else if(!lightOn)
            {
                lampLight.enabled = true;
                lightOn = true;
                spotLight.SetActive(true);
            }
        }
    }
}
