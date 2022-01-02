using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDetect : MonoBehaviour
{
    public GameObject panal1;
    private Rigidbody2D rigid;
    private CharacterController controller;
    private Health currentHealth;
    private CoinManager currentCoin;
    private CharacterMovement move;
    Transform groundCheck;
    private bool isMerchant = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        controller = GetComponent<CharacterController>();
        currentHealth = GetComponent<Health>();
        currentCoin = GetComponent<CoinManager>();
        groundCheck = transform.Find("GroundCheck");
        move = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isMerchant)
            {

                currentHealth.TakeDamage(0.1f);
                currentHealth.previousHealth -= 1;
                if (currentHealth.previousHealth == 3)
                    panal1.SetActive(true);
                move.changespeed(1000);
                if(controller.jumpForce <= 1100)
                    controller.jumpForce += 100;
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyWeapon"))
        {
            currentHealth.TakeDamage(1);
        }

        if (collision.CompareTag("Trampoline"))
        {
            rigid.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
        }
        
        if (collision.CompareTag("EnemyBullet"))
        {
            currentHealth.TakeDamage(collision.GetComponent<ReturnToPool>().damage);
        }

        if (collision.CompareTag("EnemySpell"))
        {
            currentHealth.TakeDamage(collision.GetComponent<SpellReturnToPool>().damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 被敌人Enemy碰到
        if (collision.gameObject.layer == LayerMask.NameToLayer("SpecialEnemy"))
        {
            // 如果在空中，要先检测是不是脚底踩到敌人
            if (!controller.isGrounded)
            {
                float w = 0.3f;
                if (transform.localScale.x > 1.1f)
                {
                    w = 0.5f;
                }
                Collider2D[] colliders = Physics2D.OverlapBoxAll(groundCheck.position, new Vector2(w, 0.2f), 0,
                    LayerMask.GetMask("SpecialEnemy"));
                foreach (Collider2D c in colliders)
                {
                    Health rd = c.GetComponent<Health>();
                    if (rd != null)
                    {
                        rd.dead = true;
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
            currentHealth.TakeDamage(1);

        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("merchant"))
        {

            isMerchant = true;
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("merchant"))
            isMerchant = false;
    }

}
