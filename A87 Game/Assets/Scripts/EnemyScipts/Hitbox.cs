using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public EnemyHealth health;

    public void OnRaycastHit(GunWeapon weapon)
    {
        health.Damage(weapon.maxDamage);
    }
    
}
