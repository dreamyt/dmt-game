using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] movePos;
    //Gets the anchor point value
    private int pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
