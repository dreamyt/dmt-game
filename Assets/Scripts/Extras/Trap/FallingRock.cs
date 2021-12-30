using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public float damage;
    // Start is called before the first frame update
    public LayerMask groundLayer;
    public GameObject player;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PhysicsCheck();
    }
    void PhysicsCheck()
    {
        RaycastHit2D headCheck = Raycast(new Vector2(0f, 0f), Vector2.down, 10, groundLayer);
        if (headCheck)
        {
            rb.constraints =~ RigidbodyConstraints2D.FreezePositionY;
            anim.SetTrigger("fall");
            


        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("damage");
            other.GetComponent<Character>().TakeDamage(damage);
        }

    }
    void DestroyTrapPlatform()
    {
        //player.GetComponent<Character>().TakeDamage(damage);
        Destroy(gameObject);
    }
    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDiration, float length, LayerMask layer)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDiration, length, layer);
        Debug.DrawRay(pos + offset, rayDiration * length);
        return hit;
    }
}
