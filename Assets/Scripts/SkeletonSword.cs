using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSword : MonoBehaviour
{
    public Transform handPosition;
    public float damage;
    public float radius=2f;

    private void Update()
    {
        var collisions = Physics.OverlapSphere(handPosition.position, radius);
        foreach (var item in collisions)
        {
            if (item.CompareTag("Player"))
            {
                item.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(handPosition.position, radius);
    }
}
