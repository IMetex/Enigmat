using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rings : MonoBehaviour
{

    public Image ringImage;
    public Ring fireRing;
    public ParticleSystem fire;

    public Ring boltRing;
    public ParticleSystem bolt;

    public Ring iceRing;
    //public ParticleSystem ice;

    private Ring currentRing;

    bool isOne=true;
    bool isTwo=false;
    bool isThree=false;

    
    public Animator leftAnimator;






    //-------------

    // maxAbility2Distance tanýmlandý

   
    private void Start()
    {
        currentRing = fireRing;

    }
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (fireRing.isActive)
            {
                currentRing = fireRing;


                isOne = true;
                isTwo = false;
                isThree = false;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (boltRing.isActive)
            {
                currentRing = boltRing;

                isOne = false;
                isTwo = true;
                isThree = false;

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (iceRing.isActive)
            {
                currentRing = iceRing;


                isOne = false;
                isTwo = false;
                isThree = true;

            }
        }

        ringImage.sprite = currentRing.ringImage;
        SetParticle();
        SetBools();
        if (currentRing!=null)
        {
            print(currentRing.name);

        }

       

    }

    private void SetParticle()
    {
        if (isOne)
        {
            fire.gameObject.SetActive(true);
        }
        else
        {
            fire.gameObject.SetActive(false);

        }

        if (isTwo)
        {
            bolt.gameObject.SetActive(true);

        }
        else
            bolt.gameObject.SetActive(false);

    }
    private void SetBools()
    {
        leftAnimator.SetBool("isOne", isOne);
        leftAnimator.SetBool("isTwo", isTwo);
        leftAnimator.SetBool("isThree", isThree);
    }

  
    public Ring GetCurrentRing()
    {
        return currentRing;
    }
}
