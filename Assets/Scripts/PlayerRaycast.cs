using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public float maxRange;
    RaycastHit hit;
    public InventoryScript inv;
    


    void Start()
    {
        inv = GameObject.Find("Canvas").GetComponent<InventoryScript>();
        if (inv == null)
        {
            Debug.Log("inventory script not found plz fix");
        }
    }

    void Update()
    {
        Transform cameraTransform = Camera.main.transform;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, maxRange))
        {
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
