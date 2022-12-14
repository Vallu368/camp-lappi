using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public PlayerMovement playerMov;
    public FadeToBlack fade;
    public bool taken = false;
    public Item item;
    public bool isKeyitem;
    public int keyItemNumber;
    public bool played;
    public AudioSource audio;
    public InventoryScript inv;
    public string pickUpText;
    private bool f;
    GameObject mesh;
    void Start()
    {
        fade = GameObject.Find("Canvas").GetComponent<FadeToBlack>();
        playerMov = GameObject.Find("Main Camera").GetComponent<PlayerMovement>();
        inv = GameObject.Find("Canvas").GetComponent<InventoryScript>();
        mesh = this.transform.GetChild(0).gameObject;
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (taken)
        {
            
            if (audio != null)
            {
                if (!audio.isPlaying && !played)
                {
                    audio.Play();
                    played = true;
                }
            }
            if (isKeyitem)
            {
                
                if (!f)
                {
                    StartCoroutine(inv.AddedItemText(pickUpText));
                    f = true;
                    if (this.gameObject.name == "Bandage_Prefab")
                    {
                        StartCoroutine(UseBandage());
                    }
                }


            }
            mesh.SetActive(false);
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator UseBandage()
    {
        playerMov.usingKeyItem = true;

        yield return new WaitForSeconds(3);
        StartCoroutine(fade.FadeIn(3f));
        inv.bandageSound.Play();
        inv.bleeding.SetActive(false);
        yield return new WaitForSeconds(5);
        StartCoroutine(fade.FadeOut(3f));
        playerMov.usingKeyItem = false;
        StartCoroutine(inv.AddedItemText("BANDAGE USED TEXT HERE"));
        inv.keyItemsUsed++;

    }   
}
