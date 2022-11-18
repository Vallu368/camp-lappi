using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public ActiveItem act;
    public GameObject inventory;
    public PlayerMotivation motiv;
    public PlayerMovement movement;
    private bool inventoryOpen;
    public List<Item> items;
    private GameObject[] slots;
    public GameObject slotHolder;
    public int itemsMaxIndex;
    public int selectedItem;
    private int i;
    void Start()
    {
        motiv = GameObject.Find("Player").GetComponent<PlayerMotivation>();
        movement = GameObject.Find("Player").GetComponentInChildren<PlayerMovement>();
        inventory.SetActive(false);
        inventoryOpen = false;
        slots = new GameObject[slotHolder.transform.childCount];
        for (int i = 0; i < slotHolder.transform.childCount; i++)
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        Debug.Log(slotHolder.transform.childCount);
        Debug.Log(slots.Length);
        RefreshUI();

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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!inventoryOpen)
            {
                RemoveConsumableFromInventory(selectedItem);

            }
        } 
        if (inventoryOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            movement.canMove = false;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            movement.canMove = true;
        }


    }
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemIcon;
                slots[i].transform.GetChild(0).GetComponent<Button>().descriptionText = items[i].description;
                slots[i].transform.GetChild(0).GetComponent<Button>().sprite = items[i].itemIcon;
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(0).GetComponent<Button>().descriptionText = "oh fuck";
                slots[i].transform.GetChild(0).GetComponent<Button>().sprite = null;
            }
        }
    }
    public void AddItemToInventory(Item item)
    {
        items.Add(item);
        Debug.Log("Added " + item.itemName + " to inventory");
        RefreshUI();


    }
    public  void RemoveConsumableFromInventory(int i)
    {
        if (items[i].GetType() == typeof(ConsumableItem))
        {
            Debug.Log("Removing " + items[i].itemName + " from inventory");
            motiv.AddMotivation(items[i].GetConsumableItem().health);
            items.RemoveAt(i);
            selectedItem = 0;
            act.ChangeHeldItem();
            RefreshUI();
            slots[i].transform.GetChild(0).GetComponent<Button>().RemoveText();

        }
        else Debug.Log("Can't delete, not consumable");
    }
}
