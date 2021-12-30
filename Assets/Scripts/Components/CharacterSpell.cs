using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpell : CharacterComponents
{
    /* It's standing for the spell position togehter with the player */
    public int spellMode = 0;
    ObjectPooler Pooler;
    private float rotationAngle;
    
    public bool isSpelling = false;
    float spellTime = 0.7f;
    float spellFinishTime;
    [Header("Spell Settings")]
    [SerializeField] private Vector3 SpellGeneratePosition; // The real position to generate spell attack
    [SerializeField] private Vector3 spellGeneratePosition; // The relative position of spell compared to player

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        spellMode = 0;
        spellGeneratePosition = new Vector3(0f, 0f, 0f);
        Pooler = GetComponent<ObjectPooler>();
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        UpdateAnimations();
    }

    protected override void InternalInput()
    {
        if (!freezeInput)
        {
            if (!isSpelling && controller.isGrounded)   
            {
                if (Input.GetKey("l"))
                {
                    spellFinishTime = Time.time + spellTime;
                    isSpelling = true;
                }
            }
        }

        if (isSpelling)
        {
            if (Time.time >= spellFinishTime)
            {
                startSpellAttacking();
                isSpelling = false;
            }
        }
    }



    public void startSpellAttacking()
    {
        if(spellMode == 0)
        {
            spellAttackRed();
        }
    }

    private void spellAttackRed()
    {
        GameObject projectilePooled = Pooler.GetObjectFromPool();
        SpellGeneratePosition = transform.position + spellGeneratePosition;
        projectilePooled.transform.position = SpellGeneratePosition;
        projectilePooled.SetActive(true);
        if (controller.FacingRight)
        {
            SpellAttack.facingRight = true;
        }
        else
        {
            SpellAttack.facingRight = false;
        }

    }

    private void SpellAttackBule()
    {
        GameObject firstAttack = Pooler.GetObjectFromPool();
        GameObject secondAttack = Pooler.GetObjectFromPool();
        GameObject thirdAttack = Pooler.GetObjectFromPool();

        spellGeneratePosition = transform.position + spellGeneratePosition;
        firstAttack.transform.position = spellGeneratePosition;
        secondAttack.transform.position = spellGeneratePosition;
        thirdAttack.transform.position = spellGeneratePosition;
        firstAttack.SetActive(true);
        firstAttack.SetActive(true);
        firstAttack.SetActive(true);
        
    }

    private void UpdateAnimations()
    {
        if ((!currentHealth.dead) && (!currentHealth.getHit))
        {
            
            if (controller.isGrounded)
            {
                if (isSpelling)
                {
                    animator.SetBool("Spelling", true);
                }
                else
                {
                    animator.SetBool("Spelling", false);
                }
            }
           
        }
    }
}
