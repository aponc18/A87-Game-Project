using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Guns/GunWeapon")]
public class GunWeapon : ScriptableObject
{
    
    public GameObject gunPrefab;
    
    //Menu
    [Header("Stats")]
    public string gunName;
    public int maxAmmoCount;
    public int magSize;
    public int minDamage;
    public int maxDamage;
    public float maxRange;

    
    //public int currentAmmoCount = maxAmmoCount;

    public virtual void OnLeftMouseDown(Transform cameraPos) {    }

    public virtual void OnLeftMouseHold(Transform cameraPos) {    }

    protected void Fire(Transform cameraPos) 
    {
        RaycastHit whatIHit;
        //currentAmmoCount--;
        if (Physics.Raycast(cameraPos.position, cameraPos.transform.forward, out whatIHit, Mathf.Infinity))
        {
            IDamagable damageable = whatIHit.collider.GetComponent<IDamagable>();
            if (damageable != null)
            {
                float normalizedDistance = whatIHit.distance / maxRange;
                if (normalizedDistance <= 1)
                {
                    damageable.Damage(Mathf.RoundToInt(Mathf.Lerp(maxDamage, minDamage, normalizedDistance)));
                }

            }
        }
    }
}
