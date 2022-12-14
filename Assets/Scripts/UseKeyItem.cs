using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UseKeyItem : MonoBehaviour
{
    public bool running;
    public InventoryScript inv;
    public PlayerMovement playerMov;
    public GameObject noKeyItem;
    public GameObject keyItemObject;
    public int keyItemNeededID;
    public bool keyItemUsed;
    FadeToBlack fade;
    public AudioSource audio;
    public string textIfMissingItem;
    public string textAfterSuccess;
    public TextMeshProUGUI playerSpeech;
    void Start()
    {
        inv = GameObject.Find("Canvas").GetComponent<InventoryScript>();
        fade = GameObject.Find("Canvas").GetComponent<FadeToBlack>();
        playerMov = GameObject.Find("Main Camera").GetComponent<PlayerMovement>();
        audio = this.GetComponent<AudioSource>();
        keyItemObject.SetActive(false);
        playerSpeech.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UseItem()
    {
        if (!keyItemUsed)
        {
            if (keyItemNeededID == 1)
            {
                if (inv.keyItem1)
                {

                    StartCoroutine(UseKey());
                }
                else StartCoroutine(MissingKey());
            }
            if (keyItemNeededID == 2)
            {
                if (inv.keyItem2)
                {

                    StartCoroutine(UseKey());
                }
                else StartCoroutine(MissingKey());
            }
            if (keyItemNeededID == 3)
            {
                if (inv.keyItem3)
                {

                    StartCoroutine(UseKey());
                }
                else StartCoroutine(MissingKey());
            }
            if (keyItemNeededID == 4)
            {
                if (inv.keyItem4)
                {

                    StartCoroutine(UseKey());
                }
                else StartCoroutine(MissingKey());
            }
            if (keyItemNeededID == 5)
            {
                if (inv.keyItem5)
                {
                    StartCoroutine(UseKey());
                }
                else StartCoroutine(MissingKey());
            }
            if (keyItemNeededID == 6)
            {
                if (inv.keyItem6)
                {
                    StartCoroutine(UseKey());
                }
                else StartCoroutine(MissingKey());
            }
            if (keyItemNeededID == 7)
            {
                if (inv.keyItem7)
                {
                    StartCoroutine(UseKey());
                }
                else StartCoroutine(MissingKey());
            }
            if (keyItemNeededID == 8)
            {
                if (inv.keyItem7)
                {
                    StartCoroutine(UseKey());   
                }
                else StartCoroutine(MissingKey());
            }


        }
    }
    IEnumerator MissingKey()
    {
        if (!running)
        {
            running = true;
            playerSpeech.text = textIfMissingItem;
            playerSpeech.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            playerSpeech.gameObject.SetActive(false);
            running = false;
        }
        else Debug.Log("stop spamming");

    }

    IEnumerator UseKey()
    {
        if (!running && !inv.running)
        {
            running = true;
            inv.running = true;
            playerMov.usingKeyItem = true;
            StartCoroutine(fade.FadeIn(6f));
            audio.Play();
            yield return new WaitForSeconds(5);
            //sounds
            if (noKeyItem != null)
            {
                noKeyItem.SetActive(false);
            }
            keyItemObject.SetActive(true);
            keyItemUsed = true;
            audio.Stop();
            StartCoroutine(fade.FadeOut(3f));
            playerMov.usingKeyItem = false;
            playerSpeech.text = textAfterSuccess;
            playerSpeech.gameObject.SetActive(true);
            yield return new WaitForSeconds(5);
            playerSpeech.gameObject.SetActive(false);
            running = false;
            inv.running = false;
            this.GetComponent<BoxCollider>().enabled = false;
            inv.keyItemsUsed++;
        }
        else Debug.Log("stop spamming");


    }
}
