using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item{

    public enum ItemType{
        Carrot,
        Cake
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite(){
        Debug.Log("2nd");
        switch (itemType){
            default:
            case ItemType.Carrot: return ItemAssets.Instance.carrotSprite;
            case ItemType.Cake: return ItemAssets.Instance.cakeSprite;

        }
    }

    public bool IsStackable(){
        switch (itemType) {
            default: 
            case ItemType.Carrot:
            case ItemType.Cake:
            return true;
        }
    }
}

