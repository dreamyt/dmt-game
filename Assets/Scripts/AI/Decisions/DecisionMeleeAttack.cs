using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/MeleeAttack", fileName = "DecisionMeleeAttack")]
public class DecisionMeleeAttack : AIDecision
{
    public override bool Decide(StateController controller)
    {
        return canAttack(controller);
    }

    private bool canAttack(StateController controller)
    {
        if (controller.characterController.isGrounded)
        {
            if (controller.raycast.attack_range)
            {
                return true;
            }
        }

        return false;
    }
}

