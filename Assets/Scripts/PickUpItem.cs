using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
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
                }


            }
            mesh.SetActive(false);
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
