using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreatingCharacters.Player
{
    [RequireComponent(typeof(CharacterController))]

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] protected float speed = 5f;
        [SerializeField] protected float jumpForce = 4f;
        [SerializeField] protected float mass = 1f;
        [SerializeField] protected float damping = 5f;

        [SerializeField] private float jumpraycastDistance;

        protected CharacterController charContrl;

        protected float velocityY;
        protected Vector3 currentImpact;
        protected float distanceToFeet;

        private readonly float gravity = Physics.gravity.y;

        //protected Rigidbody rb;
        protected float activeSpeed;

        public bool isSprinting = false;
        public float sprintingMultiplier = 2.1f;

        protected virtual void Awake() 
        {
            charContrl = GetComponent<CharacterController>();
        }

        private void Start()
        {
            //rb = GetComponent<Rigidbody>();
        }

        protected virtual void Update()
        {
            if (!PauseMenu.isPaused || RespawnMenu.isDead)
            {
                Move();
                Jump();
                //Sprint();
            }
        }

        /*protected virtual void FixedUpdate()
        {
            Move();
        }*/

        protected virtual void Move()
        {
            float hAxis = Input.GetAxisRaw("Horizontal");
            float vAxis = Input.GetAxisRaw("Vertical");

            /*while (Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = true;
                
                activeSpeed = speed * sprintingMultiplier;
            }*/

            //isSprinting = false;
            activeSpeed = speed;

            Vector3 movementInput = new Vector3(hAxis, 0f, vAxis).normalized;
            movementInput = transform.TransformDirection(movementInput);

            if (charContrl.isGrounded && velocityY < 0f) 
            {
                velocityY = 0f;
            }

            velocityY += gravity * Time.deltaTime;

            Vector3 velocity = movementInput * activeSpeed + Vector3.up * velocityY;

            if (currentImpact.magnitude > 0.2f) 
            {
                velocity += currentImpact;
            }

            charContrl.Move(velocity * Time.deltaTime);
            currentImpact = Vector3.Lerp(currentImpact, Vector3.zero, damping * Time.deltaTime);
        }

        public void ResetImpact() 
        {
            currentImpact = Vector3.zero;
            velocityY = 0f;
        }

        protected void ResetImpactY() 
        {
            currentImpact.y = 0f;
            velocityY = 0f;
        }

        protected void ResetImpactX()
        {
            currentImpact.x = 0f;
        }

        protected virtual void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (charContrl.isGrounded) 
                {
                    AddForce(Vector3.up, jumpForce);
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

        /*protected bool IsGrounded()
        {
            //Debug.DrawRay(transform.position, Vector3.down * jumpraycastDistance, Color.blue);
            return (Physics.Raycast(transform.position, Vector3.down, jumpraycastDistance));
        }*/
        public void AddForce(Vector3 direc, float magn) 
        {
            currentImpact += direc.normalized * magn / mass;
        }
    }

    
}