using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health")]
    public float initialHealth = 20f;
    [SerializeField] private float MaxHealth = 20f;
    [SerializeField] private bool destroyObject;
    public float health;
    public float maxHealth;
    public float previousHealth;
    //revive related
    public Vector3 spawnPosition;
    private float spawnPositionCheckInterval = 10.0f;//spawnPosition won't be update within 10 second
    private float nextCheckTime;
    
    public bool dead = false;
    public bool getHit = false;
    float getHitTime = 0.15f;
    float HitFinishTime;
    float spellFinishTime;
    private float rendererEndInterval = 1.5f;
    private float rendererEndTime;
    bool check = false;//used to ensure death check only execute once
    public Text healthNumber;
    private bool isPlayer;
    private Character character;
    private CharacterController controller;
    private Collider2D collider2D;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;
    private Animator anim;
    private CharacterWeapon weapon;
    private EnemyHealth enemyHealth;
    private CharacterSpell characterSpell;
    private void Awake()
    {
        character = GetComponent<Character>();
        controller = GetComponent<CharacterController>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        weapon = GetComponent<CharacterWeapon>();
        enemyHealth = GetComponent<EnemyHealth>();
        characterSpell = GetComponent<CharacterSpell>();
        dead = false;
        getHit = false;
        spawnPosition = rigid.position;
        health = initialHealth;
        previousHealth = health;
        maxHealth = MaxHealth;
        if (character.CharacterType == Character.CharacterTypes.player)
        {
            UIManager.Instance.UpdateHealth(health, maxHealth);
            healthNumber.text = health.ToString();
        }
        /*if (character != null)
        {
            isPlayer = character.CharacterType == Character.CharacterTypes.player;
        }*/

    }
    

    // Update is called once per frame
    private void Update()
    {
        if (dead)
        {
            Death();
            if (!destroyObject)
            {
                if (Input.GetKey("h"))
                {
                    Revive();
                }
                else if (Input.GetKey("r"))
                {
                    ReviveFromBeginning();
                }
            }
        }
        else
        {
            IsDead();
            if (getHit)
            {
                if (Time.time > HitFinishTime)
                {
                    getHit = false;
                }
            }
        }

        UpdateAnimations();
    }
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
    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }

    private void Death()
    {
        if (destroyObject)
        {
            rigid.simulated = false;
            characterSpell.isSpelling = false;
            Invoke("DestroyObject", 1.5f);
        }
        else
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
                deadNotice.SetActive(true);*/
                
            }

            if (Time.time > rendererEndTime)
            {
                spriteRenderer.enabled = false;
            }
        }
    }
    
    private void Revive()
    {
        /*
         Gameover.Stop();
         BGM.Play();
         weapon.ShowWeapon();
         weapon.ShootingAllowed = true;
         deadNotice.SetActive(false);
         */
        if (!destroyObject)
        {
            weapon.ShowWeapon();
            weapon.shootingAllowed = true;
            dead = false;
            rigid.simulated = true;
            spriteRenderer.enabled = true;
            anim.SetBool("Death", false);
            rigid.position = spawnPosition;
            check = false;
            health = previousHealth;
            healthNumber.text = health.ToString();
            UIManager.Instance.UpdateHealth(health, maxHealth);
        }
    }
    private void ReviveFromBeginning()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void TakeDamage(float damage)
    {
        if (health <= 0)
        {
            return;
        }
        //damage-shield
        getHit = true;
        HitFinishTime = Time.time + getHitTime;
        health -= damage;
        UpdateCharacterHealth();

    }

    private void UpdateCharacterHealth()
    {
        if (enemyHealth != null)
        {
            enemyHealth.UpdateEnemyHealth(health, maxHealth);
        }  
      
        // Update Player health
        if (character.CharacterType == Character.CharacterTypes.player)
        {
            healthNumber.text = health.ToString();
            UIManager.Instance.UpdateHealth(health, maxHealth);
        }

    }
    private void UpdateAnimations()
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
            }
        }
    }
}
