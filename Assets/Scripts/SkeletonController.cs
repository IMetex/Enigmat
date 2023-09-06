using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float chaseDistance = 5f;
    public float attackDistance = 2f;
    private NavMeshAgent agent;
    private float timeSinceLastAttack = Mathf.Infinity;
    private Animator animator;


    public bool isAttacking = false;
    private bool isChasing = false;


    private Transform playerReferance;

    public float timeBetweenAttacks = 1f;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        walkSpeed = agent.speed;
        playerReferance = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckStatus();
        UpdateAnimatorVariables();

        timeSinceLastAttack += Time.deltaTime;
    }

    void CheckStatus()
    {
        if (ReturnDistance() > chaseDistance)
        {
            agent.SetDestination(transform.position);
            isChasing = false;
        }
        if (ReturnDistance() < chaseDistance && ReturnDistance() > attackDistance)
        {
            isChasing = true;
            FaceTarget();
            agent.SetDestination(playerReferance.position);
        }
        if (ReturnDistance() < chaseDistance && ReturnDistance() <= attackDistance)
        {
            FaceTarget();

            Attack();
        }
        else
        {
            isAttacking = false;
        }

    }

    void Attack()
    {
        if (timeSinceLastAttack >= timeBetweenAttacks)
        {
            timeSinceLastAttack = 0;
            isAttacking = true;

            agent.SetDestination(transform.position);


        }
        

    }
    public void AttackEvent()
    {
        //playerReferance.GetComponent<Health>().TakeDamage(attackDamage);
    }
    void UpdateAnimatorVariables()
    {
        animator.SetBool("isAttacking", isAttacking);
        animator.SetBool("isChasing", isChasing);


    }
    float ReturnDistance()
    {
        return Vector3.Distance(transform.position, playerReferance.position);
    }
    void FaceTarget()
    {
        // Enemynin targeta doðru dönmesini saðlar
        Vector3 direction = (playerReferance.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
