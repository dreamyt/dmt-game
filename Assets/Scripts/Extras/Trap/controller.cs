using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private bool theKey = false;
    public GameObject[] Door;

    public AudioSource OpenDoorAudio;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(theKey == true)
            {
                anim.SetTrigger("open");
                OpenDoorAudio.Play();
                foreach (var D in Door)
                {
                    D.GetComponent<DoorEnter>().canDoor = true;
                }
               // Door.GetComponent<DoorEnter>().canDoor = true;
                
            }
            
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            theKey = true;
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            theKey = false;
        }
    }
}
