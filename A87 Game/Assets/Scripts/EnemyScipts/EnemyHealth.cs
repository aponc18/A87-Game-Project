using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    //backup
    //[SerializeField] private EnemyStats enemyStats;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image healthBarImage;
    [SerializeField] private Color maxHealthColor;
    [SerializeField] private Color minHealthColor;
    [SerializeField] private bool regenerator;

    public int maxHealth = 3;
    public int currentHealth;//changed to public
    private Animator animator = null; //for animation trigger death
    Ragdoll ragdoll;


    //private EnemyController eControl;

    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        animator = GetComponentInChildren<Animator>(); //animation




        currentHealth = maxHealth;
        //  currentHealth = enemyStats.maxHealth;
        //SetHealthbarUI();


        var rigidBodies = GetComponentsInChildren<Rigidbody>(); //used to apply damage of all hitboxes to overall health
        foreach (var rigidBody in rigidBodies)
        {
            Hitbox hitBox = rigidBody.gameObject.AddComponent<Hitbox>();
            hitBox.health = this;

        }



    }
    private void Update()
    {
        //RegainHealth();
        //SetHealthbarUI();
    }

    public void Damage(int damage) //wanted to added vector3 direction for ragdoll push effect
    {
        currentHealth -= damage;
        CheckIfDead();
        //SetHealthbarUI();
    }

    /** public void Regen() 
     {
         if (regenerator)
         {
             while (currentHealth < enemyStats.maxHealth && currentHealth > 0)
             {
                 currentHealth++;
             }
         }
     }**/

    IEnumerator RegainHealth()
    {
        if (regenerator)
        {
            while (currentHealth < maxHealth && currentHealth > 0) //            while (currentHealth < enemyStats.maxHealth && currentHealth > 0)

            {
                yield return new WaitForSeconds(1f);
                currentHealth++;
            }
        }
    }

    private void CheckIfDead()
    {
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Death"); //animation death sequence
                                          // ragdoll.ActivateRagdoll(); 
            Destroy(gameObject, 1);//added wait time sec
        }
    }

    /**private void SetHealthbarUI()
    {
        float healthPer = CalculateHealthPerc();
        healthBar.value = healthPer;
        healthBarImage.color = Color.Lerp(minHealthColor, maxHealthColor, healthPer / 100);
    }**/

    private float CalculateHealthPerc()
    {
        return ((float)currentHealth / (float)maxHealth) * 100; //        return ((float)currentHealth / (float)enemyStats.maxHealth) * 100;

    }
}
