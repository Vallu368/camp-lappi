using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveItem : MonoBehaviour
{
    public GameObject currentHeldItem;
    public InventoryScript inv;
        
    void Start()
    {
        inv = GameObject.Find("Canvas").GetComponent<InventoryScript>();
        ChangeHeldItem();
    }

    // Update is called once per frame
    void Update()
    {
        currentHeldItem = this.gameObject.transform.GetChild(0).gameObject;

    }
    public void InstantiateObject(GameObject gameObject)
    {

        Instantiate(gameObject, transform);
    }

    public void ChangeHeldItem() {

        Destroy(currentHeldItem);
        InstantiateObject(inv.items[inv.selectedItem].itemPrefab);

    }
}
