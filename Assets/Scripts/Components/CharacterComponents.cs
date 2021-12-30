using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponents : MonoBehaviour
{
    protected float move;
    protected bool jump;
    protected bool dash = false;
    
    protected bool freezeInput = false;
    protected CharacterController controller;
    protected CharacterMovement characterMovement;
    protected CharacterWeapon characterWeapon;
    protected Animator animator;
    protected Character character;
    protected Health currentHealth;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        controller = GetComponent<CharacterController>();
        character = GetComponent<Character>();
        characterWeapon = GetComponent<CharacterWeapon>();
        characterMovement = GetComponent<CharacterMovement>();
        animator = GetComponent<Animator>();
        currentHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        HandleAbility();
    }

    protected virtual void HandleAbility()
    {
        if (!currentHealth.dead&&!currentHealth.getHit)
        {
            InternalInput();
        }
        HandleInput();
    }

    protected virtual void InternalInput()
    {
        if (!freezeInput)
        {
            move = Input.GetAxis("Horizontal");// Get horizontal movement
            jump = Input.GetKey("k");//detect jumping 
            dash = Input.GetKey("left shift"); 
        }
    }

    protected virtual void HandleInput()
    {
        /* Currently nothing in CharacterComponent.HandleInput, just being overrode */
    }
}
