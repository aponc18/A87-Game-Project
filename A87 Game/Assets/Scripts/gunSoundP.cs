using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSoundP : MonoBehaviour
{
    public AudioSource shootingP;
    void Start()
    {
        shootingP = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) {
            shootingP.enabled = true;
           // Debug.Log("Mouse 0 ");
        }
         else {
            shootingP.enabled = false;
        }
        // shootingR.PlayOneShot(GetComponent<AudioSource>().clip);
    }
}
