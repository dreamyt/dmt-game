using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpikeBox : MonoBehaviour
{
    public int damage;
    public float destroyTime;
    //public Character character;
    
    void Start()
    {
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
            this.GetComponent<Character>().TakeDamage(damage);
        }
    }
    
}
