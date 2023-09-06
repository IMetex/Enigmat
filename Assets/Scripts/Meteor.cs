using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Meteor : MonoBehaviour
{
    public Spell2 instigator;
    public LayerMask ground;
    private bool isHitGround = false;
    public GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHitGround)
        {

            var collisions = Physics.OverlapSphere(transform.position, transform.localScale.x);

            foreach (var item in collisions)
            {
                if (item.TryGetComponent<Health>(out Health enemy))
                {
                    enemy.GetComponent<NavMeshAgent>().SetDestination(enemy.transform.position);
                    enemy.TakeDamage(instigator.damage);

                }

            }
            isHitGround = false;
            gameObject.SetActive(false);
        }

        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isHitGround = true;
            Instantiate(hitEffect, transform.position+Vector3.up*.5f, Quaternion.identity);

        }
    }
}
