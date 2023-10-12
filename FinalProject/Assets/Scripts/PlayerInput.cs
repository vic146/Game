using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{ 
   [SerializeField] UI_Inventory uiInventory;
   [SerializeField] DiscreteMovement movement;
   private Inventory inventory;

    void Awake(){
        movement = GetComponent<DiscreteMovement>();
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
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
        
    }
    

}
