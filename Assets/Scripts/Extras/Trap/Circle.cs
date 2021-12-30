using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public float damage=1;
    public bool lifePoint = false;
    public LayerMask groundLayer;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // PhysicsCheck();
        //takeDamage();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("damage");
            other.GetComponent<Character>().TakeDamage(damage);
        }

    }
    void PhysicsCheck()
    {
        RaycastHit2D Check = Raycast(new Vector2(0f, 0f), Vector2.down, 0.2f, groundLayer);
        if (Check)
        {
            lifePoint = true;
        }
    }
    void takeDamage()
    {
        if(lifePoint==true)
        {
            GetComponent<Character>().TakeDamage(damage);
        }    
        
    }
    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDiration, float length, LayerMask layer)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDiration, length, layer);
        Debug.DrawRay(pos + offset, rayDiration * length);
        return hit;
    }
}
