using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreatingCharacters.Abilities
{
    public class Dash : Ability
    {
        [SerializeField] private float dashForce;
        [SerializeField] private float dashDuration;

        private Rigidbody rb;

        private void Awake() 
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) 
            {
                StartCoroutine(Cast());
            }
        }

        public override IEnumerator Cast() 
        {
            rb.AddForce(Camera.main.transform.forward * dashForce, ForceMode.Impulse);

            yield return new WaitForSeconds(dashDuration);

            rb.velocity = Vector3.zero;
        }
    }
}