using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponents : MonoBehaviour
{

    protected Animator animator;
    protected Character character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
