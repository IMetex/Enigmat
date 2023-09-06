using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ice", menuName = "Ability/Ice")]
public class IceSpecial : Spell2
{

    public GameObject meteorPrefab;


    public override void Activate()
    {
        base.Activate();

        Instantiate(meteorPrefab, castPos.position + Vector3.up * vfxOffset, Quaternion.Euler(0,0,90));

    }
}
