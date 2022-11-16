using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Item : ScriptableObject
{
    public string itemName;
    public GameObject itemPrefab;

    public abstract Item GetItem();
    public abstract ConsumableItem GetConsumableItem();
    public abstract MiscItem GetMiscItem();
}
