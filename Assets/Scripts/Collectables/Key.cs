using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    [SerializeField] public int keyNum;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {    
            sr.enabled = false;
            bc.enabled = false;
            keyNum += 1;
        }
    }
}
