using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstepsSound, dashSound;

    void Start(){
        footstepsSound = GetComponent<AudioSource>();
        dashSound = GetComponent<AudioSource>();
    }
    
    void Update(){
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            footstepsSound.enabled = true;

            if (Input.GetKey(KeyCode.Q)){
                footstepsSound.enabled = false;
                dashSound.enabled = true;
            }
            else{
                footstepsSound.enabled = true;
                dashSound.enabled = false;
            }
        }
        else {
            footstepsSound.enabled = false;
        }
    }
}