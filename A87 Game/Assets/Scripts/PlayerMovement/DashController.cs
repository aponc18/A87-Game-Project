using CreatingCharacters.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreatingCharacters.Abilities
{
    public class DashController : PlayerController
    {
        private int jumpCounter = 0;

        protected override void Update() 
        {
            base.Update();

            if (IsGrounded()) 
            {
                jumpCounter = 0;
            }
        }

        protected override void Jump() 
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
               
                if (jumpCounter == 0)
                {
                    rb.velocity = Vector3.up * jumpForce;
                    if (IsGrounded())
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
                    rb.velocity = Vector3.up * jumpForce * 1.5f;
                    jumpCounter = 2;
                }
            }
            
        }
    }
}