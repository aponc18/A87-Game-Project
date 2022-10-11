using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpraycastDistance;

    private Rigidbody rb;
    private float activeSpeed;

    public bool isSprinting = false;
    public float sprintingMultiplier;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        Jump();
        //Sprint();
    }

    private void FixedUpdate() 
    {
        Move();
    }

    private void Move() 
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        activeSpeed = speed;

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * activeSpeed * Time.fixedDeltaTime;

        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);

        rb.MovePosition(newPosition);
    }

    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (IsGrounded()) 
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
            
        }
        
    }

    private void Sprint() 
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else 
        {
            isSprinting = false;
        }

        if (isSprinting)
        {
            activeSpeed += sprintingMultiplier;
        }
        else 
        {
            activeSpeed = speed;
        }
    }

    private bool IsGrounded() 
    {
        //Debug.DrawRay(transform.position, Vector3.down * jumpraycastDistance, Color.blue);
        return (Physics.Raycast(transform.position, Vector3.down, jumpraycastDistance));
    }
}
