using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    public  float currentHealth;
    public float regenRate = 4f;

    public HealthBar healthBar;
    public static bool dead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        ResetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        ///**
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            TakeDamage(10f);
        }
        //**/
        CheckDead();
        RegenHealth();
    }

    public void TakeDamage(float damage) 
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void CheckDead() 
    {
        if (currentHealth <= 0f)
        {
            //Application.LoadLevel(Application.loadedLevel);
            dead = true;
        }
    }

    void RegenHealth() 
    {
        currentHealth += regenRate * Time.deltaTime;
        if (currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    public void ResetHealth() 
    {
        currentHealth = maxHealth;
        dead = false;
    }
   
}
