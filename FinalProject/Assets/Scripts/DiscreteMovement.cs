using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    Rigidbody2D rb;
    [SerializeField] float jumpForce = 5;
    [SerializeField] LayerMask groundMask;
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] Transform body;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Start(){

    }
    public void MoveRB(Vector3 vel){
       vel *= speed;
       vel.y = rb.velocity.y;
       rb.velocity = vel;
       Debug.Log(vel);
       if(vel.magnitude > 0){
        animationStateChanger.changeAnimationState("Walk", speed/5);
        if (vel.x > 0){
            body.localScale = new Vector3(1,1,1);
        }else if(vel.x < 0){
            body.localScale = new Vector3(-1,1,1);
         }
       }
       else{
         animationStateChanger.changeAnimationState("Idle");
       }
    }

    public void Stop(){
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        animationStateChanger.changeAnimationState("Idle");
    }

    public void Jump(){
        if(Physics2D.OverlapCircleAll(transform.position - new Vector3(0,.5f,0),1,groundMask).Length > 0){
            rb.AddForce(new Vector3(0, jumpForce ,0), ForceMode2D.Impulse);
        }
        
    }
}
