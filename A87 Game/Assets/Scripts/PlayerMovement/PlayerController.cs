using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreatingCharacters.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] protected float speed;
        [SerializeField] protected float jumpForce;
        [SerializeField] private float jumpraycastDistance;

        protected Rigidbody rb;
        private float activeSpeed;

        public bool isSprinting = false;
        public float sprintingMultiplier;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        protected virtual void Update()
        {
            Jump();
            //Sprint();
        }

        protected virtual void FixedUpdate()
        {
            Move();
        }

        protected virtual void Move()
        {
            float hAxis = Input.GetAxisRaw("Horizontal");
            float vAxis = Input.GetAxisRaw("Vertical");

            activeSpeed = speed;

            Vector3 movement = new Vector3(hAxis, 0, vAxis) * activeSpeed * Time.fixedDeltaTime;

            Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);

            rb.MovePosition(newPosition);
        }

        protected virtual void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (IsGrounded())
                {
                    rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                }

            }

        }

        /*
        protected virtual Sprint()
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
        */

        protected bool IsGrounded()
        {
            //Debug.DrawRay(transform.position, Vector3.down * jumpraycastDistance, Color.blue);
            return (Physics.Raycast(transform.position, Vector3.down, jumpraycastDistance));
        }
    }
}