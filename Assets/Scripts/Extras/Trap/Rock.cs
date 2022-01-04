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

    public AudioSource BreakRockAudio;
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
        RaycastHit2D headCheck = Raycast(new Vector2(0f, 0f), new Vector2(0.7f, 0.1f), groundLayer);
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
            BreakRockAudio.Play();
            anim.SetTrigger("strike");
        }
        else if(freq==2)
        {
            BreakRockAudio.Play();
            anim.SetTrigger("strike_2");            
        }
        else if(freq == 3)
        {
            BreakRockAudio.Play();
            anim.SetTrigger("destroy");
            //destroyBox();
        }
    }
    void destroyBox()
    {
        Destroy(gameObject);
        Instantiate(bonus, transform.position, Quaternion.identity);
    }
    RaycastHit2D Raycast(Vector2 offset, Vector2 boxSize, LayerMask layer)
    {
        Vector2 pos = transform.position;
        //public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask)
        RaycastHit2D hit = Physics2D.BoxCast(pos, boxSize, 0, new Vector2(0, -0.4f), new Vector2(0, -0.4f).magnitude, layer);
        
        return hit;
     }

    
}