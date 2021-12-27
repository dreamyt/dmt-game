using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player" && transform.position.y < other.gameObject.transform.position.y)
        {
            anim.SetTrigger("Collapse");
        }
    }
    
    void DisableBoxCollider2D()
    {

    }
    void DestroyTrapPlatform()
    {
        Destroy(gameObject);
    }
}
