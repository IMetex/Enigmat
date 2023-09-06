using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellController : MonoBehaviour
{

    public Transform handPos;
    private Ring currentRing;

    List<GameObject> projectilePool = new List<GameObject>();
    
    private float lastTimeSinceAttack = Mathf.Infinity;
    private float lastTimeSinceAbility = Mathf.Infinity;
    [SerializeField]
    private Animator anim;
    private bool isAttacking1;
    private bool isAttacking2;





    [Header("Ability 1")]
    public Image abilityImage1;
    public Image abilityImage12;
    public TextMeshProUGUI abilityText1;
    public float ability1Cooldown;
    private bool isAbility1Cooldown = false;
    private float currentAbility1Cooldown;
    [Header("Ability 2")]
    public Image abilityImage2;
    public Image abilityImage21;
    public TextMeshProUGUI abilityText2;
    
    public float ability2Cooldown;
    private bool isAbility2Cooldown = false;
    private float currentAbility2Cooldown;

    private void Start()
    {
        currentRing = GetComponent<Rings>().GetCurrentRing();
        
    }

  

    private void Update()
    {
        currentRing = GetComponent<Rings>().GetCurrentRing();

        if (currentRing == null)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (lastTimeSinceAttack >= currentRing.leftClick.timeBetweenAttacks)
            {
                lastTimeSinceAttack = 0;
                isAttacking1 = true;
            }
            

            
        }

        if (lastTimeSinceAbility >= currentRing.rightClick.cooldown)
        {
            if (Input.GetMouseButton(1))
            {
               
                currentRing.rightClick.ControlIndicator();

                
            }

        
            if (Input.GetMouseButtonUp(1))
            {


                isAttacking2 = true;
                isAbility2Cooldown = true;
                currentAbility2Cooldown = ability2Cooldown;

                lastTimeSinceAbility = 0;
                currentRing.rightClick.EndIndicate();
                currentRing.rightClick.Activate();

            }
        }


        SetBools();
        CheckCd();
        print("Current: "+currentAbility1Cooldown+"CD: "+ability1Cooldown);

        AbilityCooldown(ref currentAbility1Cooldown, ability1Cooldown, ref isAbility1Cooldown, abilityImage1, abilityText1);
        AbilityCooldown(ref currentAbility2Cooldown, ability2Cooldown, ref isAbility2Cooldown, abilityImage2, abilityText2);
        UpdateRingImage();
        CheckTimers();
    }
    private void UpdateRingImage()
    {
        abilityImage12.sprite = currentRing.leftClick.abilityImage;
        abilityImage21.sprite = currentRing.rightClick.image;

    }
    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, TextMeshProUGUI skillText)
    {
        if (isCooldown)
        {
            print("girdi");

            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0f)
            {
                print("içerde");

                isCooldown = false;
                currentCooldown = 0f;
                if (skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if (skillText != null)
                {
                    skillText.text = "";
                }
            }
            else
            {
                print("ASDFÞLASKDFALÞSDKG");
                if (skillImage != null)
                {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if (skillText != null)
                {
                    skillText.text = Mathf.Ceil(currentCooldown).ToString();
                }
            }
        }
    }
    private void CheckTimers()
    {
        lastTimeSinceAttack += Time.deltaTime;
        lastTimeSinceAbility+=Time.deltaTime;
    }
    private void CheckCd()
    {
        ability1Cooldown = currentRing.leftClick.timeBetweenAttacks;
        ability2Cooldown = currentRing.rightClick.cooldown;
    }
    private void UseSpell1()
    {
        GameObject projectile = ProjectilePool(currentRing.projectileList);
        projectile.transform.position = handPos.position;
        projectile.transform.localRotation = Quaternion.Euler(62, 30, 0);
        projectile.SetActive(true);
        projectile.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * currentRing.leftClick.projectileSpeed;
        isAttacking1 = false;
        isAbility1Cooldown = true;
        currentAbility1Cooldown = ability1Cooldown;


        //            anim.SetTrigger("isAttacking");//anim

    }

    private void SetBools()
    {
        anim.SetBool("isAttacking1", isAttacking1);
        anim.SetBool("isAttacking2", isAttacking2);
    }

    public void EndAttack2()
    {
        isAttacking2 = false;
    }
    private GameObject ProjectilePool(List<GameObject> list)
    {

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != null && !list[i].activeSelf )
            {
                return list[i];
            }
        }

        list.Add(Instantiate(currentRing.leftClick.projectile, handPos.position, Quaternion.identity));
        list[^1].GetComponent<Projectiles>().instigator = currentRing;
        return list[^1];

    }

    
  
}
