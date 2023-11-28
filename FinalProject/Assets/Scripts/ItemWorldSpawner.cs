using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Item item;

    // private void Awake(){
    //     Debug.Log("3rd");
    //     ItemWorld.SpawnItemWorld(transform.position, item);
    //     Destroy(gameObject);
    // }

    IEnumerator Start(){
        ItemWorld.SpawnItemWorld(transform.position, item);
       Destroy(gameObject);
       yield return null ; 
    }

}
