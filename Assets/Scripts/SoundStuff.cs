using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStuff : MonoBehaviour
{
    private int nextUpdate = 1;
    public GameObject ambience;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextUpdate)
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }

    }
    void UpdateEverySecond()
    {

    }
}
