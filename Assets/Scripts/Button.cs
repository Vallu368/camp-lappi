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
}
