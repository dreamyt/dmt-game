using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveTrigger : MonoBehaviour
{
    public GameObject Image;
    public AudioSource RevivePointAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            RevivePointAudio.Play();
            Image.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Image.SetActive(false);
    }
}
