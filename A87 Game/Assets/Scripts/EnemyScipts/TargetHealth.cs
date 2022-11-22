using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private TargetStats targetStats;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image healthBarImage;
    [SerializeField] private Color maxHealthColor;
    [SerializeField] private Color minHealthColor;

    private int currentHealth;

    private void Start()
    {
        currentHealth = targetStats.maxHealth;
        SetHealthbarUI();
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        CheckIfDead();
        SetHealthbarUI();
    }

    private void CheckIfDead()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void SetHealthbarUI()
    {
        float healthPer = CalculateHealthPerc();
        healthBar.value = healthPer;
        healthBarImage.color = Color.Lerp(minHealthColor, maxHealthColor, healthPer / 100);
    }

    private float CalculateHealthPerc()
    {
        return ((float)currentHealth / (float)targetStats.maxHealth) * 100;
    }
}