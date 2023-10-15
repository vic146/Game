using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
   public event EventHandler OnItemListChanged;
   private List<Item> itemList;

   public Inventory(){
    itemList = new List<Item>();

    AddItem(new Item { itemType = Item.ItemType.Chair, amount = 1 });
    AddItem(new Item { itemType = Item.ItemType.Table, amount = 1 });
    AddItem(new Item { itemType = Item.ItemType.FlowerPot, amount = 1 });
    Debug.Log(itemList.Count);
   }

   public void AddItem(Item item) {
    itemList.Add(item);
    OnItemListChanged?.Invoke(this, EventArgs.Empty);
   }

   public List<Item> GetItemList(){
      return itemList;
   }
}
