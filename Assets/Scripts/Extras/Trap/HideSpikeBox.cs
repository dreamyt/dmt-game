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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.PolygonCollider2D")                                  
        {
            Debug.Log("damage");
            //playerHealth.DamagePlayer(damage);
        }
    }
}
