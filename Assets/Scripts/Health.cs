using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    //    [SerializeField] private Image totalHealthBar;
    //[SerializeField] private Image currentHealthBar;
    public float healthAmount;

    public Slider healthBar;
    public bool isPlayer = false;
    private bool isDead = false;
    private float currentHealth;
    private Animator anim;

    public Canvas canva;

    void Start()
    {

        currentHealth = healthAmount;

        if (isPlayer)
        {

            healthBar.maxValue = healthAmount;
            healthBar.value = currentHealth;
        }
        if (!isPlayer)
        {
            anim = GetComponent<Animator>();

        }
    }
    void Update()
    {
        if (!isPlayer)
        {
            

        }

        if (isPlayer)
        {
            healthBar.value = currentHealth;
        }
    }


    public void TakeDamage(float attackDamage)
    {
        
        float temp = Mathf.Max(currentHealth - attackDamage, 0);
        currentHealth = temp;
        
        if (currentHealth == 0 && !isDead)
        {

            Die();
        }
        else
        {
            if (!isPlayer)
            {
                anim.SetTrigger("Hurt");

            }
        }

    }

    private void Die()
    {
        if (!isPlayer)
        {
            //Instantiate(bloodPrefab,transform.position+Vector3.up*5f, Quaternion.Euler(-90f, 0, 0));    

            isDead = true;
            anim.SetTrigger("Die");
            GetComponent<NavMeshAgent>().enabled = false;
            Destroy(gameObject,5f);
        }

        if (isPlayer)
        {

            //Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            canva.gameObject.SetActive(true);
            isDead = true;
            GetComponent<PlayerController>().enabled = false;
            //Destroy(gameObject);
        }
    }
    void SpawnParticle(GameObject particle, Transform spawnPos)
    {
        Instantiate(particle, spawnPos.position, Quaternion.identity);

    }
}
