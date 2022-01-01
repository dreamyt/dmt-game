using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CharacterSpell : CharacterComponents
{
    ObjectPooler Pooler;
    private float rotationAngle;
    public Text magicNumber;
    public bool isSpelling = false;
    float spellTime = 0.7f;
    float spellFinishTime;
    public int spellMode = 0;
    public float currentMagicPower;
    public float maxMagicPower;
    public float magicPowerConsumption;
    [Header("Spell Settings")]
    [SerializeField] private Vector3 SpellGeneratePosition; // The real position to generate spell attack
    [SerializeField] private Vector3 spellGeneratePosition; // The relative position of spell compared to player

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        spellMode = 0;
        magicPowerConsumption = 5;
        spellGeneratePosition = new Vector3(0f, 0f, 0f);
        Pooler = GetComponent<ObjectPooler>();
        
        maxMagicPower = 30;
        currentMagicPower = maxMagicPower;
        UIManager.Instance.UpdateMagic(currentMagicPower, maxMagicPower);
        magicNumber.text = currentMagicPower.ToString();
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

        if (spellMode == 1)
        {
            SpellAttackBlue();
        }
    }

    private void spellAttackRed()
    {
        GameObject projectilePooled = Pooler.GetObjectFromPool();
        SpellGeneratePosition = transform.position + spellGeneratePosition;
        projectilePooled.transform.position = SpellGeneratePosition;
        projectilePooled.SetActive(true);

        SpellAttack spellAttack = projectilePooled.GetComponent<SpellAttack>();
        if (GetComponent<CharacterFlip>().FacingRight)
        {
            spellAttack.TurnToRight();
        }
        else
        {
            spellAttack.TurnToLeft();
        }

        currentMagicPower -= magicPowerConsumption;
        magicNumber.text = currentMagicPower.ToString();
        UIManager.Instance.UpdateMagic(currentMagicPower, maxMagicPower);
    }

    private void SpellAttackBlue()
    {
        GameObject firstAttack = Pooler.GetObjectFromPool();
        GameObject secondAttack = Pooler.GetObjectFromPool();
        GameObject thirdAttack = Pooler.GetObjectFromPool();

        spellGeneratePosition = transform.position + spellGeneratePosition;
        firstAttack.transform.position = spellGeneratePosition + new Vector3(0,1.0f,0);
        secondAttack.transform.position = spellGeneratePosition;
        thirdAttack.transform.position = spellGeneratePosition + new Vector3(0,-1.0f,0);
        firstAttack.SetActive(true);
        firstAttack.SetActive(true);
        firstAttack.SetActive(true);
        
        currentMagicPower -= magicPowerConsumption;
        magicNumber.text = currentMagicPower.ToString();
        UIManager.Instance.UpdateMagic(currentMagicPower, maxMagicPower);
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
