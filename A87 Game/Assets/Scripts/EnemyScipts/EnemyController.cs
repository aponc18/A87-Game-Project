using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f; //look radius
    public float fov = 120f;
    public float wanderRadius = 7f;
    public float wanderSpeed = 4f;
    public float chaseSpeed = 7f;


    private bool isAware = false;
    private Vector3 wanderPoint;
    private Animator animator;


    Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        wanderPoint = RandomWanderPoint();
        animator = GetComponentInChildren<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) //wake up and follow if too  close
        {
            OnAware();
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
        animator.SetBool("Aware", false);
        agent.speed = wanderSpeed;

        if (Vector3.Distance(transform.position, wanderPoint) < 2f)
        {
            wanderPoint = RandomWanderPoint();
        }
        else
        {
            agent.SetDestination(wanderPoint);
        }
    }

    public void OnAware()
    {
        isAware = true;
        animator.SetBool("Aware", true);
        agent.speed = chaseSpeed;
       
    }

    public Vector3 RandomWanderPoint()
    {
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);
        return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);
    }

    public void AttackTarget()
    {
        if(agent.remainingDistance < 2f)
        {
            animator.SetTrigger("Attack");
        }
    }

}

