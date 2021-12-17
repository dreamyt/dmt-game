using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttack : MonoBehaviour
{
    Transform initialState;
    public Vector3 currentDirection;
    public Vector3 initialDirection;
    public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        initialState = transform;
        initialDirection = new Vector3 (1.0f, 0.0f, 0.0f);
        currentDirection = initialDirection;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("SpellFlying");
        transform.position = transform.position + currentDirection * speed;
    }

    public void setDirection(Vector2 newDirection)
    {
        currentDirection = newDirection;
    }

}
