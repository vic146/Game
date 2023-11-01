using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerInput : MonoBehaviour
{ 
   [SerializeField] UI_Inventory uiInventory;
   [SerializeField] DiscreteMovement movement;
   
   private Inventory inventory;

    void Awake(){
        Debug.Log("playerInput");
        movement = GetComponent<DiscreteMovement>();
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        /*ItemWorld.SpawnItemWorld(new Vector3(0, -3), new Item {itemType = Item.ItemType.Chair, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(1, -3), new Item {itemType = Item.ItemType.Chair, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(3, -3), new Item {itemType = Item.ItemType.Chair, amount = 1});*/
    }

    private void OnTriggerEnter2D(Collider2D collider){
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null){
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    void Update(){
    
        if(Input.GetKey(KeyCode.A)){ 
            movement.MoveRB(new Vector3(-1, 0, 0));
        }
        else if(Input.GetKey(KeyCode.D)){
            movement.MoveRB(new Vector3(1, 0, 0));
        }
        else{
            movement.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            movement.Jump();
        }
        if(transform.position.y < -8){
        SceneManager.LoadScene("Main Menu");
        }
    }
    

}
