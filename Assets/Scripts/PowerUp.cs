using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float rotationSpeed = 5f;
    // Update is called once per frame
    void Update(){
        transform.Rotate(0f,rotationSpeed,0f);//TODO can be done in shader
    }

    // void OnTriggerEnter(Collider coll){
        
    //     if(coll.CompareTag("Player")){
    //         Destroy(this);
    //     }
    // }
}
