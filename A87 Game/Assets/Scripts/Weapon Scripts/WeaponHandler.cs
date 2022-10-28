using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private GunWeapon currentGun;

    private Transform cameraTransform;

    private void Start() 
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update() 
    {
        CheckForShooting();
    }

    private void CheckForShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit whatIHit;
            if (Physics.Raycast(cameraTransform.position, transform.forward, out whatIHit, Mathf.Infinity))
            {
                IDamagable damagable = whatIHit.collider.GetComponent<IDamagable>();
                if (damagable != null)
                {
                    damagable.Damage(currentGun.maxDamage);
                    
                }
            }
        }
    }
}
