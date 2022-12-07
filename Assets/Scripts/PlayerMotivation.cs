using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMotivation : MonoBehaviour
{
    public GameObject restart;
    public float maxMotivation;
    public float currentMotivation;
    public TextMeshProUGUI hpText;
    private InventoryScript inv;
    FadeToBlack fade;
    public bool dead;
    public AudioSource takeDamage;
    public AudioSource die;
    private bool dyingSoundPlayed;
    void Start()
    {
        currentMotivation = maxMotivation;
        fade = GameObject.Find("Canvas").GetComponent<FadeToBlack>();
        restart = GameObject.Find("Restart");
        inv = GameObject.Find("Canvas").GetComponent<InventoryScript>();


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
            if (!dead)
            {
                StartCoroutine(Death());
                

            }
        }
    }
    IEnumerator Death()
    {
        die.Play();
        dead = true;
        Debug.Log("yay death");
        StartCoroutine(fade.FadeIn(3f));
        yield return new WaitForSeconds(5f);
        inv.unlockCursor = true;
        restart.SetActive(true);
            
        
    }


    public void AddMotivation(float amountToAdd)
    {
        currentMotivation = currentMotivation + amountToAdd;
        Debug.Log("added " + amountToAdd + " motivation, current motivation is " + currentMotivation);
    }
    public void LowerMotivation(float amountToRemove)
    {

        if (currentMotivation > 0)
        {
            currentMotivation = currentMotivation - amountToRemove;
            Debug.Log("removed " + amountToRemove + " motivation, current motivation is " + currentMotivation);
            takeDamage.Play();
        }

    }
}
