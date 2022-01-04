using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    //public float health;
    public float maxHealth;

    public AudioSource HeartAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        //health = GameObject.Find("Player").GetComponent<Character>().health;
        maxHealth = GameObject.Find("Player").GetComponent<Health>().maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //pickAudio.Play();
            if (GameObject.Find("Player").GetComponent<Health>().health < maxHealth)
            {
                sr.enabled = false;
                bc.enabled = false;
                //health += 1;
                //Debug.Log(health);
                HeartAudio.Play();
                GameObject.Find("Player").GetComponent<Health>().health += 1;
                UIManager.Instance.UpdateHealth(GameObject.Find("Player").GetComponent<Health>().health, maxHealth);
            }
            

        }
    }
}
