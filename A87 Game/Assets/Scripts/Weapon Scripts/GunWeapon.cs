using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Guns/GunWeapon")]
public class GunWeapon : ScriptableObject
{
    
    public GameObject gunPrefab;
    //public ParticleSystem muzzleFlash;
    
    //Menu
    [Header("Stats")]
    public string gunName;
    public int maxAmmoCount;
    public int magSize;
    public int minDamage;
    public int maxDamage;
    public float maxRange;

    
    //public int currentAmmoCount = maxAmmoCount;

    public virtual void OnLeftMouseDown(Transform cameraPos, ParticleSystem particles) {    }

    public virtual void OnLeftMouseHold(Transform cameraPos, ParticleSystem particles) {    }

    protected void Fire(Transform cameraPos, ParticleSystem particles) 
    {
        RaycastHit whatIHit;
        //currentAmmoCount--;
        //particles.Play();
        //muzzleFlash.Play();
        //Debug.print("Muzzleflash");
        if (Physics.Raycast(cameraPos.position, cameraPos.transform.forward, out whatIHit, Mathf.Infinity))
        {
            //muzzleFlash.Play();
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

    /**protected void mFlash() 
    {
        muzzleFlash.Play();
    }**/
    
}
