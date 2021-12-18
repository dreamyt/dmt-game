using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    private Animator anim;
    private CapsuleCollider2D _capsuleCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
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
        _capsuleCollider2D.enabled = false;
    }
    void DestroyTrapPlatform()
    {
        Destroy(gameObject);
    }
}
