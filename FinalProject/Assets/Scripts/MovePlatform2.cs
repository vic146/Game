using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform2 : MonoBehaviour
{
     public float speed = 1f;
    public float range = 2f; // Adjust this value based on your requirements
    private Vector3 initialPosition;
    
    void Start()
    {
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {  
        
        
        float movement = Mathf.PingPong(Time.time * speed, range);
        transform.position = new Vector3(initialPosition.x - movement, transform.position.y, transform.position.z);
        
        // if (playerOnPlatform){
        // GameObject player = GameObject.FindGameObjectWithTag("Character");
        // if (player != null)
        // {
        //     player.transform.position += new Vector3(-range + movement, 0f, 0f) * Time.deltaTime * speed;
        // }
        // }
    }

  void OnCollisionEnter2D(Collision2D col){
    
        string tag = col.collider.tag; 
        if(tag == "Character"){
        
            col.collider.transform.SetParent(transform);
            col.collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Debug.Log("Player entered the platform.");
        }

    }

    // OnTriggerExit is called when the Collider other has stopped touching the trigger
    void OnCollisionExit2D(Collision2D col){
    {
        string tag = col.collider.tag;
        
        if(tag == "Character"){
            col.transform.SetParent(null);
        Debug.Log("Player exited the platform.");
        }

    }

    
}
}
