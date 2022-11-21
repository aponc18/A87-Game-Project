using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSoundSG : MonoBehaviour
{
    public AudioSource shootingSG;
    void Start()
    {
        shootingSG = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) {
            shootingSG.enabled = true;
           // Debug.Log("Mouse 0 ");
        }
         else {
            shootingSG.enabled = false;
        }
        // shootingR.PlayOneShot(GetComponent<AudioSource>().clip);
    }
}
