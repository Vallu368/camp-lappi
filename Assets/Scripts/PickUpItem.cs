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
    GameObject mesh;
    void Start()
    {
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
            mesh.SetActive(false);
        }
    }
}
