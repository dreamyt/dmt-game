using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Debug = UnityEngine.Debug;

public class CharacterMovement : CharacterComponents
{
    [SerializeField] private float Speed = 280;
    public float initialSpeed;
    public float MoveSpeed { get; set; }

    private readonly int movingParameter = Animator.StringToHash("Moving");
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        initialSpeed = Speed;
        MoveSpeed = Speed;
    }

    // Update is called once per frame
    protected override void HandleAbility()
    {
        base.HandleAbility();
        MoveCharacter();
        UpdateAnimations();
    }

    private void MoveCharacter()
    {
        controller.SetMovement(move * MoveSpeed * Time.fixedDeltaTime, jump);
    }

    private void UpdateAnimations()
    {
        if ((!currentHealth.dead) && (!currentHealth.getHit))
        {
            
            if (controller.isGrounded)
            {
                animator.SetBool("Jump", false);
                if (Mathf.Abs(move) > 0.1f)
                {
                    animator.SetBool(movingParameter, true);
                }
                else
                {
                    animator.SetBool(movingParameter, false);
                }
                
            }
            else
            {   
                animator.SetBool("Jump", true);
               
            }
        }
    }
}
