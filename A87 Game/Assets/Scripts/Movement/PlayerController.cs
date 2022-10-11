using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private Rigidbody rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();


    }

    private void Update() 
    {
        Jump();
    }

    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }
}
