// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class UI_Inventory : MonoBehaviour
// {
//     [SerializeField] private Inventory inventory;
//     [SerializeField] private Transform itemSlotContainer;
//     [SerializeField] private Transform itemSlotTemplate;
  
    

//     /*private void Start(){
//         itemSlotContainer = transform.Find("itemSlotContainer");
//         itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
//     }*/

//     public void SetInventory(Inventory inventory){
//         this.inventory = inventory;

//         inventory.OnItemListChanged += Inventory_OnItemListChanged;
//         RefreshInventoryItems();
//     }

//     private void Inventory_OnItemListChanged(object sender, System.EventArgs e){
//         RefreshInventoryItems();
//     }

//     private void RefreshInventoryItems(){
//         foreach(Transform child in itemSlotContainer){
//             if (child == itemSlotTemplate) continue;
//             Destroy(child.gameObject);
//         }
//         int x = 0;
//         int y = 0;
//         float itemSlotCellSize = 150f;
//         foreach (Item item in inventory.GetItemList()){
//             int itemPoints = item.amount ;
//             Debug.Log("Here");
//             RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
//             itemSlotRectTransform.gameObject.SetActive(true);
//             itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
//             Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
//             image.sprite = item.GetSprite();
//             TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
//             if (item.amount > 1){
//             uiText.SetText(item.amount.ToString());
//             }
//             else{
//                 uiText.SetText("");
//             }
//             x++;
//             if (x > 4){
//                 x = 0;
//                 y++;
//             }
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplate;
  
    public static UI_Inventory Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*private void Start(){
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }*/

    public void SetInventory(Inventory inventory){
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e){
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems(){
        foreach(Transform child in itemSlotContainer){
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 150f;
        foreach (Item item in inventory.GetItemList()){
            int itemPoints = item.amount ;
            Debug.Log("Here");
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1){
            uiText.SetText(item.amount.ToString());
            }
            else{
                uiText.SetText("");
            }
            x++;
            if (x > 4){
                x = 0;
                y++;
            }
        }
    }
public void DestroyUIInventory()
{
    Destroy(gameObject);
}

public void ClearInventoryItems()
{
    foreach (Transform child in itemSlotContainer)
    {
        if (child == itemSlotTemplate) continue;
        Destroy(child.gameObject);
    }
}



}