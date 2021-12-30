using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDetect : MonoBehaviour
{
    
    private Rigidbody2D rigid;
    private CharacterController controller;
    private Health currentHealth;
    Transform groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        controller = GetComponent<CharacterController>();
        currentHealth = GetComponent<Health>();
        groundCheck = transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        
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
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 被敌人Enemy碰到
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
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
                    LayerMask.GetMask("Enemy"));
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
            currentHealth.TakeDamage(1);

        }
    }
}
