using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMedicine : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    public int RedMedicineNum;

    [SerializeField] private ParticleSystem medicineBonus;

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
            //pickAudio.Play();
            if (GameObject.Find("Player").GetComponent<Health>().health < GameObject.Find("Player").GetComponent<Health>().maxHealth)
            {
                PlayEffects();
                sr.enabled = false;
                bc.enabled = false;

                RedMedicineNum += 1;
                if (GameObject.Find("Player").GetComponent<Health>().health+5 <= GameObject.Find("Player").GetComponent<Health>().maxHealth)
                {
                   GameObject.Find("Player").GetComponent<Health>().health += 5;   
                }
                else
                {
                    GameObject.Find("Player").GetComponent<Health>().health = GameObject.Find("Player").GetComponent<Health>().maxHealth;
                }
                UIManager.Instance.UpdateHealth(GameObject.Find("Player").GetComponent<Health>().health,
                    GameObject.Find("Player").GetComponent<Health>().maxHealth);    
                
            }

        }
    }
}
