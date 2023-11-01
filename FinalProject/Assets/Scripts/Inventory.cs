// using System.Collections;
// using System;
// using System.Collections.Generic;
// using UnityEngine;

// public class Inventory
// {
//    public event EventHandler OnItemListChanged;
//    private List<Item> itemList;

//    public Inventory(){
//     itemList = new List<Item>();
//    /*
//     AddItem(new Item { itemType = Item.ItemType.Carrot, amount = 1 });
//     AddItem(new Item { itemType = Item.ItemType.Cake, amount = 1 });
//     */
//     Debug.Log(itemList.Count);
//    }

//    public void AddItem(Item item) {
//     if(item.IsStackable()){
//       bool itemAlreadyInInventory = false;
//       foreach (Item inventoryItem in itemList){
//          if(inventoryItem.itemType == item.itemType){
//             inventoryItem.amount += item.amount;
//             itemAlreadyInInventory = true;
//          }
//       }
//       if(!itemAlreadyInInventory){
//          itemList.Add(item);
//       }
//     }
//     else{
//     itemList.Add(item);
//     }
//     OnItemListChanged?.Invoke(this, EventArgs.Empty);
//    }

//    public List<Item> GetItemList(){
//       return itemList;
//    }
// }


// Inventory 


using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

// public class Inventory
// {
//    public static Inventory Instance { get; private set; }
//    public event EventHandler OnItemListChanged;
//    private List<Item> itemList;

//    public Inventory(){
//     itemList = new List<Item>();
//    /*
//     AddItem(new Item { itemType = Item.ItemType.Carrot, amount = 1 });
//     AddItem(new Item { itemType = Item.ItemType.Cake, amount = 1 });
//     */
//     Debug.Log(itemList.Count);
//    }

//    private void Awake()
//     {
//         if (Instance == null)
//         {
//             Instance = this;
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//     }

//    public void AddItem(Item item) {
//     if(item.IsStackable()){
//       bool itemAlreadyInInventory = false;
//       foreach (Item inventoryItem in itemList){
//          if(inventoryItem.itemType == item.itemType){
//             inventoryItem.amount += item.amount;
//             itemAlreadyInInventory = true;
//          }
//       }
//       if(!itemAlreadyInInventory){
//          itemList.Add(item);
//       }
//     }
//     else{
//     itemList.Add(item);
//     }
//     OnItemListChanged?.Invoke(this, EventArgs.Empty);
//    }

//    public List<Item> GetItemList(){
//       return itemList;
//    }
// }

public class Inventory
{

private static Inventory _instance;

public static Inventory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Inventory();
            }
            return _instance;
        }
    }

   
   public event EventHandler OnItemListChanged;
   private List<Item> itemList;


   // Add a property to keep track of the total item count
   public int TotalItemCount { get; private set; }

   public Inventory(){
      itemList = new List<Item>();
    
      UpdateItemAmounts();
   }
 private void UpdateItemAmounts()
    {
        foreach (Item item in itemList)
        {
            item.amount += TotalItemCount;
        }
    }

  

   public void AddItem(Item item)
   {
      if (item.IsStackable())
      {
         bool itemAlreadyInInventory = false;
         foreach (Item inventoryItem in itemList)
         {
            if (inventoryItem.itemType == item.itemType)
            {
               inventoryItem.amount += item.amount;
               itemAlreadyInInventory = true;
            }
         }
         if (!itemAlreadyInInventory)
         {
            itemList.Add(item);
         }
      }
      else
      {
         itemList.Add(item);
      }

      // Update the total item count
      TotalItemCount += item.amount;

      OnItemListChanged?.Invoke(this, EventArgs.Empty);
   }

   public List<Item> GetItemList()
   {
      
      return itemList;
     
   }
   public void ResetTotalItemCount()
{
    TotalItemCount = 0;
    foreach (Item item in itemList)
    {
        item.amount = 0;
    }
    UpdateItemAmounts();
    OnItemListChanged?.Invoke(this, EventArgs.Empty);
}
}



