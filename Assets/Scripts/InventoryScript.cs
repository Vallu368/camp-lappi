using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public ActiveItem act;
    public GameObject inventory;
    private bool inventoryOpen;
    public List<Item> items;
    public int itemsMaxIndex;
    public int selectedItem;
    public string selectedItemName;
    void Start()
    {
        inventory.SetActive(false);
        inventoryOpen = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryOpen)
            {
                inventory.SetActive(true);
                inventoryOpen = true;
            }
            else
            {
                inventory.SetActive(false);
                inventoryOpen = false;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedItem != items.Count - 1)
            {
                selectedItem++;
            }
            else selectedItem = 0;
            act.ChangeHeldItem();
        } //scroll up
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedItem != 0)
            {
                selectedItem = selectedItem - 1;
            }
            else selectedItem = itemsMaxIndex;
            act.ChangeHeldItem();

        } // scroll down
        itemsMaxIndex = items.Count - 1;
        if (Input.GetKeyDown(KeyCode.R))
        {
            RemoveConsumableFromInventory(selectedItem);
        } //temp test for deleting consumable from inventory

    }
    public void AddItemToInventory(Item item)
    {
        items.Add(item);
        Debug.Log("Added " + item.itemName + " to inventory");
    }
    public  void RemoveConsumableFromInventory(int i)
    {
        if (items[i].GetType() == typeof(ConsumableItem))
        {
            Debug.Log("Removing " + items[i].itemName + " from inventory");
            items.RemoveAt(i);
            selectedItem = 0;
            act.ChangeHeldItem();
        }
        else Debug.Log("Can't delete, not consumable");
    }
}
