using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour{
    Animator animator;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    public float moveSpeed, rotateSpeed;
    public float gravity = 13.0f;
    public float jumpMag = 6f;

    public Material dissolverMaterial;
    public Material originalMaterial;
    public Material powerupMaterial;
    Renderer rend;
    
    void Start(){
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.material = originalMaterial;
    }
    void Update(){
        if(characterController.isGrounded){

            float forwardSpeed = Input.GetAxisRaw("Vertical");
            //move forward
            moveDirection = Vector3.forward * forwardSpeed;
            
            if(Input.GetKeyDown(KeyCode.Space)){
                //jump -- displace by jump distance
                moveDirection.y += jumpMag;
            }

            animator.SetFloat("Speed",forwardSpeed);
        }

        //attack
        if(Input.GetKeyDown(KeyCode.A)){
            animator.SetTrigger("Attack");
        }
        //get hit
        if(Input.GetKeyDown(KeyCode.H)){
            animator.SetTrigger("Hit");
        }
        
        //aniamtions
        animator.SetBool("OnGround", characterController.isGrounded);

        moveDirection.y -= gravity * Time.deltaTime;
        // char move
        characterController.Move(moveDirection * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.D)){
            animator.SetTrigger("isDead");
            //TODO: change material to disolve
        }else{
        }
    }

    void OnTriggerEnter(Collider coll){
        print("coll player");
        if(coll.CompareTag("Powerup")){
            animator.SetTrigger("Powerup");
            Destroy(coll.gameObject);
        }
    }
}
