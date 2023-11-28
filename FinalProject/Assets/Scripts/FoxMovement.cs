using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FoxMovement : MonoBehaviour
{
    public float speed = 1f;
    public float range = 2f; // Adjust this value based on your requirements
    private Vector3 initialPosition;
    Rigidbody2D rb;
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] Transform body;
    public float addition = .5f;
   [SerializeField] UI_Inventory uiInventory;
   private Inventory inventory;

    void Awake()
    {
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {  
        
        
        float movement = Mathf.PingPong(Time.time * speed, range);
       
        transform.position = new Vector3(initialPosition.x + movement, transform.position.y, transform.position.z);
        if(transform.position.x > initialPosition.x){
        animationStateChanger.changeAnimationState("foxWalk", speed/5);

        if (Mathf.Approximately(transform.position.x, initialPosition.x + addition)){
            body.localScale = new Vector3(1,1,1);
        }else if(transform.position.x == initialPosition.x + range){
            body.localScale = new Vector3(-1,1,1);
         }

        }
        
    }

    void OnCollisionEnter2D(Collision2D col){
        string tag = col.collider.tag; 
       // GetComponent<AudioSource>().pitch = Random.Range(.9f,1.1f);
        //GetComponent<AudioSource>().Play();

        if(tag == "Character"){
         Inventory.Instance.ResetTotalItemCount(); 
        UI_Inventory.Instance.ClearInventoryItems();   

        SceneManager.LoadScene("Main Menu");
        }

        
    }
}
