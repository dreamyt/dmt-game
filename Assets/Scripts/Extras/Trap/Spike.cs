using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float damage;
                                                                                                                                             
    void Start()
    {
      
    }

    void Update()
    {
        
    }     
    
    void OnTriggerEnter2D(Collider2D other)             
    {
        if(other.CompareTag("Player"))                                 
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
