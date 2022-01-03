using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : MonoBehaviour
{
    public Vector3 Direction;//Moving direction
    public float timer;
    public float DeltaTime;
    public float MoveSpeed = 6;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DeltaTime -= Time.deltaTime;
        if (DeltaTime <= 0)
        {
            DeltaTime = timer;

            MoveSpeed = -MoveSpeed;
        }
        transform.Translate(Direction * Time.deltaTime * MoveSpeed);
    }
}
