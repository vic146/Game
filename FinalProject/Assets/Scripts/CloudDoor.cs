using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudFall : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D col){
        string tag = col.tag; 
       // GetComponent<AudioSource>().pitch = Random.Range(.9f,1.1f);
        //GetComponent<AudioSource>().Play();

        if(tag == "Character"){
        SceneManager.LoadScene("Main Menu");
        }

        
    }
}
