using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Data/Consumable Item")]
public class ConsumableItem : Item
{
    public override Item GetItem() { return this; }
    public override ConsumableItem GetConsumableItem() { return this; }

    public override MiscItem GetMiscItem() { return null; }
}
