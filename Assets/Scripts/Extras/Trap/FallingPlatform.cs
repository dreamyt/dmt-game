using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime = 3;
    private TargetJoint2D _targeJoint2D;

    public AudioSource FallingPlatformAudio;


    // Start is called before the first frame update
    void Start()
    {
        _targeJoint2D = GetComponent<TargetJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag=="Player"&& transform.position.y<other.gameObject.transform.position.y)
        {
            FallingPlatformAudio.Play();
            Invoke("Falling", fallingTime);
        }
    }
    private void Falling()
    {
        _targeJoint2D.enabled = false;
    }
}
