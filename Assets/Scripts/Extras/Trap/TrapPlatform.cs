using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    private Animator anim;

    public AudioSource TrapPlatformAudio;

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
            TrapPlatformAudio.Play();
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
