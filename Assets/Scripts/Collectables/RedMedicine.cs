using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMedicine : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D bc;

    [SerializeField] private ParticleSystem medicineBonus;

    public AudioSource MedicineAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    protected  void PlayEffects()
    {
        Instantiate(medicineBonus, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            MedicineAudio.Play();
           
                PlayEffects();
                sr.enabled = false;
                bc.enabled = false;

                Health health = collision.gameObject.GetComponent<Health>();
                health.health += 5;
                if (health.health >= health.maxHealth)
                {
                    health.health = health.maxHealth;
                }
                UIManager.Instance.UpdateHealth(health.health, health.maxHealth);    
                
        }

        
    }
}
