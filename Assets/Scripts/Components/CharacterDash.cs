using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDash : CharacterComponents
{
    private float currentStamina;     // The stamina is the value of physical strength.
    public float maxStamina;         // The maximum of stamina. Stamina is used for dashing etc.
    // maybe have dashing effect, an image or particle effects.
    private bool isSlower = false;
    private bool isfaster = false;
    private CharacterMovement movement;
    private bool audioPlaying;
    private float audioDuringTime = 1.0f;
    private float audioFinishTime;

    public AudioSource DashAudio;
    protected override void Start()
    {
        base.Start();
        maxStamina = 30;
        currentStamina = maxStamina;
        movement = GetComponent<CharacterMovement>();
        UIManager.Instance.UpdateStamina(currentStamina, maxStamina);
    }

    // Update is called once per frame
    protected override void HandleAbility()
    {
        base.HandleAbility();

    }

    private void FixedUpdate()
    {
        Dash();
    }

    private void Dash()
    {
        
        if (dash)
        {
            if (currentStamina >= 0)
            {
                if (move > 0.3 || move < -0.3)
                {
                    /* Notice: "speed" only controls the left or right moving, but not affects jumping */
                    movement.MoveSpeed = 680;
                    currentStamina -= 1.0f;
                    UIManager.Instance.UpdateStamina(currentStamina, maxStamina);
                    
                    if (!audioPlaying)
                    {
                        audioPlaying = true;
                        DashAudio.Play();
                        audioFinishTime = Time.time + audioDuringTime;
                    }
                    else
                    {
                        if (Time.time > audioFinishTime)
                        {
                            audioPlaying = false;
                        }
                    }
                }
                
                        /*
                         * Consider the way to improve
                         * if >= 0.1, is ok, but not necessary
                         * speed offers HighSpeed and LowSpeed, not necessary
                         */

            }
            else
            {
                            Debug.Log("cannot run!");
                            movement.MoveSpeed = movement.initialSpeed;
                            /* Cannot dash, just show red color in stamina bar */

            }
        }
        else
        {
            movement.MoveSpeed = movement.initialSpeed;
            currentStamina = (currentStamina >= maxStamina ? maxStamina : currentStamina + 0.3f);
            UIManager.Instance.UpdateStamina(currentStamina, maxStamina);
        }
    }
}
