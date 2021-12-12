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
    private float previousShield ;//shiedl when in the revive point
    bool dead = false;
    bool freezeInput = false;
    public bool getHit = false;
    //how long the get hit animation lasts
    float getHitTime = 0.4f;
    //record the time when get hit animation ends
    float HitFinishTime;
    float rendererEndInterval = 1.5f;//after how many seconds, the rigid simulation is ended
    float rendererEndTime;//Time to end the rigid simulation
    bool check = false;//used to ensure death check only execute once
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CharacterController>();
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
                move = Input.GetAxis("Horizontal");
                jump = Input.GetKey("k");
                dead = Input.GetKey("z");
            }
            else
            {
                move = 0;
                jump = false;
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
            anim.SetBool("Death", true);
        }
        else
        {
            if (getHit)
            {
                anim.SetBool("Jump", false);
                anim.SetBool("Moving", false);
                anim.SetBool("Hurt", true);
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
            check = true;
            rendererEndTime = Time.time + rendererEndInterval;
            rigid.simulated = false;
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
        dead = false;
        rigid.simulated = true;
        sr.enabled = true;
        anim.SetBool("Death", false);
        rigid.position = spawnPosition;
        check = false;
        health = previousHealth;
        shield = previousShield;
    }
    //Revive from the beginning of the scene
    private void ReviveFromBeginning()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
