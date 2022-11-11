using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUi : MonoBehaviour
{
    private Camera playerCam;

    private void Start() 
    {
        playerCam = Camera.main;
    }

    private void FixedUpdate() 
    {
        LookAtPlayer();
    }

    private void LookAtPlayer() 
    {
        transform.LookAt(transform.position + playerCam.transform.rotation * Vector3.forward, playerCam.transform.rotation * Vector3.up);

    }
}
