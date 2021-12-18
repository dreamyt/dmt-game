using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime = 3;
    private TargetJoint2D _targeJoint2D;
    private BoxCollider2D _boxCollider2D;



    // Start is called before the first frame update
    void Start()
    {
        _targeJoint2D = GetComponent<TargetJoint2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            Invoke("Falling", fallingTime);
        }
    }
    private void Falling()
    {
        _targeJoint2D.enabled = false;
        _boxCollider2D.isTrigger = false;
    }
}
