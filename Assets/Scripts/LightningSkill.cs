using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName ="Lightning",menuName = "Ability/Spell2")]
public class LightningSkill : Spell2
{

    public GameObject zaap;
    public override void Activate()
    {
        base.Activate();

      

        var collisions = Physics.OverlapSphere(castPos.position, raycastRadius);


        foreach (var item in collisions)
        {
            if (item.TryGetComponent<Health>(out Health enemy))
            {
                enemy.TakeDamage(damage);
                enemy.GetComponent<NavMeshAgent>().SetDestination(enemy.transform.position);

            }

        }

    }

    public override void EndIndicate()
    {
        base.EndIndicate();
        Instantiate(vfx, castPos.transform.position + Vector3.up * vfxOffset, Quaternion.Euler(-90, 0, 0));
        Instantiate(zaap, castPos.transform.position + Vector3.up * 1f, Quaternion.identity);


    }


}
