using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMeleeAttack : MonoBehaviour
{
    private Rigidbody rb;
    public float attackRange = 2f;
    public float chaseRange = 10f; // New variable for chase rangee
    public float attackCooldown = 0.5f;
    public float moveSpeed = 3.0f;

    private Transform player;
    public Animator enemyAnimator;
    private bool canAttack = true;
    private bool isChasing = false; // Flag to indicate if enemy is chasing
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && canAttack)
        {
            Attack();
        }
        else if (distanceToPlayer <= chaseRange)
        {
            isChasing = true;
            Vector3 moveDirection = (player.position - transform.position).normalized;
            rb.velocity = moveDirection * moveSpeed; // Use Rigidbody velocity for movement


            Vector3 lookDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
            transform.rotation = Quaternion.LookRotation(lookDirection);

            // enemyAnimator.SetBool("IsWalking", true);
        }
        else
        {
            isChasing = false;
            // enemyAnimator.SetBool("IsWalking", false);
        }
    }

    private void Attack()
    {
        canAttack = false;
        enemyAnimator.SetTrigger("IsAttack");
        Invoke("ResetAttackCooldown", attackCooldown);
    }

    private void ResetAttackCooldown()
    {
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
