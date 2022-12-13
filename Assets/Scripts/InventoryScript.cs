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
    public GameObject addedItemText;
    private GameObject[] slots;
    public GameObject slotHolder;
    public int itemsMaxIndex;
    public int selectedItem;
    private int i;
    AudioSource audio;
    [HideInInspector] public GameObject keyItemSlot1;
    [HideInInspector] public GameObject keyItemSlot2;
    [HideInInspector] public GameObject keyItemSlot3;
    [HideInInspector] public GameObject keyItemSlot4;
    [HideInInspector] public GameObject keyItemSlot5;
    [HideInInspector] public GameObject keyItemSlot6;
    [HideInInspector] public GameObject keyItemSlot7;
    [HideInInspector] public GameObject keyItemSilhouette1;
    [HideInInspector] public GameObject keyItemSilhouette2;
    [HideInInspector] public GameObject keyItemSilhouette3;
    [HideInInspector] public GameObject keyItemSilhouette4;
    [HideInInspector] public GameObject keyItemSilhouette5;
    [HideInInspector] public GameObject keyItemSilhouette6;
    [HideInInspector] public GameObject keyItemSilhouette7;
    public bool keyItem1;
    public bool keyItem2;
    public bool keyItem3;
    public bool keyItem4;
    public bool keyItem5;
    public bool keyItem6;
    public bool keyItem7;
    public bool ending;
    public bool disabled;
    public int stickIndex;
    public bool hasStick;
    public int knifeIndex;
    public bool hasKnife;
    public bool changingItem;
    public bool escMenuOpen;
    public GameObject escMenu;
    
    [HideInInspector] public bool unlockCursor = false;
    void Start()
    {
        addedItemText = GameObject.Find("AddedItem");
        addedItemText.SetActive(false);
        audio = this.GetComponent<AudioSource>();
        act = GameObject.Find("Player").GetComponentInChildren<ActiveItem>();
        motiv = GameObject.Find("Player").GetComponent<PlayerMotivation>();
        movement = GameObject.Find("Player").GetComponentInChildren<PlayerMovement>();
        keyItemSilhouette1 = GameObject.Find("KeyItemSilhouette1");
        keyItemSilhouette2 = GameObject.Find("KeyItemSilhouette2");
        keyItemSilhouette3 = GameObject.Find("KeyItemSilhouette3");
        keyItemSilhouette4 = GameObject.Find("KeyItemSilhouette4");
        keyItemSilhouette5 = GameObject.Find("KeyItemSilhouette5");
        keyItemSilhouette6 = GameObject.Find("KeyItemSilhouette6");
        keyItemSilhouette7 = GameObject.Find("KeyItemSilhouette7");
        keyItemSlot1 = GameObject.Find("KeyItemSlot1");
        keyItemSlot2 = GameObject.Find("KeyItemSlot2");
        keyItemSlot3 = GameObject.Find("KeyItemSlot3");
        keyItemSlot4 = GameObject.Find("KeyItemSlot4");
        keyItemSlot5 = GameObject.Find("KeyItemSlot5");
        keyItemSlot6 = GameObject.Find("KeyItemSlot6");
        keyItemSlot7 = GameObject.Find("KeyItemSlot7");

        inventory.SetActive(false);
        inventoryOpen = false;
        slots = new GameObject[slotHolder.transform.childCount];
        for (int i = 0; i < slotHolder.transform.childCount; i++)
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        Debug.Log(slotHolder.transform.childCount);
        Debug.Log(slots.Length);
        RefreshUI();
        keyItemSlot1.SetActive(false);
        keyItemSlot2.SetActive(false);
        keyItemSlot3.SetActive(false);
        keyItemSlot4.SetActive(false);
        keyItemSlot5.SetActive(false);
        keyItemSlot6.SetActive(false);
        keyItemSlot7.SetActive(false);

        escMenu = GameObject.Find("EscMenu");
        escMenu.SetActive(false);
        escMenuOpen = false;

    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!escMenuOpen)
            {
                escMenu.SetActive(true);
                escMenuOpen = true;
            }
            else
            {
                escMenu.SetActive(false);
                escMenuOpen = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.I) && !motiv.dead && !movement.usingKeyItem &&!escMenuOpen)
        {
            audio.Play();
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
        if (!disabled)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && !changingItem)
            {
                changingItem = true;
                if (selectedItem != items.Count - 1)
                {
                    selectedItem++;
                }
                else selectedItem = 0;
                StartCoroutine(act.ChangeItem());
            } //scroll up
            if (Input.GetAxis("Mouse ScrollWheel") < 0f && !changingItem)
            {
                changingItem = true;
                if (selectedItem != 0)
                {
                    selectedItem = selectedItem - 1;
                }
                else selectedItem = itemsMaxIndex;
                StartCoroutine(act.ChangeItem());

            } // scroll down
        }
        itemsMaxIndex = items.Count - 1;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!inventoryOpen)
            {
                RemoveConsumableFromInventory(selectedItem);

            }
        } 
        if (inventoryOpen || unlockCursor)
        {
            Cursor.lockState = CursorLockMode.None;
            movement.canMove = false;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            movement.canMove = true;
        }
        if (keyItem1)
        {
            keyItemSilhouette1.SetActive(false);
            keyItemSlot1.SetActive(true);
        }
        if (keyItem2)
        {
            keyItemSilhouette2.SetActive(false);
            keyItemSlot2.SetActive(true);
        }
        if (keyItem3)
        {
            keyItemSilhouette3.SetActive(false);
            keyItemSlot3.SetActive(true);
        }
        if (keyItem4)
        {
            keyItemSilhouette4.SetActive(false);
            keyItemSlot4.SetActive(true);
        }
        if (keyItem5)
        {
            keyItemSilhouette5.SetActive(false);
            keyItemSlot5.SetActive(true);
        }
        if (keyItem6)
        {
            keyItemSilhouette6.SetActive(false);
            keyItemSlot6.SetActive(true);
        }
        if (keyItem7)
        {
            keyItemSilhouette7.SetActive(false);
            keyItemSlot7.SetActive(true);
        }

        if (keyItem1 && keyItem2 && keyItem3 && keyItem4 && keyItem5 && keyItem6 && keyItem7)
        {
            ending = true;
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
        changingItem = false;
    }
    public void AddItemToInventory(Item item)
    {
        items.Add(item);
        Debug.Log("Added " + item.itemName + " to inventory");
        if (item.itemName == "Knife")
        {
            hasKnife = true;
            knifeIndex = items.IndexOf(item);
        }
        if (item.itemName == "Stick")
        {
            hasStick = true;
            stickIndex = items.IndexOf(item);
        }
        RefreshUI();
        StartCoroutine(AddedItemText(item.itemName));


    }
    public IEnumerator AddedItemText(string itemName)
    {
        addedItemText.SetActive(true);
        TextMeshProUGUI text = addedItemText.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        text.text = itemName;

        yield return new WaitForSeconds(2f);
        addedItemText.SetActive(false);
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
