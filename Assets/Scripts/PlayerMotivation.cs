using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMotivation : MonoBehaviour
{
    public float maxMotivation;
    public float currentMotivation;
    public TextMeshProUGUI hpText;
    void Start()
    {
        currentMotivation = maxMotivation;

    }

    // Update is called once per frame
    void Update()
    {
        
        hpText = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
        hpText.text = currentMotivation.ToString();
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
