using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponents : MonoBehaviour
{
    protected float horizontalInput;
    protected float verticalInput;

    protected Animator animator;
    protected Character character;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        character = GetComponent<Character>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        HandleAbility();
    }

    protected virtual void HandleAbility()
    {
        InternalInput();
        HandleInput();
    }

    protected virtual void InternalInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    protected virtual void HandleInput()
    {
        /* Currently nothing in CharacterComponent.HandleInput, just being overrode */
    }
}
