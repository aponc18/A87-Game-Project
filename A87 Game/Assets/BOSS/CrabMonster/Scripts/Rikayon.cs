using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rikayon : MonoBehaviour
{
    //current---------------------------------------

    public float lookRadius = 10f; //look radius
    public float fov = 120f;
    public float wanderRadius = 10f;
    public float wanderSpeed = 4f;
    public float chaseSpeed = 7f;



    private Vector3 wanderPoint;
    private Animator animator = null;




    Transform target;
    UnityEngine.AI.NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        //settings for boss
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        wanderPoint = RandomWanderPoint();
        animator = GetComponentInChildren<Animator>();
        //animator.SetTrigger("Walking_Cycle_2");
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);



        if (distance <= lookRadius) //wake up and follow if too  close
        {
            BossAware();
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget(); //face the target
                AttackTarget();
            }

        }
        else
        {
            Wander();
        }

        /* if (Input.GetKeyDown(KeyCode.Space)) {
             animator.SetTrigger("Attack_1");
         }*/

    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red; //red outline
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }
    public void Wander()
    {





        //enemyIdle.Play();
        //audioSource.PlayOneShot(zombie_idle);
        // animator.SetBool("Aware", false);
        //animator.SetBool("Chasing", false);
        //animator.ResetTrigger("Walk_Cycle_2");
        //animator.ResetTrigger("Attack_2");
        animator.SetBool("Chasing", false);
        animator.SetBool("Walking", true);

        agent.speed = wanderSpeed;

        if (Vector3.Distance(transform.position, wanderPoint) < 5f)
        {
            wanderPoint = RandomWanderPoint();
        }
        else
        {
            agent.SetDestination(wanderPoint);
        }
    }

    public void BossAware()
    {
        // animator.SetBool("Aware", true);
        //animator.SetBool("Chasing", true);
        // animator.ResetTrigger("Walk_Cycle_1");
        //animator.ResetTrigger("Attack_2");
        //animator.SetTrigger("Walk_Cycle_2");
        animator.SetBool("Walking", false);
        animator.SetBool("Chasing", true);
        agent.speed = chaseSpeed;

    }

    public Vector3 RandomWanderPoint()
    {
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        UnityEngine.AI.NavMeshHit navHit;
        UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);
        return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);
    }

    public void AttackTarget()
    {
        if (agent.remainingDistance < 8f)
        {
            //enemyAttack.Play();
            //audioSource.PlayOneShot(attackSound);
           // animator.ResetTrigger("Walk_Cycle_2");
            animator.SetTrigger("Attack");
            //DealDamage(15);
        }
    }

}
