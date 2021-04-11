using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_inventory
{
    private List<Item> itemList;

    public player_inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }
}
