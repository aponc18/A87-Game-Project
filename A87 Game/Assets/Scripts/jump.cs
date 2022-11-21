using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public AudioSource jumpSound;

    void Start(){
        jumpSound = GetComponent<AudioSource>();
        
    }
    void Update(){
        
         if(Input.GetKey(KeyCode.Space)) {
            jumpSound.enabled = true;
            
        }
        else {
            jumpSound.enabled = false;
        }
    }
}
