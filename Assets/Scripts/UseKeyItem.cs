using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseKeyItem : MonoBehaviour
{
    public InventoryScript inv;
    public GameObject noKeyItem;
    public GameObject keyItemObject;
    public int keyItemNeededID;
    public bool keyItemUsed;
    FadeToBlack fade;
    void Start()
    {
        inv = GameObject.Find("Canvas").GetComponent<InventoryScript>();
        fade = GameObject.Find("Canvas").GetComponent<FadeToBlack>();
        keyItemObject.SetActive(false);
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
                else Debug.Log("need keyItem1");
            }
            if (keyItemNeededID == 2)
            {
                if (inv.keyItem2)
                {
                    //fade to black alkuun
                    noKeyItem.SetActive(false);
                    keyItemObject.SetActive(true);
                    keyItemUsed = true;
                }
                else Debug.Log("need keyItem2");
            }
            
            
        }
    }

    IEnumerator UseKey()
    {
        StartCoroutine(fade.FadeIn(3f));
        yield return new WaitForSeconds(3);
        //sounds
        noKeyItem.SetActive(false);
        keyItemObject.SetActive(true);
        keyItemUsed = true;
        StartCoroutine(fade.FadeOut(3f));


    }
}
