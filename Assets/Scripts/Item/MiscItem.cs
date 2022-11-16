using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Data/Misc Item")]
public class MiscItem : Item
{
    public override Item GetItem() { return this; }
    public override ConsumableItem GetConsumableItem() { return null; }
    public override MiscItem GetMiscItem() { return this; }
}
