using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{

    public enum ItemType{
        Chair,
        Table,
        FlowerPot,
        Bed,
        Picture,
        Bookshelves,
        Kitchen
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite(){
        Debug.Log("2nd");
        switch (itemType){
            default:
            case ItemType.Chair: return ItemAssets.Instance.chairSprite;
            case ItemType.Table: return ItemAssets.Instance.tableSprite;
            case ItemType.FlowerPot: return ItemAssets.Instance.potSprite;
            case ItemType.Bed: return ItemAssets.Instance.bedSprite;
            case ItemType.Picture: return ItemAssets.Instance.pictureSprite;
            case ItemType.Bookshelves: return ItemAssets.Instance.bookshelvesSprite;
            case ItemType.Kitchen: return ItemAssets.Instance.kitchenSprite;
        }
    }
}

