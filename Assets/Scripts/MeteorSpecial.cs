using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Meteor", menuName = "Ability/Meteor")]
public class MeteorSpecial : Spell2
{
    public GameObject meteorPrefab;


    public override void Activate()
    {
        base.Activate();

        Instantiate(meteorPrefab,castPos.position + Vector3.up * vfxOffset, Quaternion.identity);
       
    }

}
