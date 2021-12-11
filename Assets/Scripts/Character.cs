using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Character : MonoBehaviour
{

    private Rigidbody2D rigid;
    private CharacterController cc;
    private Animator anim;
    float move;
    bool jump;

    public float speed = 280;
    Transform groundCheck;
    bool dead = false;
    bool freezeInput = false;
    public bool getHit = false;
    //how long the get hit animation lasts
    float getHitTime = .2f;
    //record the time when get hit animation ends
    float HitFinishTime;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        cc = GetComponent<CharacterController>();
        groundCheck = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
    }

    //Update is called once per frame
    private void Update()
    {

        if (dead)
        {
         
        }
        else
        {
            if (!freezeInput)
            {
                move = Input.GetAxis("Horizontal");
                jump = Input.GetKey("k");
            }
            else
            {
                move = 0;
                jump = false;
            }
            IsDead();
        }
       // SetAnim();
    }
    /*void SetAnim()
    {
        if (dead)
        {
            anim.SetBool("jump_up", false);
            anim.SetBool("Moving", false);
            anim.SetBool("jump_down", false);
            anim.SetBool("hit", false);
            anim.SetBool("death", true);
        }
        else
        {
            if (getHit)
            {
                anim.SetBool("jump_up", false);
                anim.SetBool("Moving", false);
                anim.SetBool("jump_down", false);
                anim.SetBool("hit", true);
            }
            else
            {
                anim.SetBool("hit", false);
                if (cc.isGrounded)
                {
                    anim.SetBool("jump_up", false);
                    anim.SetBool("jump_down", false);
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
                    if (rigid.velocity.y > 0)
                    {
                        anim.SetBool("jump_up", true);
                        anim.SetBool("jump_down", false);
                    }
                    else
                    {
                        anim.SetBool("jump_up", false);
                        anim.SetBool("jump_down", true);
                    }
                }
            }
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {

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
    //Check if the player is dead
    private void IsDead()
    {
        if (dead)
        {
            return;
        }
        if (transform.position.y < -8)
        {
            dead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
