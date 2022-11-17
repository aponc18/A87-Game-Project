using CreatingCharacters.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CreatingCharacters.Abilities
{
    [RequireComponent(typeof(PlayerController))]
    public class Dash : Ability
    {
        [SerializeField] private float dashForce;
        [SerializeField] private float dashDuration;

        private PlayerController playerMovementCtrl;

        private void Awake() 
        {
            playerMovementCtrl = GetComponent<PlayerController>();
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
            playerMovementCtrl.AddForce(Camera.main.transform.forward, dashForce);

            yield return new WaitForSeconds(dashDuration);

            playerMovementCtrl.ResetImpact();
        }
    }
}