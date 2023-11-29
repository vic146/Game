using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CloudFall : MonoBehaviour
{
    [SerializeField] UI_Inventory uiInventory;
    private Inventory inventory;
    void OnTriggerEnter2D(Collider2D col){
        string tag = col.tag; 
       // GetComponent<AudioSource>().pitch = Random.Range(.9f,1.1f);
        //GetComponent<AudioSource>().Play();

        if(tag == "Character"){
        Inventory.Instance.ResetTotalItemCount(); 
        UI_Inventory.Instance.ClearInventoryItems();    
        SceneManager.LoadScene("Main Menu");
        }

        
    }
}
