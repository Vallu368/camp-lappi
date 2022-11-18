using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public GameObject itemPrefab;
    public string description;

    public abstract Item GetItem();
    public abstract ConsumableItem GetConsumableItem();
    public abstract MiscItem GetMiscItem();
}
