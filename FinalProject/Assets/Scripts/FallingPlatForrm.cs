using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatForrm : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
    
        string tag = col.collider.tag; 
        if(tag == "Character"){

            this.GetComponent<Rigidbody2D>().gravityScale = -10000f;
        
            

    }
}
}