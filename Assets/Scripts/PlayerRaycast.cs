using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public float maxRange;
    RaycastHit hit;
   [HideInInspector] public InventoryScript inv;
    public GameObject interractText;
    public GameObject playerSpeech;
    


    void Start()
    {
        inv = GameObject.Find("Canvas").GetComponent<InventoryScript>();
        interractText = GameObject.Find("InterractText");
        interractText.SetActive(false);
        
    }

    void Update()
    {
        if (playerSpeech.activeSelf)
        {
            interractText.SetActive(false);
        }
        Transform cameraTransform = Camera.main.transform;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, maxRange))
        {
            if (hit.transform.tag == "Item" || hit.transform.tag == "KeyItem" || hit.transform.tag == "test")
            {
                if (!inv.running && !playerSpeech.activeSelf)
                {
                    interractText.SetActive(true);
                }
            }
            else
            {
                interractText.SetActive(false);
            }
            if (hit.transform.tag == "Item")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inv.AddItemToInventory(hit.transform.GetComponent<PickUpItem>().item);
                    hit.transform.GetComponent<PickUpItem>().taken = true;

                }

            }
            if (hit.transform.tag == "KeyItem")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.transform.GetComponent<PickUpItem>().isKeyitem == false)
                    {
                        Debug.Log("Not setup as keyitem in pickupitem script");
                    }
                    if (hit.transform.GetComponent<PickUpItem>().isKeyitem)
                    {
                        if (hit.transform.GetComponent<PickUpItem>().keyItemNumber == 1)
                        {
                            Debug.Log("key item 1 added to inventory");
                            inv.keyItem1 = true;
                            hit.transform.GetComponent<PickUpItem>().taken = true;
                        }
                        if (hit.transform.GetComponent<PickUpItem>().keyItemNumber == 2)
                        {
                            Debug.Log("key item 2 added to inventory");
                            inv.keyItem2 = true;
                            hit.transform.GetComponent<PickUpItem>().taken = true;
                        }
                        if (hit.transform.GetComponent<PickUpItem>().keyItemNumber == 3)
                        {
                            Debug.Log("key item 3 added to inventory");
                            inv.keyItem3 = true;
                            hit.transform.GetComponent<PickUpItem>().taken = true;
                        }
                        if (hit.transform.GetComponent<PickUpItem>().keyItemNumber == 4)
                        {
                            Debug.Log("key item 4 added to inventory");
                            inv.keyItem4 = true;
                            hit.transform.GetComponent<PickUpItem>().taken = true;
                        }
                        if (hit.transform.GetComponent<PickUpItem>().keyItemNumber == 5)
                        {
                            Debug.Log("key item 5 added to inventory");
                            inv.keyItem5 = true;
                            hit.transform.GetComponent<PickUpItem>().taken = true;
                        }
                        if (hit.transform.GetComponent<PickUpItem>().keyItemNumber == 6)
                        {
                            Debug.Log("key item 6 added to inventory");
                            inv.keyItem6 = true;
                            hit.transform.GetComponent<PickUpItem>().taken = true;
                        }
                        if (hit.transform.GetComponent<PickUpItem>().keyItemNumber == 7)
                        {
                            Debug.Log("key item 7 added to inventory");
                            inv.keyItem7 = true;
                            hit.transform.GetComponent<PickUpItem>().taken = true;
                        }
                        if (hit.transform.GetComponent<PickUpItem>().keyItemNumber == 7)
                        {
                            Debug.Log("key item 7 added to inventory");
                            inv.keyItem7 = true;
                            hit.transform.GetComponent<PickUpItem>().taken = true;

                        }
                        if (hit.transform.GetComponent<PickUpItem>().keyItemNumber == 8)
                        {
                            Debug.Log("key item 8 added to inventory");
                            inv.keyItem8 = true;
                            hit.transform.GetComponent<PickUpItem>().taken = true;
                        }

                    }
                }

            }
            if (hit.transform.tag == "test") //using keyitems on camp or whatever
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<UseKeyItem>().UseItem();
                }

                }
        } 



    }
}
