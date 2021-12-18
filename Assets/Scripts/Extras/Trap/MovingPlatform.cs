using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] movePos;
    //Gets the anchor point value
    private int pos;
    private Transform playerDefTransform;
    // Start is called before the first frame update
    void Start()
    {
        pos = 1;
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos[pos].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,movePos[pos].position) < 0.1f)
        {
            if(waitTime<0.0f)
            {
                if (pos == 0)
                { pos = 1; }
                else
                { pos = 0; }
                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            other.gameObject.transform.parent = gameObject.transform;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            other.gameObject.transform.parent = playerDefTransform;
        }
    }
}
