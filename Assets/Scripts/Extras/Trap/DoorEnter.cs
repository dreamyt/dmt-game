using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnter : MonoBehaviour
{
    public Transform backDoor;
    private Animator anim;
    private bool isDoor = false;
    public bool canDoor = false;
    private Transform playerDefTransform;
    // Start is called before the first frame update
    void Start() 
    {
        anim = GetComponent<Animator>();
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            EnterDoor();
            
        }
    }
    void EnterDoor()
    {
        if(isDoor==true&&canDoor==true )
        {
            playerDefTransform.position = backDoor.position;
            anim.SetTrigger("openDoor");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isDoor = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isDoor = false;
        }
    }
}
