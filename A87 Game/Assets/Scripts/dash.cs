using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
   public AudioSource dashSound;

    void Start(){
        dashSound = GetComponent<AudioSource>();
        
    }
    
    void Update(){
        
         if(Input.GetKey(KeyCode.Q)) {
            dashSound.enabled = true;
            
        }
        else {
            dashSound.enabled = false;
        }
    }
}