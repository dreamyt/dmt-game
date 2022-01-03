using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CharacterSpell : CharacterComponents
{
    ObjectPooler Pooler;
    public bool isLearnt0 = false;
    public bool isLearnt1 = false;
    private bool isNPC = false;
    private float rotationAngle;
    public Text magicNumber;
    public bool isSpelling = false;
    public float spellTime = 0.7f;
    public float spellFinishTime;
    public int spellMode = 0;
    public float currentMagicPower;
    public float maxMagicPower;
    public float magicPowerConsumption;
    public GameObject newPrefab;
    public GameObject magicRed;
    public GameObject magicBlue;
    [Header("Spell Settings")]
    [SerializeField] private Vector3 SpellGeneratePosition; // The real position to generate spell attack
    [SerializeField] private Vector3 spellGeneratePosition; // The relative position of spell compared to player

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        spellMode = 0;
        isNPC = false;
        magicPowerConsumption = 5;
        //spellGeneratePosition = new Vector3(0f, 0f, 0f);
        Pooler = GetComponent<ObjectPooler>();
        
        maxMagicPower = 30;
        currentMagicPower = maxMagicPower;
        if(character.CharacterType==Character.CharacterTypes.player)
        {
            UIManager.Instance.UpdateMagic(currentMagicPower, maxMagicPower);
            magicNumber.text = currentMagicPower.ToString();
        }

        if(CoinManager.Instance.isSpellBought1)
        {
            isLearnt0 = true;
            SwitchSpell1();
        }

        if (CoinManager.Instance.isSpellBought2)
        {
            isLearnt1 = true;
            SwitchSpell2();
        }

        
    }

    protected override void Update()
    {
        base.Update();
        if(isNPC)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isLearnt0 = true;
                CoinManager.Instance.isSpellBought1 = true;
                SwitchSpell1();
                
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                isLearnt1 = true;
                CoinManager.Instance.isSpellBought2 = true;
                SwitchSpell2();
                
            }
                
        }

    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        UpdateAnimations();
    }

    protected override void InternalInput()
    {
        if (character.CharacterType == Character.CharacterTypes.player)
        {
            if (!freezeInput)
            {
                if (CoinManager.Instance.isSpellBought1 || CoinManager.Instance.isSpellBought2)
                {
                    if (!isSpelling && controller.isGrounded)
                    {
                        if (Input.GetKeyDown(KeyCode.L))
                        {
                            Debug.Log("2");
                            spellFinishTime = Time.time + spellTime;
                            isSpelling = true;
                        }
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

            if (CoinManager.Instance.isSpellBought2)
            {
                if (Input.GetKeyDown("2"))
                {
                    spellMode = 1;
                    //newPrefab = (GameObject)Resources.Load("Prefab/BlueMagicAttack") as GameObject;
                    newPrefab = magicBlue;
                    if (newPrefab == null)
                    {
                        Debug.Log("error!");
                    }

                    Pooler.ChangePrefab(newPrefab);
                    Pooler.ChangePool();
                }
            }

            if (CoinManager.Instance.isSpellBought1)
            {
                if (Input.GetKeyDown("1"))
                {
                    spellMode = 0;
                    //newPrefab = (GameObject)Resources.Load("Prefab/BlueMagicAttack") as GameObject;
                    newPrefab = magicRed;
                    if (newPrefab == null)
                    {
                        Debug.Log("error!");
                    }

                    Pooler.ChangePrefab(newPrefab);
                    Pooler.ChangePool();
                }
            }
        }
    }

    public void SwitchSpell1()
    {
        if (CoinManager.Instance.isSpellBought1)
        {
         
                spellMode = 0;
                //newPrefab = (GameObject)Resources.Load("Prefab/BlueMagicAttack") as GameObject;
                newPrefab = magicRed;
                if (newPrefab == null)
                {
                    Debug.Log("error!");
                }

                Pooler.ChangePrefab(newPrefab);
                Pooler.ChangePool();
            
        }
    }

    public void SwitchSpell2()
    {
        if (CoinManager.Instance.isSpellBought2)
        {
                spellMode = 1;
                //newPrefab = (GameObject)Resources.Load("Prefab/BlueMagicAttack") as GameObject;
                newPrefab = magicBlue;
                if (newPrefab == null)
                {
                    Debug.Log("error!");
                }

                Pooler.ChangePrefab(newPrefab);
                Pooler.ChangePool();
            
        }
    }
    //used by ai
    public void useSpell()
    {
        if (!isSpelling && controller.isGrounded)   
        {
            spellFinishTime = Time.time + spellTime;
            isSpelling = true;
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
            if (isLearnt0)
             spellAttackRed();
        }

        if (spellMode == 1)
        {
            if (isLearnt1)
              SpellAttackBlue();

            
        }
    }

    private void spellAttackRed()
    {
        GameObject projectilePooled = Pooler.GetObjectFromPool();
        if (GetComponent<CharacterFlip>().FacingRight)
        {
            SpellGeneratePosition = transform.position + spellGeneratePosition;
        }
        else
        {
            SpellGeneratePosition = transform.position - spellGeneratePosition;
        }
        projectilePooled.transform.position = SpellGeneratePosition;
        projectilePooled.SetActive(true);

        SpellAttack spellAttack = projectilePooled.GetComponent<SpellAttack>();
        if (GetComponent<CharacterFlip>().FacingRight)
        {
            spellAttack.facingRight = true;
        }
        else
        {
            spellAttack.TurnToLeft();
        }

        currentMagicPower -= magicPowerConsumption;
        if (character.CharacterType == Character.CharacterTypes.player)
        {
            magicNumber.text = currentMagicPower.ToString();
            UIManager.Instance.UpdateMagic(currentMagicPower, maxMagicPower);
        }
        
    }

    private void SpellAttackBlue()
    {
        if (GetComponent<CharacterFlip>().FacingRight)
        {
            SpellGeneratePosition = transform.position + spellGeneratePosition;
        }
        else
        {
            SpellGeneratePosition = transform.position - spellGeneratePosition;
        }
        
        GameObject firstAttack = Pooler.GetObjectFromPool();
        firstAttack.transform.position = SpellGeneratePosition + new Vector3(0,1.0f,0);
        firstAttack.SetActive(true);

        GameObject secondAttack = Pooler.GetObjectFromPool();
        secondAttack.transform.position = SpellGeneratePosition;
        secondAttack.SetActive(true);
        
        GameObject thirdAttack = Pooler.GetObjectFromPool();
        thirdAttack.transform.position = SpellGeneratePosition + new Vector3(0,-1.0f,0);
        thirdAttack.SetActive(true);
        
        SpellAttack spellAttack1 = firstAttack.GetComponent<SpellAttack>();
        SpellAttack spellAttack2 = secondAttack.GetComponent<SpellAttack>();
        SpellAttack spellAttack3 = thirdAttack.GetComponent<SpellAttack>();
        if (GetComponent<CharacterFlip>().FacingRight)
        {
            spellAttack1.facingRight = true;
            spellAttack2.facingRight = true;
            spellAttack3.facingRight = true;
        }
        else
        {
            spellAttack1.TurnToLeft();
            spellAttack2.TurnToLeft();
            spellAttack3.TurnToLeft();
        }
        
        currentMagicPower -= magicPowerConsumption;
        if (character.CharacterType == Character.CharacterTypes.player)
        {
            magicNumber.text = currentMagicPower.ToString();
            UIManager.Instance.UpdateMagic(currentMagicPower, maxMagicPower);
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("NPC"))
            isNPC = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
            isNPC = false;
    }


}
