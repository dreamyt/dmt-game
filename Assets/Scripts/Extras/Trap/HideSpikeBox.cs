using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpikeBox : MonoBehaviour
{
    public int damage;
    public float destroyTime;
    //private PlayerHealth playerHealth;
    
    void Start()
    {
        //playerHealth = GameObject.FindGameObjectsWithTag("Player").GetComponent<PlayerHealth>();
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player" )
        {
            Debug.Log("damage");
            //playerHealth.DamagePlayer(damage);
        }
    }
    
}
