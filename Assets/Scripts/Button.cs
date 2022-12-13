using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public InventoryScript inv;
    public string descriptionText = "if you can see this something is borked";
    public string itemName;
    public TextMeshProUGUI text;
    public Sprite sprite;

    private void Start()
    {
        text = GameObject.Find("ItemDescription").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {

    }
    public void OnClick()
    {
        text.text = descriptionText;
    }
    public void RemoveText()
    {
        text.text = " ";
    }
    public void CloseEscMenu()
    {
        inv.escMenuOpen = false;
        inv.escMenu.SetActive(false);
    }
}
