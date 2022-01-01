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
    public AIRaycast raycast;
    
    //Returns a reference to this enemy path
    public PatrolPath Path { get; set; }

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        characterController = GetComponent<CharacterController>();
        characterSpell = GetComponent<CharacterSpell>();
        raycast = GetComponent<AIRaycast>();
        Path = GetComponent<PatrolPath>();
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
