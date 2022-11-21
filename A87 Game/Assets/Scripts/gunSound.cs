using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSound : MonoBehaviour
{
    public AudioSource shootingR;
    void Start()
    {
        shootingR = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) {
            shootingR.enabled = true;
            Debug.Log("Mouse 0 ");
        }
        // shootingR.PlayOneShot(GetComponent<AudioSource>().clip);
    }
}
