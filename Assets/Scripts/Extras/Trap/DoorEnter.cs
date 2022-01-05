using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnter : MonoBehaviour
{
    public Transform backDoor;
    private Animator anim;
    public GameObject image;
    private bool isDoor = false;
    public bool canDoor = false;
    private Transform playerDefTransform;
    
    public AudioSource TransmissionAudio;
    // Start is called before the first frame update
    void Start() 
    {
        anim = GetComponent<Animator>();
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            EnterDoor();
            
        }
    }
    void EnterDoor()
    {
        if(isDoor==true&&canDoor==true )
        {
            TransmissionAudio.Play();
            playerDefTransform.position = backDoor.position;
            anim.SetTrigger("openDoor");
        }
        if(canDoor==false)
            if(isDoor)
                image.SetActive(true);
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
            image.SetActive(false);
        }
    }
}
