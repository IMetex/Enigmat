using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Spell1", menuName = "Magic/Spell1")]

public class Spell1 : ScriptableObject
{
    public string spellName;
    public Sprite abilityImage;
    public float projectileSpeed;
    public ParticleSystem vfx;
    public float damage;
    public AnimatorOverrideController animation;
    public GameObject projectile;
    public float timeBetweenAttacks;
    public float projectileLifeTime;
}
