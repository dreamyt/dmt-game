using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Character : MonoBehaviour
{
    //revive
    public Vector3 spawnPosition;
    private float spawnPositionCheckInterval = 10.0f;//spawnPosition won't be update within 10 second
    private float nextCheckTime;
    private CharacterWeapon weapon;
    //basic movement
    private Rigidbody2D rigid;
    private CharacterController cc;
    private SpriteRenderer sr;
    private Animator anim;
    float move;
    bool jump;
    public float speed = 280;
    Transform groundCheck;
    //status
    public float health = 10.0f;
    private float previousHealth;//health when in the revive point
    public float shield = 0;
    private float previousShield ;//shield when in the revive point
    bool dead = false;
    //bool attack = false;  /* Moved to CharacterWeapon. */
    bool freezeInput = false;
    public bool getHit = false;
    public bool isSpelling = false;
    public SpellAttack basicSpell;
    //how long the get hit animation lasts
    float getHitTime = 0.4f;
    float spellTime = 0.7f;
    //record the time when get hit animation ends
    float HitFinishTime;
    float spellFinishTime;
    private float rendererEndInterval = 1.5f;
    private float rendererEndTime;
    bool check = false;//used to ensure death check only execute once

    CharacterSpell characterSpell;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CharacterController>();
        weapon = GetComponent<CharacterWeapon>();
        characterSpell = GetComponent<CharacterSpell>();
        groundCheck = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
        previousHealth = health;
        previousShield = shield;
        spawnPosition = rigid.position;
    }

    //Update is called once per frame
    private void Update()
    {

        if (dead)
        {
            Death();
            if (Input.GetKey("h"))
            {
                Revive();
            }
            else if (Input.GetKey("r"))
            {
                ReviveFromBeginning();
            }
        }
        else
        {
            if (!freezeInput)
            {
                move = Input.GetAxis("Horizontal");         // Get horizontal movement
                jump = Input.GetKey("k");                   // Press K to jump
                dead = Input.GetKey("z");                   // Press Z to suicide
                //isSpelling = Input.GetKey("l");             // Press L to attack with spell

                if (!isSpelling && Input.GetKey("l"))   
                {
                    spellFinishTime = Time.time + spellTime;
                    isSpelling = true;
                }

                /* use CharacterWeapon to deal with attack.
                 * attack = Input.GetKey("j");                 // Press J to attack (either melee or ranged) */
            }
            else
            {
                move = 0;
                jump = false;
                isSpelling = false;
            }
            IsDead();
        }
        SetAnim();
    }
    private void FixedUpdate()
    {
        if (!dead)
        {
            if (!getHit)
            {
                /* Can only start spelling when not hit && jumping (of course not dead!) */
                if (!jump)
                {
                    if (isSpelling)
                    {
                        if (Time.time >= spellFinishTime)
                        {
                            StartSpellAttack();
                            basicSpell.gameObject.SetActive(true);
                            isSpelling = false;
                        }
                    }
                }
                cc.Move(move * speed * Time.fixedDeltaTime, jump);
                //weapon.ShootingAllowed = true;
            }
            //can't shoot and move while get hit
            else
            {
                //weapon.ShootingAllowed = false;
                cc.Move(0, false);
                if (Time.time > HitFinishTime)
                {
                    getHit = false;
                }
            }
        }
    }
    void SetAnim()
    {
        if (dead)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Moving", false);
            anim.SetBool("Hurt", false);
            anim.SetBool("Spelling", false);  // Spelling is stopped by Death
            anim.SetBool("Death", true);
        }
        else
        {
            if (getHit)
            {
                anim.SetBool("Jump", false);
                anim.SetBool("Moving", false);
                anim.SetBool("Hurt", true);
                anim.SetBool("Spelling", false);  // Spelling is also stopped by Hurt
            }       
            else
            {
                anim.SetBool("Hurt", false);
                if (cc.isGrounded)
                {
                    anim.SetBool("Jump", false);
                    if (Mathf.Abs(move) > 0.1f)
                    {
                        anim.SetBool("Moving", true);
                    }
                    else
                    {
                        anim.SetBool("Moving", false);
                    }

                    if (isSpelling)
                    {
                        anim.SetBool("Spelling", true);
                    }
                    else
                    {
                        anim.SetBool("Spelling", false);
                    }
                }
                else
                {   
                    anim.SetBool("Jump", true);
                }
            }
        }
    }
    
 
    //Check if the player is dead
    private void IsDead()
    {
        if (dead)
        {
            return;
        }
        if (transform.position.y < -10)
        {
            dead = true;
        }
        if(health <= 0)
        {
            dead = true;
        }
    }
    //things need to be done when player is dead, destroying the weapon, disable the animation
    private void Death()
    {
        if (!check)
        {
            rendererEndTime = Time.time + rendererEndInterval;
            check = true;
            rigid.simulated = false;
            weapon.RemoveWeapon();
            weapon.shootingAllowed = false;
            /*BGM.Stop();
            Gameover.Play();
            //destroy weapon
            weapon.RemoveWeapon();
            deadNotice.SetActive(true);
            //forbidden shooting
            weapon.ShootingAllowed = false;*/
        }

        if (Time.time > rendererEndTime)
        {
            sr.enabled = false;
        }
    }
    //Revive from the previous revive point
    private void Revive()
    {
       /*
        Gameover.Stop();
        BGM.Play();
        weapon.ShowWeapon();
        weapon.ShootingAllowed = true;
        deadNotice.SetActive(false);
        */
        weapon.ShowWeapon();
        weapon.shootingAllowed = true;
        dead = false;
        rigid.simulated = true;
        sr.enabled = true;
        anim.SetBool("Death", false);
        rigid.position = spawnPosition;
        check = false;
        health = previousHealth;
        shield = previousShield;
    }
    //hurt 
    public void TakeDamage(float damage)
    {
        if (health <= 0)
        {
            return;
        }
        //damage-shield
        float remainingDamage = damage;
        getHit = true;
        HitFinishTime = Time.time + getHitTime;
        if (shield>0)
        {
            if (shield >= damage)
            {
                shield -= damage;
                return;
            }
            else
            {
                shield = 0;
                remainingDamage = damage - shield;
            }
        }
        else
        {
            health -= remainingDamage;
        }

    }
    private void StartSpellAttack()
    {
        characterSpell.startSpellAttacking();
        /* This code is for start spelling */
    }

    //Revive from the beginning of the scene
    private void ReviveFromBeginning()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Weapon"))
        {
            TakeDamage(1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 被敌人Enemy碰到
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // 如果在空中，要先检测是不是脚底踩到敌人
            if (!cc.isGrounded)
            {
                float w = 0.3f;
                if (transform.localScale.x > 1.1f)
                {
                    w = 0.5f;
                }
                Collider2D[] colliders = Physics2D.OverlapBoxAll(groundCheck.position, new Vector2(w, 0.2f), 0, LayerMask.GetMask("Enemy"));
                foreach (Collider2D c in colliders)
                {
                    RoleDie rd = c.GetComponent<RoleDie>();
                    if (rd != null)
                    {
                        rd.Die(c.transform);
                        // 反弹
                        rigid.velocity = new Vector2(rigid.velocity.x, 0);
                        rigid.AddForce(new Vector2(0, 300));
                    }
                }
                if (colliders.Length > 0)
                {
                    return;
                }
            }

            // 运行到这里说明没踩到敌人，碰撞死亡
            TakeDamage(1);
          
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Collection"))
        { // Collection 包括： 血量，金币，药水等

        }

       
    }
}
