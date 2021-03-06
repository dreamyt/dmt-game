using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [Header("State")] 
    [SerializeField] private AIState currentState;
    [SerializeField] private AIState remainState;

    //returns the target of the enemy
    public Transform Target { get; set; }

    public CharacterMovement characterMovement;
    public CharacterController characterController;
    public CharacterSpell characterSpell;
    public CharacterFlip characterFlip;
    public AIRaycast raycast;
    public Animator animator;
    
    //Returns a reference to this enemy path
    public PatrolPath Path { get; set; }

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        characterFlip = GetComponent<CharacterFlip>();
        characterController = GetComponent<CharacterController>();
        characterSpell = GetComponent<CharacterSpell>();
        raycast = GetComponent<AIRaycast>();
        Path = GetComponent<PatrolPath>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        currentState.EvaluateState(this);
    }
    
    public void TransitionToState(AIState nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }

}
