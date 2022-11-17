using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotivation : MonoBehaviour
{
    public float maxMotivation;
    public float currentMotivation;
    void Start()
    {
        currentMotivation = maxMotivation;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMotivation > maxMotivation)
        {
            Debug.Log("motivation over " + maxMotivation);
            currentMotivation = maxMotivation;
        }

        if (currentMotivation <= 0)
        {
            Debug.Log("ei pyke");
        }
    }
    public void AddMotivation(float amountToAdd)
    {
        currentMotivation = currentMotivation + amountToAdd;
        Debug.Log("added " + amountToAdd + " motivation, current motivation is " + currentMotivation);
    }
    public void LowerMotivation(float amountToRemove)
    {
        currentMotivation = currentMotivation - amountToRemove;
        Debug.Log("removed " + amountToRemove + " motivation, current motivation is " + currentMotivation);

    }
}
