using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Melee Attack", fileName = "MeleeAttack")]
public class ActionMeleeAttack : AIAction
{
    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    private void Attack(StateController controller)
    {
        // Stop
        controller.characterMovement.SetHorizontal(0f);
        controller.characterMovement.SetJump(false);
        
        // Attack
        controller.animator.SetBool("Spelling", true);
    }
}

