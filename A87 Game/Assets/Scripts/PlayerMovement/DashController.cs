using CreatingCharacters.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreatingCharacters.Abilities
{
    public class DashController : PlayerController
    {
        [SerializeField] private float edgeForce;
        [SerializeField] private float climbSpeed;
        [SerializeField] private float wallRaycast;

        private bool isClimbing = false;

        private int jumpCounter = 0;

        public float speedBoost = 8f;

        protected override void Update() 
        {
            if (!isClimbing) 
            {
                base.Update();
            }
            

            if (charContrl.isGrounded) 
            {
                jumpCounter = 0;

                

            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
             {
                 speed += speedBoost;
             }
             else if (Input.GetKeyUp(KeyCode.LeftShift)) 
             {
                 speed -= speedBoost;
             }
        }

        protected override void Jump() 
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, wallRaycast)) 
                {
                    if (hit.collider.GetComponent<Climbable>() != null) 
                    {
                        StartCoroutine(Climb(hit.collider));
                    }
                }

                if (jumpCounter == 0)
                {
                    ResetImpactY();
                    AddForce(Vector3.up, jumpForce);
                    //rb.velocity = Vector3.up * jumpForce;

                    if (charContrl.isGrounded)
                    {
                        jumpCounter = 1;
                    }
                    else 
                    {
                        jumpCounter = 2;
                    }
                }
                else if (jumpCounter == 1) 
                {
                    ResetImpactY();
                    AddForce(Vector3.up, jumpForce*1.8f);
                    //rb.velocity = Vector3.up * jumpForce * 1.8f;
                    jumpCounter = 2;
                }
            }
            
        }

        private IEnumerator Climb(Collider climbableCollider) 
        {
            isClimbing = true;

            while (Input.GetKey(KeyCode.Space)) 
            {
                RaycastHit hit;
                Debug.DrawRay(transform.position, transform.forward * wallRaycast, Color.blue, 0.5f);
                if (Physics.Raycast(transform.position, transform.forward, out hit, wallRaycast))
                {
                    if (hit.collider == climbableCollider)
                    {
                        charContrl.Move(new Vector3(0f, climbSpeed * Time.deltaTime, 0f));
                        yield return null;
                    }
                    else 
                    {
                        break;
                    }
                }
                else 
                {
                    break;
                }
            }

            ResetImpactY();
            AddForce(Vector3.up, edgeForce);
            isClimbing = false;
        }
    }
}