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

    // Update is called once per frame
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
        }



    }
}
