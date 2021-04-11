using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Sword,
        Axe,
        Gun,
        Armor,
        HealingItem,
        SpeedItem
    }

    public ItemType itemType;
    public int amount;
}
