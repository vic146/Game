using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D col){
    
        PlayerManager manager = col.GetComponent<PlayerManager>();
        if (manager){
            manager.pickup();
            Destroy(this.gameObject);
        }        
    }
}
