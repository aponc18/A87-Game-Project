using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamagable
{
    private int health = 1;

    public void Damage(int damage) 
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}
