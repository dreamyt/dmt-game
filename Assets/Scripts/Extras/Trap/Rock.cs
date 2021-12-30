using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Animator anim;
    public GameObject bonus;
    private int freq = 0;
    public bool isHeadBlocked;
    public LayerMask groundLayer;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PhysicsCheck();

        SpikeBox();
    }
    void PhysicsCheck()
    {
        RaycastHit2D headCheck = Raycast(new Vector2(-0.3f, 0f), Vector2.down, 0.5f, groundLayer);
        if (headCheck)
        {
            isHeadBlocked = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player" 
            && transform.position.y > other.gameObject.transform.position.y
            &&isHeadBlocked
            )
        {
            freq++;         
        }
    }
    void SpikeBox()
    {
        if(freq==1)
        {
            anim.SetTrigger("strike");
        }
        else if(freq==2)
        {            
            anim.SetTrigger("strike_2");            
        }
        else if(freq == 3)
        {
            anim.SetTrigger("destroy");
            //destroyBox();
        }
    }
    void destroyBox()
    {
        Destroy(gameObject);
        Instantiate(bonus, transform.position, Quaternion.identity);
    }
    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDiration, float length, LayerMask layer)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDiration, length, layer);
        Debug.DrawRay(pos + offset, rayDiration*length);
        return hit;
    }

    
}